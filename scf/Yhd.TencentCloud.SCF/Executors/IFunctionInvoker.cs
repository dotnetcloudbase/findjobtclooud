// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yhd.TencentCloud.SCF.Executors
{
    public interface IFunctionInvoker
    {
        /// <summary>
        /// process event , simply return event and request id.
        /// </summary>
        /// <param name="responseBody"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<string> ProcessEvent(string responseBody, SCFContext context);

    }
}
