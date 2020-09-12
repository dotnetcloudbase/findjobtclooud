using System.ComponentModel.DataAnnotations;

namespace LBS.Amap.SDK.Models.Direction
{
    /// <summary>
    /// 公交路径规划参数
    /// </summary>
    public class IntegratedParameter : BaseParameter
    {
        /// <summary>
        /// 出发点
        /// </summary>
        [Display(Name = "origin")]
        public string Origin { get; set; }

        /// <summary>
        /// 目的地
        /// </summary>
        [Display(Name = "destination")]
        public string Destination { get; set; }

        /// <summary>
        /// 城市/跨城规划时的起点城市
        /// <pre>可选值：城市名称/citycode</pre>
        /// </summary>
        [Display(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// 跨城公交规划时的终点城市
        /// </summary>
        [Display(Name = "cityd")]
        public string Cityd { get; set; }

        /// <summary>
        /// 返回结果详略
        /// </summary>
        [Display(Name = "extensions")]
        public string Extensions { get; set; }

        /// <summary>
        /// 公交换乘策略
        /// </summary>
        [Display(Name = "strategy")]
        public string Strategy { get; set; }

        /// <summary>
        /// 是否计算夜班车
        /// </summary>
        [Display(Name = "nightflag")]
        public string NightFlag { get; set; }

        /// <summary>
        /// 出发日期
        /// </summary>
        [Display(Name = "date")]
        public string Date { get; set; }

        /// <summary>
        /// 出发时间
        /// </summary>
        [Display(Name = "time")]
        public string Time { get; set; }

        /// <summary>
        /// 数字签名
        /// </summary>
        [Display(Name = "sig")]
        public string Sig { get; set; }

        /// <summary>
        /// 回调函数
        /// </summary>
        [Display(Name = "callback")]
        public string Callback { get; set; }
    }
}
