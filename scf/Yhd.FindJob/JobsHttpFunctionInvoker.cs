using LBS.Amap.SDK;
using LBS.Amap.SDK.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yhd.TencentCloud.SCF;
using Yhd.TencentCloud.SCF.Executors;
using Yhd.TencentCloud.SCF.Protocols;

namespace Yhd.FindJob
{
    public class JobsHttpFunctionInvoker : HttpFunctionInvoker
    {
        private IJobsManager jobsManager;
        private IAmapWebApi amapWebApi;

        public JobsHttpFunctionInvoker(ILoggerFactory loggerFactory, IJobsManager manager, IAmapWebApi webApi) :
            base(loggerFactory)
        {
            jobsManager = manager;
            amapWebApi = webApi;
        }

        protected override async Task<APIGatewayProxyResponseEvent> Handler(SCFContext context, APIGatewayProxyRequestEvent requestEvent)
        {
            if (requestEvent != null && requestEvent.RequestContext == null)
            {
                return new APIGatewayProxyResponseEvent()
                {
                    ErrorCode = 410,
                    ErrorMessage = "event is not come from api gateway",
                };
            }
            if (requestEvent != null)
            {
                if (requestEvent.Path != "/api/jobs/getjobs" && requestEvent.Path != "/api/jobs/getdetailsinfo" && requestEvent.Path != "/api/geocode/regeo")
                {
                    return new APIGatewayProxyResponseEvent()
                    {
                        ErrorCode = 411,
                        ErrorMessage = "request is not from setting api path"
                    };
                }
                if (requestEvent.Path == "/api/jobs/getjobs" && requestEvent.HttpMethod.ToUpper() == "GET")
                {
                    string sources = requestEvent.QueryString["sources"];
                    string city = requestEvent.QueryString["city"];
                    string searchKey = requestEvent.QueryString["searchkey"];
                    string pageIndex = requestEvent.QueryString["pageindex"];
                    var jobs = await jobsManager.GetJobsAsync(sources.Split('-').ToList(), city, searchKey, int.Parse(pageIndex));
                    var response = new APIGatewayProxyResponseEvent()
                    {
                        StatusCode = 200,
                        ErrorCode = 0,
                        ErrorMessage = "",
                        Body = JsonConvert.SerializeObject(jobs),
                        IsBase64Encoded = false,
                        Headers = new Dictionary<string, string>()
                    };
                    response.Headers.Add("Content-Type", "application/json");
                    response.Headers.Add("Access-Control-Allow-Origin", "*");
                    return response;
                }
                if (requestEvent.Path == "/api/jobs/getdetailsinfo" && requestEvent.HttpMethod.ToUpper() == "GET")
                {
                    string source = requestEvent.QueryString["source"];
                    string url = requestEvent.QueryString["url"];
                    var jobs = await jobsManager.GetDetailsInfo(source, url);
                    var response = new APIGatewayProxyResponseEvent()
                    {
                        StatusCode = 200,
                        IsBase64Encoded = false,
                        Headers = new Dictionary<string, string>()
                    };
                    if (jobs == null)
                    {
                        response.ErrorCode = -1;
                        response.ErrorMessage = "user code exception caught";

                    }
                    else
                    {
                        response.ErrorCode = 0;
                        response.ErrorMessage = "";
                        response.Body = JsonConvert.SerializeObject(jobs);

                    }
                    response.Headers.Add("Content-Type", "application/json");
                    response.Headers.Add("Access-Control-Allow-Origin", "*");
                    return response;
                }
                if(requestEvent.Path == "/api/geocode/regeo" &&  requestEvent.HttpMethod.ToUpper() == "GET")
                {
                    string location = requestEvent.QueryString["location"];
                    ReGeoParameter reGeoParameter = new ReGeoParameter()
                    {
                        Location = location,
                        Batch = false,
                        Output = "JSON",
                        Radius = 1000,
                        RoadLevel = 0,
                        Extensions = "base",
                        Poitype = string.Empty
                    };

                    var regeo = await amapWebApi.GetRegeoAsync(reGeoParameter);

                    var response = new APIGatewayProxyResponseEvent()
                    {
                        StatusCode = 200,
                        IsBase64Encoded = false,
                        Headers = new Dictionary<string, string>()
                    };
                    if(regeo == null)
                    {
                        response.ErrorCode = -1;
                        response.ErrorMessage = "user code exception caught";

                    }
                    else
                    {
                        response.ErrorCode = 0;
                        response.ErrorMessage = "";
                        response.Body = string.IsNullOrEmpty(regeo.ReGeoCode.AddressComponent.City) ? regeo.ReGeoCode.AddressComponent.Province : regeo.ReGeoCode.AddressComponent.City;
                    }
                    response.Headers.Add("Content-Type", "application/json");
                    response.Headers.Add("Access-Control-Allow-Origin", "*");
                    return response;
                }
            }
            return new APIGatewayProxyResponseEvent()
            {
                ErrorCode = 413,
                ErrorMessage = "request is not correctly execute" 
            };
        }
    }
}
