using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models
{
    public class Cast
    {
        /// <summary>
        /// 日期
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }

        /// <summary>
        /// 星期几
        /// </summary>
        [JsonProperty("week")]
        public string Week { get; set; }

        /// <summary>
        /// 白天天气现象
        /// </summary>
        [JsonProperty("dayweather")]
        public string DayWeather { get; set; }

        /// <summary>
        /// 晚上天气现象
        /// </summary>
        [JsonProperty("nightweather")]
        public string NightWeather { get; set; }

        /// <summary>
        /// 白天温度
        /// </summary>
        [JsonProperty("daytemp")]
        public string DayTemp { get; set; }

        /// <summary>
        /// 晚上温度
        /// </summary>
        [JsonProperty("nighttemp")]
        public string NightTemp { get; set; }

        /// <summary>
        /// 白天风向
        /// </summary>
        [JsonProperty("daywind")]
        public string DayWind { get; set; }

        /// <summary>
        /// 晚上风向
        /// </summary>
        [JsonProperty("nightwind")]
        public string NightWind { get; set; }

        /// <summary>
        /// 白天风力
        /// </summary>
        [JsonProperty("daypower")]
        public string DayPower { get; set; }

        /// <summary>
        /// 晚上风力
        /// </summary>
        [JsonProperty("nightpower")]
        public string NightPower { get; set; }
    }
}
