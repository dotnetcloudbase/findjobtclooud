
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yhd.TencentCloud.SCF.Protocols
{

    /// <summary>
    /// Class that represents an APIGatewayProxyResponseEvent object
    /// </summary>
    public class APIGatewayProxyResponseEvent {

        public int StatusCode { get; set; }

        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
        public bool IsBase64Encoded { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
        /**
         * default constructor
         */
        public APIGatewayProxyResponseEvent() {
            Headers = new Dictionary<string, string>();
            StatusCode = 200;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
  
    }
}
