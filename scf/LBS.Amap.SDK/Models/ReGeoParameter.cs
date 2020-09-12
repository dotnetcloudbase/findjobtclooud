using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LBS.Amap.SDK.Models
{
    public  class ReGeoParameter : BaseParameter
    {
        /// <summary>
        /// 经纬度坐标;最多支持20个坐标点;多个点之间用"|"分割。
        /// </summary>
        [Display(Name = "location")]
        public string Location { get; set; }

        /// <summary>
        /// batch=true为批量查询。batch=false为单点查询
        /// </summary>
        [Display(Name = "batch")]
        public bool Batch { get; set; }

        /// <summary>
        /// 查询POI的半径范围。取值范围：0~3000,单位：米
        /// </summary>
        [Display(Name = "radius")]
        public int Radius { get; set; }


        /// <summary>
        /// 返回结果控制
        /// </summary>
        [Display(Name = "extensions")]
        public string Extensions { get; set; }

        /// <summary>
        /// 可选值：1，当roadlevel=1时，过滤非主干道路，仅输出主干道路数据
        /// </summary>
        [Display(Name = "roadlevel")]
        public int RoadLevel { get; set; }

        /// <summary>
        /// 支持传入POI TYPECODE及名称；支持传入多个POI类型，多值间用“|”分隔
        /// </summary>
        [Display(Name = "poitype")]
        public string Poitype { get; set; }
 
    }
}
