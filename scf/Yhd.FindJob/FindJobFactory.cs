using EasyCaching.Core;
using System;

namespace Yhd.FindJob
{
    public interface IFindJobFactory
    {
        IFindJob Get(string source);
    }

    public class FindJobFactory : IFindJobFactory
    {
        private IEasyCachingProvider _provider;

        public FindJobFactory(IEasyCachingProvider provider)
        {
            _provider = provider;
        }

        public IFindJob Get(string source)
        {
            IFindJob findJob = null;
            RecruitEnum enumRecruit = (RecruitEnum)Enum.Parse(typeof(RecruitEnum), source);
            switch(enumRecruit)
            {
                case RecruitEnum.BOSS:
                    findJob = new FindBossJob(_provider);
                    break;
                case RecruitEnum.Lagou:
                    findJob = new FindLagouJob(_provider);
                    break;
                case RecruitEnum.Liepin:
                    findJob = new FindLiepinJob(_provider);
                    break;
                case RecruitEnum.QC51:
                    findJob = new FindQCJob(_provider);
                    break;
                case RecruitEnum.ZLZhaopin:
                    findJob = new FindZhaopinJob(_provider);
                    break;                
            }
            return findJob;
 
        }
    }
}
