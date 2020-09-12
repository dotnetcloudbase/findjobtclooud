
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yhd.TencentCloud.SCF.Protocols
{
    public class APIGatewayProxyRequestEvent
    {
        public ProxyRequestContext RequestContext { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
        public Dictionary<string, string> PathParameters { get; set; }
        public Dictionary<string, string> QueryStringParameters { get; set; }
        public Dictionary<string, string> HeaderParameters { get; set; }
        public Dictionary<string, string> StageVariables { get; set; }
        public string Path { get; set; }
        public Dictionary<string, string> QueryString { get; set; }
        public string HttpMethod { get; set; }


        /**
         * default constructor
         */
        public APIGatewayProxyRequestEvent()
        {
            HeaderParameters = new Dictionary<string, string>();
            Headers = new Dictionary<string, string>();
            PathParameters = new Dictionary<string, string>();
            QueryString = new Dictionary<string, string>();
            QueryStringParameters = new Dictionary<string, string>();
            StageVariables = new Dictionary<string, string>();
        }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);            
        }
    }
}
