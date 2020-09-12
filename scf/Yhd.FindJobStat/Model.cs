using Newtonsoft.Json;

namespace Yhd.FindJobStat
{
    /// <summary>
    /// 错误模型类
    /// </summary>
    public class ErrorModel
    {
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }

        public bool HasError()
        {
            return ErrorCode > 0;
        }
    }

    /// <summary>
    /// AccessToken 模型类
    /// </summary>
    public class AccessTokenModel : ErrorModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }

    /// <summary>
    /// 微信云开发云函数调用结果模型类
    /// </summary>
    public class WxCloudInvokeCloudFunctionModel : ErrorModel
    {
        [JsonProperty("resp_data")]
        public string ResponseData { get; set; }
    }
}
