using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 提示信息
    /// </summary>
    public class Tip
    {
        /// <summary>
        /// 提示信息
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// tip名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 所属区域
        /// </summary>
        [JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        /// 区域编码
        /// </summary>
        [JsonProperty("adcode")]
        public string AdCode { get; set; }

        /// <summary>
        /// tip中心点坐标
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
