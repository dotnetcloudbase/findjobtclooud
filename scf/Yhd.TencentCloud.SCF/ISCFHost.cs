
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yhd.TencentCloud.SCF
{
    public interface ISCFHost
    {
        Task StartAsync(CancellationToken cancellationToken);

        Task StopAsync();
    }
}
