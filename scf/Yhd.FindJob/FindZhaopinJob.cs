using AngleSharp.Html.Parser;
using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Yhd.FindJob
{
    /// <summary>
    /// 智联信息查找岗位
    /// </summary>
    public class FindZhaopinJob : FindJobBase
    {
        public FindZhaopinJob(IEasyCachingProvider provider) :
            base(RecruitEnum.ZLZhaopin, provider)
        {
            RequestPath = "sou.zhaopin"; 
        }

        public override async Task<DetailsInfo> GetDetailsInfo(string url)
        {
            using (HttpClient http = new HttpClient())
            {
                var htmlString = await http.GetStringAsync(url);
                HtmlParser htmlParser = new HtmlParser();
                var detailsInfo = (await htmlParser.ParseDocumentAsync(htmlString))
                    .QuerySelectorAll(".terminalpage")
                    .Where(t => t.QuerySelectorAll(".terminalpage-left .terminal-ul li").FirstOrDefault() != null)
                    .Select(t => new DetailsInfo()
                    {
                        Experience = t.QuerySelectorAll(".terminalpage-left .terminal-ul li")[4].TextContent.Trim(),
                        Education = t.QuerySelectorAll(".terminalpage-left .terminal-ul li")[5].TextContent.Trim(),
                        CompanyNature = t.QuerySelectorAll(".terminalpage-right .terminal-company li")[1].TextContent.Trim(),
                        CompanySize = t.QuerySelectorAll(".terminalpage-right .terminal-company li")[0].TextContent.Trim(),
                        Requirement = t.QuerySelectorAll(".tab-cont-box .tab-inner-cont")[0].TextContent.Replace("职位描述：", "").Trim(),
                        CompanyIntroduction = t.QuerySelectorAll(".tab-cont-box .tab-inner-cont")[1].TextContent.Trim()
                    })
                    .FirstOrDefault();
                return detailsInfo;
            }
        }


        public override async Task<List<JobInfo>> GetJobsFromWeb(string cityCode)
        {
            List<JobInfo> jobInfos = new List<JobInfo>();

            string url = string.Format("http://sou.zhaopin.com/jobs/searchresult.ashx?jl={0}&kw={1}&p={2}", cityCode, SearchKey, PageIndex);
            using (HttpClient http = new HttpClient())
            {
                try
                {
                    var htmlString = await http.GetStringAsync(url);
                    HtmlParser htmlParser = new HtmlParser();
                    jobInfos = (await htmlParser.ParseDocumentAsync(htmlString))
                        .QuerySelectorAll(".newlist_list_content table")
                        .Where(t => t.QuerySelectorAll(".zwmc a").FirstOrDefault() != null)
                        .Select(t => new JobInfo()
                        {
                            PositionName = t.QuerySelectorAll(".zwmc a").FirstOrDefault().TextContent.Trim(),
                            CorporateName = t.QuerySelectorAll(".gsmc a").FirstOrDefault().TextContent.Trim(),
                            Salary = t.QuerySelectorAll(".zwyx").FirstOrDefault().TextContent.Trim(),
                            WorkingPlace = t.QuerySelectorAll(".gzdd").FirstOrDefault().TextContent.Trim(),
                            ReleaseDate = t.QuerySelectorAll(".gxsj span").FirstOrDefault().TextContent.Trim(),
                            DetailsUrl = t.QuerySelectorAll(".zwmc a").FirstOrDefault().Attributes.FirstOrDefault(f => f.Name == "href").Value,
                            Source = Enum.GetName(typeof(RecruitEnum), this.Recruit)
                        })
                        .ToList();

                    return jobInfos;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    return jobInfos;
                }
            }
        }
    }
}
