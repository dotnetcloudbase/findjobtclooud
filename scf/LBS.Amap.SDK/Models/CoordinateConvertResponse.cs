using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models
{
    public class CoordinateConvertResponse
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 返回的状态信息
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// 转换之后的坐标。若有多个坐标，则用 “;”进行区分和间隔
        /// </summary>
        [JsonProperty("locations")]
        public string Locations { get; set; }
    }
}
