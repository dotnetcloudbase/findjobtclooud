using System.ComponentModel.DataAnnotations;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 地理编码参数
    /// </summary>
    public class GeoParameter : BaseParameter
    {
        /// <summary>
        /// 结构化地址信息
        /// <pre>规则遵循：国家、省份、城市、区县、城镇、乡村、街道、门牌号码、屋邨、大厦</pre>
        /// <pre>如果需要解析多个地址的话，请用"|"进行间隔，并且将 batch 参数设置为 true，最多支持 10 个地址进进行"|"分割形式的请求</pre>
        /// <exapmle>北京市朝阳区阜通东大街6号</exapmle>
        /// </summary>
        [Display(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// 指定查询的城市
        /// <pre>可选输入内容包括：指定城市的中文（如北京）、指定城市的中文全拼（beijing）、citycode（010）、adcode（110000），不支持县级市</pre>
        /// <pre>当指定城市查询内容为空时，会进行全国范围内的地址转换检索</pre>
        /// </summary>
        [Display(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// 批量查询控制
        /// </summary>
        [Display(Name = "batch")]
        public bool Batch { get; set; } = false;

        /// <summary>
        /// 数字签名
        /// <see cref="https://lbs.amap.com/faq/quota-key/key/41169"/>
        /// </summary>
        [Display(Name = "sig")]
        public string Sig { get; set; }

        /// <summary>
        /// 回调函数
        /// <pre>callback 值是用户定义的函数名称，此参数只在 output 参数设置为 JSON 时有效</pre>
        /// </summary>
        [Display(Name = "callback")]
        public string Callback { get; set; }
    }
}
