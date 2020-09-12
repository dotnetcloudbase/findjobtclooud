using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Yhd.TencentCloud.SCF.Protocols;

namespace Yhd.TencentCloud.SCF.Executors
{
    public class HttpFunctionInvoker : FunctionInvoker
    {
        private ILogger _logger;

        public HttpFunctionInvoker(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpFunctionInvoker>();
        }

        public override async Task<string> ProcessEvent(string responseBody, SCFContext context)
        {
            _logger.LogInformation($"start {context.Handler }");

            APIGatewayProxyRequestEvent requestEvent = JsonConvert.DeserializeObject<APIGatewayProxyRequestEvent>(responseBody);

            var response = await Handler(context, requestEvent);

            return response.ToString();
        }

        protected virtual async  Task<APIGatewayProxyResponseEvent> Handler(SCFContext context, APIGatewayProxyRequestEvent requestEvent)
        {
            return new APIGatewayProxyResponseEvent() { 
                 StatusCode =  200,
                 IsBase64Encoded = false,
                  Headers = new Dictionary<string, string>(),
                  Body = requestEvent.ToString()
                };
        }
    }
}
