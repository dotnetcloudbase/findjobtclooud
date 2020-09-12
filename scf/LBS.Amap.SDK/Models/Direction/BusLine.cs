using Newtonsoft.Json;
using System.Collections.Generic;

namespace LBS.Amap.SDK.Models.Direction
{
    public class BusLine
    {
        /// <summary>
        /// 起乘站
        /// </summary>
        [JsonProperty("departure_stop")]
        public Stop DepartureStop { get; set; }

        /// <summary>
        /// 到达站
        /// </summary>
        [JsonProperty("arrival_stop")]
        public Stop ArrivalStop { get; set; }

        /// <summary>
        /// 公交路线名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 公交路线id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 公交类型
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 公交行驶距离
        /// </summary>
        [JsonProperty("distance")]
        public string Distance { get; set; }

        /// <summary>
        /// 此路段坐标集
        /// </summary>
        [JsonProperty("polyline")]
        public string PolyLine { get; set; }

        /// <summary>
        /// 首班车时间
        /// </summary>
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// 末班车时间
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// 此段途经公交站数
        /// </summary>
        [JsonProperty("via_num")]
        public string ViaNum { get; set; }

        /// <summary>
        /// 此段途经公交站点列表
        /// </summary>
        [JsonProperty("via_stops")]
        public ICollection<Stop> ViaStops { get; set; }
    }
}
