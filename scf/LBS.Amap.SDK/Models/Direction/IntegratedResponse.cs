using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBS.Amap.SDK.Models.Direction
{
    /// <summary>
    /// 公交规划响应结果
    /// </summary>
    public class IntegratedResponse
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
        /// 公交换乘方案数目
        /// </summary>
        [JsonProperty("count")]
        public string Count { get; set; }
    }
}
