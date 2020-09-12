using Newtonsoft.Json;
using System.Collections.Generic;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 行政区信息
    /// </summary>
    public class District
    {
        /// <summary>
        /// 城市编码
        /// </summary>
        [JsonProperty("citycode")]
        public string CityCode { get; set; }

        /// <summary>
        /// 区域编码
        /// </summary>
        [JsonProperty("adcode")]
        public string AdCode { get; set; }

        /// <summary>
        /// 行政区名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 行政区边界坐标点
        /// </summary>
        [JsonProperty("polyline")]
        public string PolyLine { get; set; }

        /// <summary>
        /// 区域中心点
        /// </summary>
        [JsonProperty("center")]
        public string Center { get; set; }

        /// <summary>
        /// 行政区划级别
        /// </summary>
        /// <remarks>
        /// <para>country:国家</para>
        /// <para>province:省份（直辖市会在province和city显示）</para>
        /// <para>city:市（直辖市会在province和city显示）</para>
        /// <para>district:区县</para>
        /// <para>street:街道</para>
        /// </remarks>
        [JsonProperty("level")]
        public string Level { get; set; }

        /// <summary>
        /// 下级行政区列表
        /// </summary>
        [JsonProperty("districts")]
        public List<District> Districts { get; set; }
    }
}
