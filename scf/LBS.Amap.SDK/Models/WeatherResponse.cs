using Newtonsoft.Json;
using System.Collections.Generic;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 天气数据响应
    /// </summary>
    public class WeatherResponse
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 返回结果总数目
        /// </summary>
        [JsonProperty("count")]
        public string Count { get; set; }

        /// <summary>
        /// 返回的状态信息
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// 返回状态说明
        /// </summary>
        [JsonProperty("infocode")]
        public string InfoCode { get; set; }

        /// <summary>
        /// 实况天气数据信息集合
        /// </summary>
        [JsonProperty("lives")]
        public ICollection<Live> Lives { get; set; }

        /// <summary>
        /// 预报天气信息数据
        /// </summary>
        [JsonProperty("forecasts")]
        public ICollection<ForeCast> ForeCasts { get; set; }
    }
}
