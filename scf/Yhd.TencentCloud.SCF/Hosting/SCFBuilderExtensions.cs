
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Yhd.TencentCloud.SCF.Hosting;

namespace Yhd.TencentCloud.SCF
{
    public static class SCFBuilderExtensions
    {
        /// <summary>
        /// Adds builtin bindings 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ISCFBuilder AddBuiltInBindings(this ISCFBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            } 

            return builder;
        }
    }
}
