using System.ComponentModel.DataAnnotations;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 静态地图请求参数
    /// </summary>
    public class StaticMapParameter : BaseParameter
    {
        /// <summary>
        /// 地图中心点
        /// </summary>
        [Display(Name = "location")]
        public string Location { get; set; }

        /// <summary>
        /// 地图级别
        /// </summary>
        [Display(Name = "zoom")]
        public int? Zoom { get; set; }

        /// <summary>
        /// 地图大小
        /// </summary>
        [Display(Name = "size")]
        public string Size { get; set; }

        /// <summary>
        /// 清晰度
        /// </summary>
        [Display(Name = "scale")]
        public int Scale { get; set; } = 1;

        /// <summary>
        /// 标注
        /// </summary>
        [Display(Name = "markers")]
        public string Markers { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        [Display(Name = "labels")]
        public string Labels { get; set; }

        /// <summary>
        /// 折线
        /// </summary>
        [Display(Name = "paths")]
        public string Paths { get; set; }

        /// <summary>
        /// 交通路况标识
        /// </summary>
        [Display(Name = "traffic")]
        public int Traffic { get; set; } = 0;

        /// <summary>
        /// 数字签名
        /// </summary>
        [Display(Name = "sig")]
        public string Sig { get; set; }
    }
}
