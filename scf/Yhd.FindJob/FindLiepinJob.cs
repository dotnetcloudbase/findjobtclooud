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
    /// 猎聘网信息提取
    /// </summary>
    public class FindLiepinJob : FindJobBase
    {
        public FindLiepinJob(IEasyCachingProvider provider) :
            base(RecruitEnum.Liepin, provider)
        {
            RequestPath = "liepin.zhaopin"; 
        }

        public override async Task<DetailsInfo> GetDetailsInfo(string url)
        {
            using (HttpClient http = new HttpClient())
            {
                var htmlString = await http.GetStringAsync(url);
                HtmlParser htmlParser = new HtmlParser();
                var detailsInfo = (await htmlParser.ParseDocumentAsync(htmlString))
                    .QuerySelectorAll(".wrap")
                    .Where(t => t.QuerySelectorAll(".job-qualifications").FirstOrDefault() != null)
                    .Select(t => new DetailsInfo()
                    {
                        Experience = t.QuerySelectorAll(".job-qualifications span")[1].TextContent.Trim(),
                        Education = t.QuerySelectorAll(".job-qualifications span")[0].TextContent.Trim(),
                        CompanyNature = t.QuerySelectorAll(".new-compintro li")[0].TextContent.Trim(),
                        CompanySize = t.QuerySelectorAll(".new-compintro li")[1].TextContent.Trim(),
                        Requirement = t.QuerySelectorAll(".job-item.main-message").FirstOrDefault().TextContent.Replace("职位描述：", "").Trim(),
                        CompanyIntroduction = t.QuerySelectorAll(".job-item.main-message.noborder").FirstOrDefault().TextContent.Trim(),
                    })
                    .FirstOrDefault();
                return detailsInfo;
            }
        }


        public override async  Task<List<JobInfo>> GetJobsFromWeb(string cityCode)
        {
            List<JobInfo> jobInfos = new List<JobInfo>();

            string url = string.Format("http://www.liepin.com/zhaopin/?key={0}&dqs={1}&curPage={2}", SearchKey, cityCode, PageIndex);
            using (HttpClient http = new HttpClient())
            {
                try
                {
                    var htmlString = await http.GetStringAsync(url);
                    HtmlParser htmlParser = new HtmlParser();
                    jobInfos = (await htmlParser.ParseDocumentAsync(htmlString))
                        .QuerySelectorAll("ul.sojob-list li")
                        .Where(t => t.QuerySelectorAll(".job-info h3 a").FirstOrDefault() != null)
                        .Select(t => new JobInfo()
                        {
                            PositionName = t.QuerySelectorAll(".job-info h3 a").FirstOrDefault().TextContent.Trim(),
                            CorporateName = t.QuerySelectorAll(".company-name a").FirstOrDefault().TextContent.Trim(),
                            Salary = t.QuerySelectorAll(".text-warning").FirstOrDefault().TextContent.Trim(),
                            WorkingPlace = t.QuerySelectorAll(".area").FirstOrDefault().TextContent.Trim(),
                            ReleaseDate = t.QuerySelectorAll(".time-info time").FirstOrDefault().TextContent.Trim(),
                            DetailsUrl = t.QuerySelectorAll(".job-info h3 a").FirstOrDefault().Attributes.FirstOrDefault(f => f.Name == "href").Value,
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
