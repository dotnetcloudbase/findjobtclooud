using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Yhd.FindJobStat;
using Yhd.TencentCloud.SCF.Config;

namespace XUnitTestFindJobStat
{
    public class WxCloudApiTest
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configRoot;

        public WxCloudApiTest()
        {
            _configRoot = AppConfigurations.Get(Environment.CurrentDirectory);
            _services = new ServiceCollection();
            _services.AddFindJobStat(_configRoot);
            _services.AddEasyCaching(options =>
            {
                options.UseInMemory();
            });
            _services.AddSingleton(_configRoot);
            _serviceProvider = _services.BuildServiceProvider();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Fact]
        public async Task TestWxCloudApiGetStatPV()
        {
            var wxCloudApi = _serviceProvider.GetService<WxCloudApi>();
            var invokeResult = await wxCloudApi.InvokeCloudFunction("get-stat-pv");
            Assert.Equal(0, invokeResult.ErrorCode);
            Assert.Equal("ok", invokeResult.ErrorMessage);
            Assert.NotNull(invokeResult.ResponseData);
        }

        [Fact]
        public async Task TestWxCloudApiGetStatApplyButton()
        {
            var wxCloudApi = _serviceProvider.GetService<WxCloudApi>();
            var invokeResult = await wxCloudApi.InvokeCloudFunction("get-stat-apply");
            Assert.Equal(0, invokeResult.ErrorCode);
            Assert.Equal("ok", invokeResult.ErrorMessage);
            Assert.NotNull(invokeResult.ResponseData);
        }

        [Fact]
        public async Task TestWxCloudApiGetStatTopSearch()
        {
            var wxCloudApi = _serviceProvider.GetService<WxCloudApi>();
            var invokeResult = await wxCloudApi.InvokeCloudFunction("get-stat-top-search");
            Assert.Equal(0, invokeResult.ErrorCode);
            Assert.Equal("ok", invokeResult.ErrorMessage);
            Assert.NotNull(invokeResult.ResponseData);
        }

        [Fact]
        public async Task TestWxCloudApiGetStatTopCity()
        {
            var wxCloudApi = _serviceProvider.GetService<WxCloudApi>();
            var invokeResult = await wxCloudApi.InvokeCloudFunction("get-stat-top-city");
            Assert.Equal(0, invokeResult.ErrorCode);
            Assert.Equal("ok", invokeResult.ErrorMessage);
            Assert.NotNull(invokeResult.ResponseData);
        }
    }
}
