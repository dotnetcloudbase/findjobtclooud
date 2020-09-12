using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBS.Amap.SDK.Models
{
    public class ReGeoCode
    {

        /// <summary>
        /// 结构化地址信息
        /// </summary>
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// 地址信息
        /// </summary>
        [JsonProperty("addressComponent")]
        public AddressComponent AddressComponent { get; set; }
    }
}
