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
    public class AccessTokenManagerTest
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configRoot;

        public AccessTokenManagerTest()
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
        public async Task TestGetAccessToken()
        {
            var accessTokenManager = _serviceProvider.GetService<IAccessTokenManager>();
            var token = await accessTokenManager.GetAccessToken();
            Assert.NotNull(token);
        }
    }
}
