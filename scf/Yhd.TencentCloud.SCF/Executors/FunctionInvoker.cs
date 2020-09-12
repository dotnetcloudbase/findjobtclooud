// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yhd.TencentCloud.SCF.Executors
{
    public class FunctionInvoker : IFunctionInvoker
    {
        public virtual async Task<string> ProcessEvent(string responseBody, SCFContext context)
        {
            return "Event :" + responseBody + "\t Context: " + context.ToString();
        }
    }
}
