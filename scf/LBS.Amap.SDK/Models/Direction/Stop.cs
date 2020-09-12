using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models.Direction
{
    /// <summary>
    /// 站点信息
    /// </summary>
    public class Stop
    {
        /// <summary>
        /// 站点名字
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 站点id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 站点经纬度
        /// </summary>
        [JsonProperty("id")]
        public string Location { get; set; }
    }
}
