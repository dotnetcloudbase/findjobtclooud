using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Yhd.FindJob
{
    public class JobsManager : IJobsManager
    {
        private IFindJobFactory findjobFactory;

        public JobsManager(IFindJobFactory factory)
        {
            findjobFactory = factory;
        }

        public async Task<List<JobInfo>> GetJobsAsync(List<string> sources, string city, string searchKey, int pageIndex)
        {
            var jobInfos = new List<JobInfo>();

            foreach (var x in sources)
            {
                List<JobInfo> jobList = await GetJobsAsync(x, city, searchKey, pageIndex);
                jobInfos.AddRange(jobList);
            }
            return jobInfos;

            //return await Task.Run(() =>
            //{
            //    var jobInfos = new List<JobInfo>();
            //    Parallel.ForEach(sources, (async x =>
            //    {
            //        List<JobInfo> jobList = await GetJobsAsync(x, city, searchKey, pageIndex);
            //        jobInfos.AddRange(jobList);
            //        //jobList.ForEach(y => jobInfos.Add(y));
            //    }));
            //    return jobInfos;
            //});
        }

        public async Task<List<JobInfo>> GetJobsAsync(string source,string city, string searchKey, int pageIndex)
        {
            IFindJob findJob = findjobFactory.Get(source);
            findJob.City = city;
            findJob.SearchKey = searchKey;
            findJob.PageIndex = pageIndex;
            var jobList = await findJob.GetJobsAsync();
            return jobList;
        }

        public async Task<DetailsInfo> GetDetailsInfo(string source, string url)
        {
            IFindJob findJob = findjobFactory.Get(source);
            return await findJob.GetDetailsInfo(url);
        }
    }
}
