using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yhd.FindJob
{
    public interface IFindJob
    {
        RecruitEnum Recruit { get; } 

        string City { get; set; }

        string SearchKey { get; set; }

        int PageIndex { get; set; }

        Task<List<JobInfo>>  GetJobsAsync(int? minutes = null);

        Task<DetailsInfo> GetDetailsInfo(string url);

    }
}
