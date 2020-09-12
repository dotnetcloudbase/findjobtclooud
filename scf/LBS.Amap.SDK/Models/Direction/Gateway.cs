using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models.Direction
{
    /// <summary>
    /// 出入口
    /// </summary>
    public class Gateway
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
