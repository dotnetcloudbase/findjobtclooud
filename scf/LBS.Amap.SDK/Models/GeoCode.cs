using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 地理编码信息
    /// </summary>
    public class GeoCode
    {
        /// <summary>
        /// 结构化地址信息
        /// </summary>
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 地址所在的省份名
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 地址所在的城市名
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        [JsonProperty("citycode")]
        public string CityCode { get; set; }

        /// <summary>
        /// 地址所在的区
        /// </summary>
        [JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// 门牌
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// 区域编码
        /// </summary>
        [JsonProperty("adcode")]
        public string AdCode { get; set; }

        /// <summary>
        /// 坐标点
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// 匹配级别
        /// </summary>
        [JsonProperty("level")]
        public string Level { get; set; }
    }
}
