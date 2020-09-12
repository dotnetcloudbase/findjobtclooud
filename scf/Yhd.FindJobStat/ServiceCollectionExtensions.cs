using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Yhd.FindJobStat
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFindJobStat(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.Configure<WxCloudOption>(configuration.GetSection("WxCloud"));
            services.AddSingleton<IAccessTokenManager, AccessTokenManager>();
            services.AddSingleton<ApiHttpClient>();
            services.AddSingleton<WxCloudApi>();

            return services;
        }
    }
}
