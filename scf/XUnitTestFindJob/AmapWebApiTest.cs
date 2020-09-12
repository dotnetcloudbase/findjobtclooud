using LBS.Amap.SDK;
using LBS.Amap.SDK.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestFindJob
{
    public class AmapWebApiTest
    {
        private readonly IServiceCollection _services;
        private IServiceProvider _serviceProvider;
        private readonly IConfiguration _configRoot;

        IConfigurationBuilder builder;

       
           
        

        public AmapWebApiTest()
        {
            builder = new ConfigurationBuilder();

            const string KEY = "71822e73b7871a41f4cb386413d3db0c";
            builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                { "Amap:Key", KEY }
            });
            _configRoot = builder.Build();

 
            _services = new ServiceCollection();
            _services.AddAmapOptions(_configRoot);
            _services.AddLBSAmap();
            _services.AddSingleton(_configRoot);
            _serviceProvider = _services.BuildServiceProvider();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Fact]
        public async Task TestGetReGeoCode()
        {
            ReGeoParameter reGeoParameter = new ReGeoParameter()
            {
                Location = "116.481488,39.990464",
                Batch = false,
                Output = "JSON",
                Radius = 1000,
                RoadLevel = 0,
                Extensions = "base",
                Poitype = string.Empty
            };

            IAmapWebApi jobsManager = _serviceProvider.GetService<IAmapWebApi>();
            var jobs = await jobsManager.GetRegeoAsync(reGeoParameter);
            Assert.True(jobs.ReGeoCode.AddressComponent.Country == "中国");
        }
    }
}
