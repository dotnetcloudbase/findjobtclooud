using EasyCaching.Core.Configurations;
using EasyCaching.Redis;
using LBS.Amap.SDK;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yhd.FindJob
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFindJob(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
           
            services.AddAmapOptions(configuration);
            services.AddLBSAmap();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddSingleton<IFindJobFactory, FindJobFactory>();
            services.AddSingleton<IJobsManager, JobsManager>();

          
            return services;
        }
    }
}
