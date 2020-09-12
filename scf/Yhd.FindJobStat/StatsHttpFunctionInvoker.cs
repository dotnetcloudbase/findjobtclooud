using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Yhd.TencentCloud.SCF;
using Yhd.TencentCloud.SCF.Executors;
using Yhd.TencentCloud.SCF.Protocols;

namespace Yhd.FindJobStat
{
    /// <summary>
    /// 统计数据云开发数据库调用
    /// </summary>
    public class StatsHttpFunctionInvoker : HttpFunctionInvoker
    {
        private static WxCloudApi _wxCloudApi;

        public StatsHttpFunctionInvoker(ILoggerFactory loggerFactory, WxCloudApi wxCloudApi) :
            base(loggerFactory)
        {
            _wxCloudApi = wxCloudApi;
        }

        /// <summary>
        ///  URL mapping
        /// </summary>
        private readonly Dictionary<string, Func<APIGatewayProxyRequestEvent, Task<APIGatewayProxyResponseEvent>>> handlerMapper
            = new Dictionary<string, Func<APIGatewayProxyRequestEvent, Task<APIGatewayProxyResponseEvent>>>()
            {
                ["GET /api/stat/pv"] = HandlerStatPV,
                ["GET /api/stat/apply"] = HandlerStatApplyButton,
                ["GET /api/stat/topsearch"] = HandlerStatTop10Search,
                ["GET /api/stat/topcity"] = HandlerStatTop10City
            };

        /// <summary>
        /// 根据结果构建统一返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        private static APIGatewayProxyResponseEvent BuildCommonResponse<T>(T responseModel)
        {
            var response = new APIGatewayProxyResponseEvent()
            {
                StatusCode = 200,
                ErrorCode = 0,
                ErrorMessage = "",
                Body = JsonConvert.SerializeObject(responseModel),
                IsBase64Encoded = false,
                Headers = new Dictionary<string, string>()
            };
            response.Headers.Add("Content-Type", "application/json");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        /// <summary>
        /// 调用 get-stat-pv 云函数
        /// </summary>
        /// <param name="requestEvent"></param>
        /// <returns></returns>
        private static async Task<APIGatewayProxyResponseEvent> HandlerStatPV(APIGatewayProxyRequestEvent requestEvent)
        {
            return BuildCommonResponse(await _wxCloudApi.InvokeCloudFunction("get-stat-pv"));
        }

        /// <summary>
        /// 调用 get-stat-apply 云函数
        /// </summary>
        /// <param name="requestEvent"></param>
        /// <returns></returns>
        private static async Task<APIGatewayProxyResponseEvent> HandlerStatApplyButton(APIGatewayProxyRequestEvent requestEvent)
        {
            return BuildCommonResponse(await _wxCloudApi.InvokeCloudFunction("get-stat-apply"));
        }

        /// <summary>
        /// 调用 get-stat-top-search 云函数
        /// </summary>
        /// <param name="requestEvent"></param>
        /// <returns></returns>
        private static async Task<APIGatewayProxyResponseEvent> HandlerStatTop10Search(APIGatewayProxyRequestEvent requestEvent)
        {
            return BuildCommonResponse(await _wxCloudApi.InvokeCloudFunction("get-stat-top-search"));
        }

        /// <summary>
        /// 调用 get-stat-top-city 云函数
        /// </summary>
        /// <param name="requestEvent"></param>
        /// <returns></returns>
        private static async Task<APIGatewayProxyResponseEvent> HandlerStatTop10City(APIGatewayProxyRequestEvent requestEvent)
        {
            return BuildCommonResponse(await _wxCloudApi.InvokeCloudFunction("get-stat-top-city"));
        }

        /// <summary>
        /// 拦截并分发请求
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requestEvent"></param>
        /// <returns></returns>
        protected override async Task<APIGatewayProxyResponseEvent> Handler(SCFContext context, APIGatewayProxyRequestEvent requestEvent)
        {
            if (requestEvent == null)
            {
                return new APIGatewayProxyResponseEvent()
                {
                    ErrorCode = 413,
                    ErrorMessage = "request is not correctly execute"
                };
            }
            if (requestEvent.RequestContext == null)
            {
                return new APIGatewayProxyResponseEvent()
                {
                    ErrorCode = 410,
                    ErrorMessage = "event is not come from api gateway",
                };
            }
            var path = $"{requestEvent.HttpMethod.ToUpper()} {requestEvent.Path.ToLower()}";
            if (!handlerMapper.ContainsKey(path))
            {
                return new APIGatewayProxyResponseEvent()
                {
                    ErrorCode = 411,
                    ErrorMessage = "request is not from setting api path"
                };
            }
            return await handlerMapper[path](requestEvent);
        }
    }
}
