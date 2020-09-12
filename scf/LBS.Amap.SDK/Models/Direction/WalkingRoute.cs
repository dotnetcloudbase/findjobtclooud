using Newtonsoft.Json;
using System.Collections.Generic;

namespace LBS.Amap.SDK.Models.Direction
{
    /// <summary>
    /// 步行路线信息
    /// </summary>
    public class WalkingRoute
    {
        /// <summary>
        /// 起点坐标
        /// </summary>
        [JsonProperty("origin")]
        public string Origin { get; set; }

        /// <summary>
        /// 终点坐标
        /// </summary>
        [JsonProperty("destination")]
        public string Destination { get; set; }

        /// <summary>
        /// 步行方案
        /// </summary>
        [JsonProperty("paths")]
        public List<Path> Paths { get; set; }
    }
}
