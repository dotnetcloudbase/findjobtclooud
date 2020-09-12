using Newtonsoft.Json;
using System.Collections.Generic;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 地理/逆地理编码查询响应
    /// </summary>
    public class GeoResponse
    {
        /// <summary>
        /// 返回结果状态值
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 返回结果数目
        /// </summary>
        [JsonProperty("count")]
        public string Count { get; set; }

        /// <summary>
        /// 返回状态说明
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// 地理编码信息列表
        /// </summary>
        [JsonProperty("geocodes")]
        public List<GeoCode> GeoCodes { get; set; }
    }
}
