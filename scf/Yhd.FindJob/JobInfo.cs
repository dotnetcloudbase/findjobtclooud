using System;

namespace Yhd.FindJob
{
    /// <summary>
    /// 简要信息
    /// </summary>
    [Serializable]
    public class JobInfo
    {
        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CorporateName { get; set; }

        /// <summary>
        /// 薪水
        /// </summary>
        public string Salary { get; set; }

        /// <summary>
        /// 工作地点
        /// </summary>
        public string WorkingPlace { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// 详情url
        /// </summary>
        public string DetailsUrl { get; set; }

        /// <summary>
        /// 岗位来源 
        /// </summary>
        public string Source { get; set; }
    }
}
