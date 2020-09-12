using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBS.Amap.SDK.Models
{
    public class AddressComponent
    {
        /// <summary>
        /// 国家
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 地址所在的省份名
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 地址所在的城市名
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        [JsonProperty("citycode")]
        public string CityCode { get; set; }

        /// <summary>
        /// 地址所在的区
        /// </summary>
        [JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        ///  Adcode
        /// </summary>
        [JsonProperty("adcode")]
        public string Adcode { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        [JsonProperty("township")]
        public string Township { get; set; }

        /// <summary>
        /// 街道编码
        /// </summary>
        [JsonProperty("towncode")]
        public string Towncode { get; set; }

      
    }
}
