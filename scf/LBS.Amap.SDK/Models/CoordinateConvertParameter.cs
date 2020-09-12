using System.ComponentModel.DataAnnotations;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 坐标转换请求参数
    /// </summary>
    public class CoordinateConvertParameter : BaseParameter
    {
        /// <summary>
        /// 坐标点
        /// </summary>
        [Display(Name = "locations")]
        public string Locations { get; set; }

        /// <summary>
        /// 原坐标系
        /// </summary>
        [Display(Name = "coordsys")]
        public string Coordsys { get; set; }

        /// <summary>
        /// 数字签名
        /// </summary>
        [Display(Name = "sig")]
        public string Sig { get; set; }
    }
}
