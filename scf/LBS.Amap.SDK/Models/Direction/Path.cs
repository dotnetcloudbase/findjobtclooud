using LBS.Amap.SDK.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LBS.Amap.SDK.Models.Direction
{
    /// <summary>
    /// 步行方案
    /// </summary>
    public class Path
    {
        /// <summary>
        /// 起点和终点的步行距离(单位：米)
        /// </summary>
        [JsonProperty("distance")]
        public string Distance { get; set; }

        /// <summary>
        /// 步行时间预计(单位：秒)
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// 步行结果列表
        /// </summary>
        [JsonProperty("steps")]
        public List<Step> Steps { get; set; }
    }
}
