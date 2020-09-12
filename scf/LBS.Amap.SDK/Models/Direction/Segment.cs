using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBS.Amap.SDK.Models.Direction
{
    /// <summary>
    /// 换乘路段列表
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// 此路段步行导航信息
        /// </summary>
        [JsonProperty("walking")]
        public Path Walking { get; set; }

        /// <summary>
        /// 此路段公交导航信息
        /// </summary>
        [JsonProperty("bus")]
        public Bus Bus { get; set; }

        /// <summary>
        /// 地铁入口
        /// </summary>
        [JsonProperty("entrance")]
        public Gateway Entrance { get; set; }

        /// <summary>
        /// 地铁出口
        /// </summary>
        [JsonProperty("exit")]
        public Gateway Exit { get; set; }
    }
}
