using System.ComponentModel.DataAnnotations;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 输入提示请求参数
    /// </summary>
    public class TipParameter : BaseParameter
    {
        /// <summary>
        /// 查询关键词
        /// </summary>
        [Display(Name = "keywords")]
        public string Keywords { get; set; }

        /// <summary>
        /// POI分类
        /// </summary>
        [Display(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// 坐标
        /// </summary>
        [Display(Name = "location")]
        public string Location { get; set; }

        /// <summary>
        /// 搜索城市
        /// </summary>
        [Display(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// 仅返回指定城市数据
        /// </summary>
        [Display(Name = "citylimit")]
        public bool CityLimit { get; set; }

        /// <summary>
        /// 返回的数据类型
        /// </summary>
        [Display(Name = "datatype")]
        public string DataType { get; set; }

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
