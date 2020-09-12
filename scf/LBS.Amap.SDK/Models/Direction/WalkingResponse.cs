using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models.Direction
{
    /// <summary>
    /// 步行路径规划结果
    /// </summary>
    public class WalkingResponse
    {
        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 状态信息
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// 结果总数目
        /// </summary>
        [JsonProperty("count")]
        public string Count { get; set; }

        /// <summary>
        /// 路线信息
        /// </summary>
        [JsonProperty("route")]
        public WalkingRoute Route { get; set; }
    }
}
