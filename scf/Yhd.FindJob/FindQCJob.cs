using AngleSharp.Html.Parser;
using EasyCaching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yhd.FindJob
{
    public class FindQCJob : FindJobBase
    {
        public FindQCJob(IEasyCachingProvider provider) :
            base(RecruitEnum.QC51, provider)
        {
            RequestPath = "51job.zhaopin"; 
        }


        public override async Task<DetailsInfo> GetDetailsInfo(string url)
        {
            using (HttpClient http = new HttpClient())
            {
                var htmlBytes = await http.GetByteArrayAsync(url);
                //【注意】使用GBK需要 Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//注册编码提供程序
                var htmlString = Encoding.GetEncoding("GBK").GetString(htmlBytes);
                HtmlParser htmlParser = new HtmlParser();
                var detailsInfo = (await htmlParser.ParseDocumentAsync(htmlString))
                    .QuerySelectorAll(".tCompanyPage")
                    .Where(t => t.QuerySelectorAll(".tBorderTop_box .t1 span").FirstOrDefault() != null)
                    .Select(t => new DetailsInfo()
                    {
                        //Experience = t.QuerySelectorAll(".terminalpage-left .terminal-ul li")[4].TextContent,
                        Education = t.QuerySelectorAll(".tBorderTop_box .t1 span")[0].TextContent.Trim(),
                        CompanyNature = t.QuerySelectorAll(".msg.ltype")[0].TextContent.Trim(),
                        //CompanySize = t.QuerySelectorAll(".terminalpage-right .terminal-company li")[0].TextContent,
                        Requirement = t.QuerySelectorAll(".bmsg.job_msg.inbox")[0].TextContent.Replace("职位描述：", "").Trim(),
                        CompanyIntroduction = t.QuerySelectorAll(".tmsg.inbox")[0].TextContent.Trim()
                    })
                    .FirstOrDefault();
                return detailsInfo;
            }
        }

        public override async Task<List<JobInfo>> GetJobsFromWeb(string cityCode)
        {
            List<JobInfo> jobInfos = new List<JobInfo>();

            string url = string.Format("http://search.51job.com/jobsearch/search_result.php?jobarea={0}&keyword={1}&curr_page={2}", cityCode, SearchKey, PageIndex);
            using (HttpClient http = new HttpClient())
            {
                try
                {
                    var htmlBytes = await http.GetByteArrayAsync(url);
                    //【注意】使用GBK需要 Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//注册编码提供程序
                    var htmlString = Encoding.GetEncoding("GBK").GetString(htmlBytes);
                    HtmlParser htmlParser = new HtmlParser();
                    jobInfos = (await htmlParser.ParseDocumentAsync(htmlString))
                        .QuerySelectorAll(".dw_table div.el")
                        .Where(t => t.QuerySelectorAll(".t1 span a").FirstOrDefault() != null)
                        .Select(t => new JobInfo()
                        {
                            PositionName = t.QuerySelectorAll(".t1 span a").FirstOrDefault().TextContent.Trim(),
                            CorporateName = t.QuerySelectorAll(".t2 a").FirstOrDefault().TextContent.Trim(),
                            Salary = t.QuerySelectorAll(".t3").FirstOrDefault().TextContent.Trim(),
                            WorkingPlace = t.QuerySelectorAll(".t4").FirstOrDefault().TextContent.Trim(),
                            ReleaseDate = t.QuerySelectorAll(".t5").FirstOrDefault().TextContent.Trim(),
                            DetailsUrl = t.QuerySelectorAll(".t1 span a").FirstOrDefault().Attributes.FirstOrDefault(f => f.Name == "href").Value,
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
