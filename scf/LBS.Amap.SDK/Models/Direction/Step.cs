using Newtonsoft.Json;

namespace LBS.Amap.SDK.Models.Direction
{
    /// <summary>
    /// 每段步行方案
    /// </summary>
    public class Step
    {
        /// <summary>
        /// 路段步行方案
        /// </summary>
        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        /// <summary>
        /// 道路名称
        /// </summary>
        [JsonProperty("road")]
        public string Road { get; set; }

        /// <summary>
        /// 此路段距离(单位：米)
        /// </summary>
        [JsonProperty("distance")]
        public string Distance { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        /// <summary>
        /// 此路段预计步行时间
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// 此路段坐标点
        /// </summary>
        [JsonProperty("polyline")]
        public string Polyline { get; set; }

        /// <summary>
        /// 步行主要动作
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }

        /// <summary>
        /// 步行辅助动作
        /// </summary>
        [JsonProperty("assistant_action")]
        public string AssistantAction { get; set; }

        /// <summary>
        /// 这段路是否存在特殊的方式
        /// </summary>
        [JsonProperty("walk_type")]
        public string WalkType { get; set; }
    }
}
