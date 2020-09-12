using LBS.Amap.SDK;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AmapOptionsServiceCollectionExtensions
    {
        public static IServiceCollection AddAmapOptions(this IServiceCollection services, IConfiguration config, string sectionName = "Amap")
        { 
            services.AddOptions<AmapOptions>().Configure(options =>
            {
                var amapSection = config.GetSection(sectionName);
                amapSection.Bind(options);

            }).Validate(options =>
            {
                return !string.IsNullOrWhiteSpace(options.Key);
            }, "Amap Key is empty");

            return services;
        }
    }
}
