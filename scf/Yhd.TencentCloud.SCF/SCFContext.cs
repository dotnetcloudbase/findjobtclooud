
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

namespace Yhd.TencentCloud.SCF
{
    public class SCFContext 
    {
        public string RequestId { get; private set; }

        public string Handler { get; private set; }

        public int TimeLimitInMs { get; private set; }

        public int MemoryLimitInMb { get; private set; }


        public SCFContext(string requestId, string handler, int timeLimitInMs, int memoryLimitInMb)
        {
            RequestId = requestId;
            Handler = handler;
            TimeLimitInMs = timeLimitInMs;
            MemoryLimitInMb = memoryLimitInMb;
        }


        public override string ToString()
        {

            return "{" +
                    "RequestId='" + RequestId + '\'' +
                    "TimeLimitInMs" + TimeLimitInMs + '\'' +
                    "MemoryLimitInMb" + MemoryLimitInMb + '\'' +
                    '}';
        }
    }
}