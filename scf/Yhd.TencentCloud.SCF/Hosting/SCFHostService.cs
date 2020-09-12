
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yhd.TencentCloud.SCF.Hosting
{
    public class SCFHostService : IHostedService
    {
        private readonly ILogger<SCFHostService> _logger;
        private readonly ISCFHost _scfHost;

        public SCFHostService(ISCFHost jobhost, ILogger<SCFHostService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _scfHost = jobhost;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting SCFHost");
            return _scfHost.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping SCFHost");
            return _scfHost.StopAsync();
        }
    }
}
