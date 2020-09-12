using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBS.Amap.SDK.Models
{
    public class ReGeoResponse
    {
        /// <summary>
        /// 返回结果状态值
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 返回结果数目
        /// </summary>
        [JsonProperty("infocode")]
        public string Infocode { get; set; }

        /// <summary>
        /// 返回状态说明
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

      
        /// <summary>
        /// 地址详细信息
        /// </summary>
        [JsonProperty("regeocode")]
        public ReGeoCode ReGeoCode { get; set; }
    }
}
