
// Copyright (c) Yhd Tech. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.using Microsoft.Extensions.Configuration;


using System;
using System.Collections.Generic;
using System.Text;

namespace Yhd.TencentCloud.SCF.Protocols
{
    public class RequestIdentity
    {

        public RequestIdentity() { }

        public string SecretId { get; set; }

  
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || GetType() != obj.GetType()) 
                return false;
            RequestIdentity that = obj as RequestIdentity;
            return SecretId.Equals(that.SecretId);
        }

        public override int GetHashCode()
        {
            return SecretId.GetHashCode();
        }
  
    }
}
