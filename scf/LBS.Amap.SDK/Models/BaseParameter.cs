using System.ComponentModel.DataAnnotations;

namespace LBS.Amap.SDK.Models
{
    public abstract class BaseParameter
    {
        /// <summary>
        /// 返回数据格式类型
        /// <pre>可选值：JSON，XML</pre>
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; set; } = "JSON";
    }
}
