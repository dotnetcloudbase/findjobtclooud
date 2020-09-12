
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Yhd.TencentCloud.SCF.Executors;

namespace Yhd.TencentCloud.SCF
{
    /// <summary>
    /// A <see cref="SCFHost"/> is the execution container for scf. Once started, the
    /// <see cref="SCFHost"/> will manage and run scf functions when they are triggered.
    /// </summary>
    public class SCFHost : ISCFHost, IDisposable
    {
        private const int StateNotStarted = 0;
        private const int StateStarting = 1;
        private const int StateStarted = 2;
        private const int StateStoppingOrStopped = 3;

        private readonly SCFHostOptions _options;
        private readonly CancellationTokenSource _shutdownTokenSource;
        private readonly CancellationTokenSource _stoppingTokenSource;


        // Null if we haven't yet started runtime initialization.
        // Points to an incomplete task during initialization. 
        // Points to a completed task after initialization. 
        private Task _initializationRunning = null;

        private int _state;
        private Task _stopTask;
        private bool _disposed;

        // Common lock to protect fields.
        private object _lock = new object();

        private ILogger _logger;

        private IHttpClientFactory _httpFactory;

        private IFunctionInvoker _functionInvoker;

        /// <summary>
        /// Initializes a new instance of the <see cref="SCFHost"/> class using the configuration provided.
        /// </summary>
        /// <param name="configuration">The job host configuration.</param>
        public SCFHost(IOptions<SCFHostOptions> options, IFunctionInvoker invoker,ILogger<SCFHost> logger, IHttpClientFactory httpFactory)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _httpFactory = httpFactory;
            _options = options.Value;
            _logger = logger;
            _functionInvoker = invoker;
            _shutdownTokenSource = new CancellationTokenSource();
            _stoppingTokenSource = CancellationTokenSource.CreateLinkedTokenSource(_shutdownTokenSource.Token);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            if (Interlocked.CompareExchange(ref _state, StateStarting, StateNotStarted) != StateNotStarted)
            {
                throw new InvalidOperationException("Start has already been called.");
            }

            return StartAsyncCore(cancellationToken);
        }

        protected virtual async Task StartAsyncCore(CancellationToken cancellationToken)
        {
            await EnsureHostInitializedAsync(cancellationToken);

            await OnHostStarted();

            string msg = "SCF host started";
            _logger?.LogInformation(msg);

            _state = StateStarted;
        }

        public Task StopAsync()
        {
            ThrowIfDisposed();

            Interlocked.CompareExchange(ref _state, StateStoppingOrStopped, StateStarted);

            if (_state != StateStoppingOrStopped)
            {
                throw new InvalidOperationException("The host has not yet started.");
            }

            // Multiple threads may call StopAsync concurrently. Both need to return the same task instance.
            lock (_lock)
            {
                if (_stopTask == null)
                {
                    _stoppingTokenSource.Cancel();
                    _stopTask = StopAsyncCore(CancellationToken.None);
                }
            }

            return _stopTask;
        }

        protected virtual async Task StopAsyncCore(CancellationToken cancellationToken)
        {   
            string msg = "SCF host stopped";
            _logger?.LogInformation(msg);
        }

         /// <summary>
        /// Dispose the instance
        /// </summary>
        /// <param name="disposing">True if currently disposing.</param>
        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_shutdownTokenSource")]
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                // Running callers might still be using this cancellation token.
                // Mark it canceled but don't dispose of the source while the callers are running.
                // Otherwise, callers would receive ObjectDisposedException when calling token.Register.
                // For now, rely on finalization to clean up _shutdownTokenSource's wait handle (if allocated).
                _shutdownTokenSource.Cancel();

                _stoppingTokenSource.Dispose();

                _disposed = true;
            }
        }


        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(null);
            }
        }

        /// <summary>
        /// Ensure all required host services are initialized and the host is ready to start
        /// processing function invocations. This function does not start the listeners.
        /// If multiple threads call this, only one should do the initialization. The rest should wait.
        /// When this task is signalled, _context is initialized.
        /// </summary>
        private Task EnsureHostInitializedAsync(CancellationToken cancellationToken)
        {

            TaskCompletionSource<bool> tsc = null;

            lock (_lock)
            {
                if (_initializationRunning == null)
                {
                    // This thread wins the race and owns initialing. 
                    tsc = new TaskCompletionSource<bool>();
                    _initializationRunning = tsc.Task;
                }
            }

            if (tsc != null)
            {
                // Ignore the return value and use tsc so that all threads are awaiting the same thing. 
                Task ignore = InitializeHostAsync(cancellationToken, tsc);
            }

            return _initializationRunning;
        }

        // Caller gaurantees this is single-threaded. 
        // Set initializationTask when complete, many threads can wait on that. 
        // When complete, the fields should be initialized to allow runtime usage. 
        private async Task InitializeHostAsync(CancellationToken cancellationToken, TaskCompletionSource<bool> initializationTask)
        {
            try
            {
                //var context = await _jobHostContextFactory.Create(_shutdownTokenSource.Token, cancellationToken);

                // must call this BEFORE setting the results below
                // since listener startup is blocking on those members
                await OnHostInitialized();
            

                initializationTask.SetResult(true);
            }
            catch (Exception e)
            {
                initializationTask.SetException(e);
            }
        }



        /// <summary>
        /// Called when host initialization has been completed, but before listeners
        /// are started.
        /// </summary>
        protected virtual Task OnHostInitialized()
        {
             return Task.CompletedTask;
        }

        /// <summary>
        /// Called when all listeners have started and the host is running.
        /// </summary>
        protected virtual async Task OnHostStarted()
        {
            // Get APP and PORT to communicate with scf
            string scf_host = Environment.GetEnvironmentVariable("SCF_RUNTIME_API");
            string scf_port = Environment.GetEnvironmentVariable("SCF_RUNTIME_API_PORT");
            // _HANDLER -- user defined function entrance, may not be used.
            string handler = Environment.GetEnvironmentVariable("_HANDLER");
            // user defined value, passed with env. 
            string user_def_env = Environment.GetEnvironmentVariable("myKey");
            // urls.
            string ready_url = $"http://{scf_host}:{scf_port}/runtime/init/ready";
            string event_url = $"http://{scf_host}:{scf_port}/runtime/invocation/next";
            string response_url = $"http://{scf_host}:{scf_port}/runtime/invocation/response";
            string error_url = $"http://{scf_host}:{scf_port}/runtime/invocation/error";

            // some initialization work
            GlobalInitialization(handler, user_def_env);
            // send POST to read_url --  initialztion finished.
            await PostAsync(ready_url, "dotnet ready");
            _logger.LogInformation("Dotnet CustomRuntime Ready");

            // loop: get event -> process ->  post response.
            while (true)
            {
                try
                {
                    // get next event and process (print event)
                    string response = await GetAndProcessEvent(handler, event_url);
                    // send process result to scf
                    await PostAsync(response_url, response);
                }
                catch(Exception ex)
                {
                    await PostAsync(error_url, ex.Message);
                }
            }
        }


        void GlobalInitialization(string handler, string uv)
        {
            _logger.LogInformation("Doing Initialization, _HANDLER [" + handler + "] UserDefinedEnv [" + uv + "]\n");
        }

        // 使用post方法异步请求
        // url 目标链接
        // data 发送的参数字符串
        // return 返回的字符串
        public async Task<string> PostAsync(string url, string data)
        {
            var responseBody = string.Empty;
            _logger.LogInformation("Post Data :" + data);

#if RELEASE
            var client = _httpFactory.CreateClient();
            client.Timeout = Timeout.InfiniteTimeSpan;
            HttpContent content = new StringContent(data);
            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            
            responseBody = await response.Content.ReadAsStringAsync();
#endif
            return responseBody;

        }

        // 使用get方法异步请求
        // url 目标链接
        // return 返回的字符串
        public async Task<string> GetAndProcessEvent(string handler, string url)
        {
            // Use Get Api to grab events.
            var client = _httpFactory.CreateClient();
            client.Timeout = Timeout.InfiniteTimeSpan;


//用来抛异常的

            string responseBody = string.Empty;
            IEnumerable<string> values;
            string memoryLimitMB = "";
            int memoryLimitInMb = 0;
            string timeLimitMs = "";
            int timeLimitInMs = 0;
            string requestId = "";

#if RELEASE
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Events in response body, other infos in header.
            responseBody = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("Get event :" + responseBody);

            //Retrive information from header.
            //Retrive memory limit
            // Retrive time limit
            // Retrive request id
            HttpHeaders headers = response.Headers;

            if (headers.TryGetValues("memory_limit_in_mb", out values))
            {
                memoryLimitMB = values.First();
                int.TryParse(memoryLimitMB, out memoryLimitInMb);
            }
            if (headers.TryGetValues("time_limit_in_ms", out values))
            {
                timeLimitMs = values.First();
                int.TryParse(timeLimitMs, out timeLimitInMs);
            }
            if (headers.TryGetValues("request_id", out values))
            {
                requestId = values.First();
            }
#endif
            SCFContext context = new SCFContext(requestId, handler, timeLimitInMs, memoryLimitInMb);
            //process event.
            string res = await _functionInvoker.ProcessEvent(responseBody, context);

            return res;
        }
 
    }
}
