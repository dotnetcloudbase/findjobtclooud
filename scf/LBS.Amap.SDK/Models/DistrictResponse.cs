using Newtonsoft.Json;
using System.Collections.Generic;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 行政区域查询响应
    /// </summary>
    public class DistrictResponse
    {
        /// <summary>
        /// 结果状态值
        /// </summary>
        /// <remarks>值为0或1，0表示失败；1表示成功</remarks>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 状态说明
        /// </summary>
        /// <remarks>返回状态说明，status为0时，info返回错误原因，否则返回“OK”</remarks>
        [JsonProperty("info")]
        public string Info { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("infocode")]
        public string InfoCode { get; set; }

        /// <summary>
        /// 建议结果列表
        /// </summary>
        [JsonProperty("suggestion")]
        public Suggestion Suggestion { get; set; }

        /// <summary>
        /// 行政区列表
        /// </summary>
        [JsonProperty("districts")]
        public List<District> Districts { get; set; }
    }
}
