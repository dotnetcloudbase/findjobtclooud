using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yhd.FindJob
{
    public abstract class FindJobBase : IFindJob
    {
        public string RequestPath { get; set; }

        public RecruitEnum Recruit { get; }

        public string City { get; set; }

        public string SearchKey { get; set; }

        public int PageIndex { get; set; }

        private readonly IEasyCachingProvider _provider;


        public FindJobBase(RecruitEnum recruit, IEasyCachingProvider provider)
        {
            Recruit = recruit;
            _provider = provider ;
        }

        protected string CacheKey
        {
            get
            {
                var key = $"{RequestPath}?city={City}&key={SearchKey}&index={PageIndex}";
                return key;
            }
        }

        public async Task<List<JobInfo>> GetJobsAsync(int? minutes = null)
        {
            var cache = GetCacheObject();

            if (cache != null && cache.Count > 0)
                return cache;

            var cityCode = CodesData.GetCityCode(Recruit, this.City );

            var data = await GetJobsFromWeb(cityCode);
            
            var time =  minutes ?? 10 ;//缓存10分钟

            await _provider.SetAsync(CacheKey, data, TimeSpan.FromMinutes(time));
            return data;
        }


        public abstract Task<List<JobInfo>> GetJobsFromWeb(string cityCode);


        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="city"></param>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<JobInfo> GetCacheObject(int? minutes = null)
        {          
            var cacheValue = _provider.Get<List<JobInfo>>(CacheKey);
            return cacheValue.Value;           
        }

        /// <summary>
        /// 获取岗位详细信息
        /// </summary>
        /// <param name="url">岗位详细信息的URL</param>
        /// <returns></returns>
        public abstract Task<DetailsInfo> GetDetailsInfo(string url);
    }
}
