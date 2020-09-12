using Newtonsoft.Json;
using System.Collections.Generic;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 预报天气信息数据
    /// </summary>
    public class ForeCast
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        [JsonProperty("adcode")]
        public string AdCode { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 预报发布时间
        /// </summary>
        [JsonProperty("reporttime")]
        public string ReportTime { get; set; }

        /// <summary>
        /// 预报数据集合，元素cast,按顺序为当天、第二天、第三天的预报数据
        /// </summary>
        [JsonProperty("casts")]
        public ICollection<Cast> Casts { get; set; }
    }
}
