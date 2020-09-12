using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 实况天气数据
    /// </summary>
    public class Live
    {
        /// <summary>
        /// 省份
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 区域编码
        /// </summary>
        [JsonProperty("adcode")]
        public string AdCode { get; set; }

        /// <summary>
        /// 天气现象
        /// </summary>
        [JsonProperty("weather")]
        public string Weather { get; set; }

        /// <summary>
        /// 实时气温，单位：摄氏度
        /// </summary>
        [JsonProperty("temperature")]
        public string Temperature { get; set; }

        /// <summary>
        /// 风向描述
        /// </summary>
        [JsonProperty("winddirection")]
        public string WindDirection { get; set; }

        /// <summary>
        /// 风力级别，单位：级
        /// </summary>
        [JsonProperty("windpower")]
        public string WindPower { get; set; }

        /// <summary>
        /// 空气湿度
        /// </summary>
        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        /// <summary>
        /// 数据发布的时间
        /// </summary>
        [JsonProperty("reporttime")]
        public string ReportTime { get; set; }
    }
}
