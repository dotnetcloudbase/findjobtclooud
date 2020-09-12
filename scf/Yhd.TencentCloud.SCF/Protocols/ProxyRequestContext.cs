
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Text;

namespace Yhd.TencentCloud.SCF.Protocols
{
    public class ProxyRequestContext
    {
        public string ServiceId { get; set; }
        public string Path { get; set; }
        public string HttpMethod { get; set; }
        public string RequestId { get; set; }
        public RequestIdentity Identity { get; set; }
        public string SourceIp { get; set; }
        public string Stage { get; set; }

        /**
         * default constructor
         */
        public ProxyRequestContext() { }

 
        public override bool Equals(object obj)
        {
            if (this == obj) 
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;
            ProxyRequestContext that =  obj as ProxyRequestContext;
            return ServiceId.Equals(that.ServiceId) &&
                    Path.Equals(that.Path) &&
                    HttpMethod.Equals(that.HttpMethod) &&
                    RequestId.Equals( that.RequestId) &&
                    Identity.Equals(that.Identity) &&
                    SourceIp.Equals( that.SourceIp) &&
                    Stage.Equals(that.Stage);
        }

        public override int GetHashCode()
        {
            return  ServiceId.GetHashCode() ^ Path.GetHashCode() ^ HttpMethod.GetHashCode() ^ RequestId.GetHashCode() ^ Identity.GetHashCode() ^ SourceIp.GetHashCode() ^ Stage.GetHashCode();

        }

    }

}
