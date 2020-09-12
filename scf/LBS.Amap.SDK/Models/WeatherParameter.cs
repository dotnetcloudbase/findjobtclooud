using System.ComponentModel.DataAnnotations;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 天气数据获取参数
    /// </summary>
    public class WeatherParameter : BaseParameter
    {
        /// <summary>
        /// 城市编码
        /// </summary>
        [Display(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// 气象类型
        /// </summary>
        [Display(Name = "extensions")]
        public string Extensions { get; set; }
    }
}
