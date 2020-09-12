using System;
using System.Collections.Generic;
using System.Text;

namespace Yhd.FindJob
{
    /// <summary>
    /// 详情
    /// </summary>
    [Serializable]
    public class DetailsInfo
    {
        /// <summary>
        /// 学历要求
        /// </summary>
        public string Education { get; set; }

        /// <summary>
        /// 工作经验
        /// </summary>
        public string Experience { get; set; }

        /// <summary>
        /// 公司性质
        /// </summary>
        public string CompanyNature { get; set; }

        /// <summary>
        /// 公司规模
        /// </summary>
        public string CompanySize { get; set; }

        /// <summary>
        /// 详细要求 【职位描述】
        /// </summary>
        public string Requirement { get; set; }

        /// <summary>
        /// 公司介绍
        /// </summary>
        public string CompanyIntroduction { get; set; }
    }
}
