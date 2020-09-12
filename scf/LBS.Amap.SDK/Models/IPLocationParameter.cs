using System.ComponentModel.DataAnnotations;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// IP定位参数
    /// </summary>
    public class IPLocationParameter : BaseParameter
    {
        /// <summary>
        /// ip地址
        /// <pre>需要搜索的IP地址（仅支持国内）若不填写IP，则取客户http之中的请求来进行定位</pre>
        /// </summary>
        [Display(Name = "ip")]
        public string IP { get; set; }

        /// <summary>
        /// 签名
        /// <pre>选择数字签名认证的付费用户必填</pre>
        /// </summary>
        [Display(Name = "sig")]
        public string Sig { get; set; }
    }
}
