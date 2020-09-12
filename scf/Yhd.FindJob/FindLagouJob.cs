using AngleSharp.Html.Parser;
using EasyCaching.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Yhd.FindJob
{
    public class FindLagouJob : FindJobBase
    {
        public FindLagouJob(IEasyCachingProvider provider)
            : base(RecruitEnum.Lagou, provider)
        {
            RequestPath = "lagou.zhaopin"; 
        }


        public override async Task<DetailsInfo> GetDetailsInfo(string url)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0");
                var htmlString = await http.GetStringAsync(url);
                HtmlParser htmlParser = new HtmlParser();
                var detailsInfo = (await htmlParser.ParseDocumentAsync(htmlString))
                    .QuerySelectorAll("body")
                    .Select(t => new DetailsInfo()
                    {
                        Experience = t.QuerySelectorAll(".job_request p").FirstOrDefault()?.TextContent.Trim(),
                        //Education = t.QuerySelectorAll(".terminalpage-left .terminal-ul li")[5].TextContent,
                        CompanyNature = t.QuerySelectorAll(".job_company .c_feature li")?.Length <= 0 ? "" : t.QuerySelectorAll(".job_company .c_feature li")[0]?.TextContent.Trim(),
                        CompanySize = t.QuerySelectorAll(".job_company .c_feature li")?.Length <= 2 ? "" : t.QuerySelectorAll(".job_company .c_feature li")[2]?.TextContent.Trim(),
                        Requirement = t.QuerySelectorAll(".job_bt div").FirstOrDefault()?.TextContent.Replace("职位描述：", "").Trim(),
                        //CompanyIntroduction = t.QuerySelectorAll(".tab-cont-box .tab-inner-cont")[1].TextContent,
                    })
                    .FirstOrDefault();
                return detailsInfo;
            }
        }


        public override async Task<List<JobInfo>> GetJobsFromWeb(string cityCode)
        {
            List<JobInfo> jobInfos = new List<JobInfo>();

            StringContent fromurlcontent = new StringContent("first=false&pn=" + PageIndex + "&kd=" + SearchKey);
            fromurlcontent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var url = string.Format("https://www.lagou.com/jobs/positionAjax.json?px=new&city={0}&needAddtionalResult=false&isSchoolJob=0", City);
            using (HttpClient http = new HttpClient())
            {
                try
                {

                    //😄😄😄，拉勾网 后台检测了user-agent、X-Requested-With、Referer还会检测list_是否有参数
                    http.DefaultRequestHeaders.Add("Referer", "https://www.lagou.com/jobs/list_.net");
                    http.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0");
                    http.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                    var responseMsg = await http.PostAsync(new Uri(url), fromurlcontent);
                    var htmlString = await responseMsg.Content.ReadAsStringAsync();
                    var lagouData = JsonConvert.DeserializeObject<LagouData>(htmlString);
                    var resultDatas = lagouData.content.positionResult.result;
                    jobInfos = resultDatas.Select(t => new JobInfo()
                    {
                        PositionName = t.positionName.Trim(),
                        CorporateName = t.companyShortName.Trim(),
                        Salary = t.salary.Trim(),
                        WorkingPlace = t.district + (t.businessZones == null ? "" : t.businessZones.Length <= 0 ? "" : t.businessZones[0]),
                        ReleaseDate = DateTime.Parse(t.createTime).ToString("yyyy-MM-dd"),
                        DetailsUrl = "https://www.lagou.com/jobs/" + t.positionId + ".html",
                        Source = Enum.GetName(typeof(RecruitEnum), this.Recruit)
                    }).ToList();
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
