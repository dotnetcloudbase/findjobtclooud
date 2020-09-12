using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yhd.FindJob
{
    public interface IJobsManager
    {
        /// <summary>
        /// 获取岗位详细信息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<DetailsInfo> GetDetailsInfo(string source, string url);

        /// <summary>
        /// 获取查询岗位数据的简要信息
        /// </summary>
        /// <param name="sources">来源列表</param>
        /// <param name="city"></param>
        /// <param name="searchKey"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        Task<List<JobInfo>> GetJobsAsync(List<string> sources, string city, string searchKey, int pageIndex);

        Task<List<JobInfo>> GetJobsAsync(string source,string city, string searchKey, int pageIndex);
    }
}