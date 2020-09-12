using AngleSharp.Html.Parser;
using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Yhd.FindJob
{
    public class FindBossJob : FindJobBase
    {
        public FindBossJob(IEasyCachingProvider provider) :
            base(RecruitEnum.BOSS, provider)
        {
            RequestPath = "boss.zhaopin";
        }

        public override async Task<DetailsInfo> GetDetailsInfo(string url)
        {
            using (HttpClient http = new HttpClient())
            {
                var htmlString = await http.GetStringAsync(url);
                HtmlParser htmlParser = new HtmlParser();
                var detailsInfo =(await htmlParser.ParseDocumentAsync(htmlString))
                    .QuerySelectorAll("#main")
                    .Where(t => t.QuerySelectorAll(".job-banner .info-primary p").FirstOrDefault() != null)
                    .Select(t => new DetailsInfo()
                    {
                        Experience = t.QuerySelectorAll(".job-banner .info-primary p").FirstOrDefault().TextContent.Trim(),
                        //Education = t.QuerySelectorAll(".terminalpage-left .terminal-ul li")[5].TextContent,
                        CompanyNature = t.QuerySelectorAll(".job-banner .info-company p").FirstOrDefault().TextContent.Trim(),
                        //CompanySize = t.QuerySelectorAll(".terminalpage-right .terminal-company li")[0].TextContent,
                        Requirement = t.QuerySelectorAll(".detail-content div.text").FirstOrDefault().TextContent.Replace("职位描述：", "").Trim()
                        //CompanyIntroduction = t.QuerySelectorAll(".tab-cont-box .tab-inner-cont")[1].TextContent,
                    })
                    .FirstOrDefault();
                return detailsInfo;
            }
        }

        public override async Task<List<JobInfo>> GetJobsFromWeb(string cityCode)
        {
            List<JobInfo> jobInfos = new List<JobInfo>();
            string url = string.Format("http://www.zhipin.com/c{0}/h_{0}/?query={1}&page={2}", cityCode, SearchKey, PageIndex);
            using (HttpClient http = new HttpClient())
            {
                try
                {
                    var htmlString = await http.GetStringAsync(url);
                    HtmlParser htmlParser = new HtmlParser();
                    jobInfos = (await htmlParser.ParseDocumentAsync(htmlString))
                        .QuerySelectorAll(".job-list ul li")
                        .Where(t => t.QuerySelectorAll(".info-primary h3").FirstOrDefault() != null)
                        .Select(t => new JobInfo()
                        {
                            PositionName = t.QuerySelectorAll(".info-primary h3").FirstOrDefault().TextContent.Trim(),
                            CorporateName = t.QuerySelectorAll(".company-text h3").FirstOrDefault().TextContent.Trim(),
                            Salary = t.QuerySelectorAll(".info-primary h3 .red").FirstOrDefault().TextContent.Trim(),
                            WorkingPlace = t.QuerySelectorAll(".info-primary p").FirstOrDefault().TextContent.Trim(),
                            ReleaseDate = t.QuerySelectorAll(".job-time .time").FirstOrDefault().TextContent.Trim(),
                            DetailsUrl = "http://www.zhipin.com" + t.QuerySelectorAll("a").FirstOrDefault().Attributes.FirstOrDefault(f => f.Name == "href").Value,
                            Source = Enum.GetName(typeof(RecruitEnum), this.Recruit)
                        })
                        .ToList();

                    return jobInfos;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return jobInfos;
                }
            }
        }
    }
}
