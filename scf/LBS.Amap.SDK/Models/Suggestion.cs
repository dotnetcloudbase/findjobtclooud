using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 建议结果列表
    /// </summary>
    public class Suggestion
    {
        /// <summary>
        /// 建议关键字列表
        /// </summary>
        [JsonProperty("keywords")]
        public string KeyWords { get; set; }

        /// <summary>
        /// 建议城市列表
        /// </summary>
        [JsonProperty("cities")]
        public string Citys { get; set; }
    }
}
