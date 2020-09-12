using LBS.Amap.SDK;
using LBS.Amap.SDK.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LBSAmapServiceCollectionExtensions
    {
        public static IServiceCollection AddLBSAmap(this IServiceCollection services)
        {
            services.AddHttpClient<AmapHttpClient>();
            services.AddSingleton<IAmapWebApi, AmapWebApi>();
            return services;
        }
    }
}
