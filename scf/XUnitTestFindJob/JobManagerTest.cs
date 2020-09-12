using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Yhd.FindJob;
using Yhd.TencentCloud.SCF.Config;

namespace XUnitTestFindJob
{
    public class JobManagerTest
    {
        private readonly IServiceCollection _services;
        private IServiceProvider _serviceProvider;
        private readonly IConfiguration _configRoot;

        public JobManagerTest()
        {
            _configRoot = AppConfigurations.Get(Environment.CurrentDirectory);

            _services = new ServiceCollection();
            _services.AddFindJob(_configRoot);
            _services.AddEasyCaching(options =>
            {
                options.UseInMemory();
            });
            _services.AddSingleton(_configRoot);
            _serviceProvider = _services.BuildServiceProvider();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }


        [Fact]
        public async Task TestGetJobs()
        {
            string source = "2";
            List<string> sources = new List<string>();
            sources.Add("1");
            sources.Add(source);
            string city = "±±¾©ÊÐ";
            string searchKey = ".net";
            int pageIndex = 1;

            IJobsManager jobsManager = _serviceProvider.GetService<IJobsManager>();
            var jobs = await jobsManager.GetJobsAsync(sources, city, searchKey, pageIndex);
            Assert.True(jobs.Count > 0);
        }
    }
}
