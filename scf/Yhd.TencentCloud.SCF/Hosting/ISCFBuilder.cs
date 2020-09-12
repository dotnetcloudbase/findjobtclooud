// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Yhd.TencentCloud.SCF.Hosting
{
    public interface ISCFBuilder
    {
        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where scf services are configured.
        /// </summary>
        IServiceCollection Services { get; }

        /// <summary>
        /// Gets the <see cref="IConfigurationRoot"/> where scf configurations
        /// </summary>
        IConfigurationRoot Configuration { get; }
    }
}
