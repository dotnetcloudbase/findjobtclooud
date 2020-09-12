using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// IP定位接口响应
    /// </summary>
    public class IPLocationResponse
    {
        /// <summary>
        /// 返回结果状态值
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 返回状态说明
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// infocode
        /// </summary>
        [JsonProperty("infocode")]
        public string InfoCode { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 城市的adcode编码
        /// </summary>
        [JsonProperty("adcode")]
        public string AdCode { get; set; }

        /// <summary>
        /// 所在城市矩形区域范围
        /// </summary>
        [JsonProperty("rectangle")]
        public string Rectangle { get; set; }
    }
}
