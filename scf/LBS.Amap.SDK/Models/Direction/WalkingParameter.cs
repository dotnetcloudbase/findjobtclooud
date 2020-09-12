using System.ComponentModel.DataAnnotations;

namespace LBS.Amap.SDK.Models.Direction
{
    /// <summary>
    /// 路径规划参数
    /// </summary>
    public class WalkingParameter : BaseParameter
    {
        /// <summary>
        /// 出发点经纬度
        /// </summary>
        [Display(Name = "origin")]
        public string Origin { get; set; }

        /// <summary>
        /// 目的地经纬度
        /// </summary>
        [Display(Name = "destination")]
        public string Destination { get; set; }

        /// <summary>
        /// 数字签名
        /// </summary>
        [Display(Name = "sig")]
        public string Sig { get; set; }

        /// <summary>
        /// 回调函数
        /// </summary>
        [Display(Name = "callback")]
        public string CallBack { get; set; }
    }
}
