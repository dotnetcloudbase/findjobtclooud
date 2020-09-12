using System.ComponentModel.DataAnnotations;

namespace LBS.Amap.SDK.Models
{
    /// <summary>
    /// 行政区域请求参数
    /// </summary>
    public class DistrictParameter : BaseParameter
    {
        /// <summary>
        /// 查询关键字
        /// </summary>
        [Display(Name = "keywords")]
        public string Keywords { get; set; }

        /// <summary>
        /// 子级行政区
        /// </summary>
        /// <value>
        /// <para>0：不返回下级行政区</para>
        /// <para>1：返回下一级行政区</para>
        /// <para>2：返回下两级行政区</para>
        /// <para>3：返回下三级行政区</para>
        /// </value>
        [Display(Name = "subdistrict")]
        public int SubDistrict { get; set; } = 1;

        /// <summary>
        /// 需要第几页数据
        /// </summary>
        [Display(Name = "page")]
        public int Page { get; set; } = 1;

        /// <summary>
        /// 最外层返回数据个数
        /// </summary>
        [Display(Name = "offset")]
        public string Offset { get; set; }

        /// <summary>
        /// 返回结果控制
        /// </summary>
        [Display(Name = "extensions")]
        public string Extensions { get; set; } = "base";

        /// <summary>
        /// 按照adcode过滤
        /// </summary>
        [Display(Name = "filter")]
        public string Filter { get; set; }

        /// <summary>
        /// 回调函数
        /// </summary>
        [Display(Name = "callback")]
        public string Callback { get; set; }
    }
}
