using Newtonsoft.Json;
using System.Collections.Generic;

namespace LBS.Amap.SDK.Models
{
    public class TipResponse
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
        /// 返回结果总数目
        /// </summary>
        [JsonProperty("count")]
        public string Count { get; set; }

        /// <summary>
        /// 建议提示列表
        /// </summary>
        [JsonProperty("tips")]
        public ICollection<Tip> Tips { get; set; }
    }
}
