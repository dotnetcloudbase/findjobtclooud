
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Yhd.TencentCloud.SCF.Hosting
{
    internal class SCFBuilder : ISCFBuilder
    {
        public SCFBuilder(IServiceCollection services, IConfigurationRoot configuration)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
            Configuration = configuration?? throw new ArgumentNullException(nameof(configuration));
        }

        public IServiceCollection Services { get; }


        public IConfigurationRoot Configuration { get; }
    }
}
