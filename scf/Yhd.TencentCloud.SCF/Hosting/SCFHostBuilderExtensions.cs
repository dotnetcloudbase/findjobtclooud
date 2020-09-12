
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;
using Yhd.TencentCloud.SCF;
using Yhd.TencentCloud.SCF.Config;
using Yhd.TencentCloud.SCF.Hosting;

namespace Microsoft.Extensions.Hosting
{
    public static class SCFHostBuilderExtensions
    {
        private static IConfigurationRoot _appConfiguration;

        public static IHostBuilder ConfigureSCF(this IHostBuilder builder)
        {
            return builder.ConfigureSCF(o => { }, o => { });
        }

        public static IHostBuilder ConfigureSCF(this IHostBuilder builder, Action<ISCFBuilder> configure)
        {
            return builder.ConfigureSCF(configure, o => { });
        }

        public static IHostBuilder ConfigureSCF(this IHostBuilder builder, Action<ISCFBuilder> configure, Action<SCFHostOptions> configureOptions)
        {
            return builder.ConfigureSCF((context, b) => configure(b), configureOptions);
        }

        public static IHostBuilder ConfigureSCF(this IHostBuilder builder, Action<HostBuilderContext, ISCFBuilder> configure)
        {
            return builder.ConfigureSCF(configure, o => { });
        }

        public static IHostBuilder ConfigureSCF(this IHostBuilder builder, Action<HostBuilderContext, ISCFBuilder> configure, Action<SCFHostOptions> configureOptions)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var hostingEnvironment = context.HostingEnvironment;
                 _appConfiguration = AppConfigurations.Get(hostingEnvironment.ContentRootPath, hostingEnvironment.EnvironmentName);
            });

            builder.ConfigureLogging((context, b) =>
            {
                 b.SetMinimumLevel(LogLevel.Debug);
                 b.AddConsole();
            });

            builder.ConfigureServices((context, services) =>
            {                
                ISCFBuilder scfBuilder = services.AddSCF(configureOptions, _appConfiguration);
                configure(context, scfBuilder);

                services.AddHttpClient();
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IHostedService, SCFHostService>());
            });

            return builder;
        }
    }
}