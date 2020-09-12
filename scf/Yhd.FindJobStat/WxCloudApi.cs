using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Yhd.FindJobStat
{
    /// <summary>
    /// 小程序云开发 API
    /// </summary>
    public class WxCloudApi
    {
        private WxCloudOption _wxCloudOption;
        private IAccessTokenManager _accessTokenManager;

        public WxCloudApi(IOptions<WxCloudOption> options, IAccessTokenManager accessTokenManager)
        {
            _wxCloudOption = options.Value;
            _accessTokenManager = accessTokenManager;
        }

        /// <summary>
        /// 调用小程序云开发云函数
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="postBody"></param>
        /// <returns></returns>
        public async Task<WxCloudInvokeCloudFunctionModel> InvokeCloudFunction(string functionName, string postBody = "{}")
        {
            var accessToken = await _accessTokenManager.GetAccessToken();
            var api = $"https://api.weixin.qq.com/tcb/invokecloudfunction?access_token={accessToken}&env={_wxCloudOption.Env}&name={functionName}";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(api, new StringContent(postBody));
                response.EnsureSuccessStatusCode();
                var responseText = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WxCloudInvokeCloudFunctionModel>(responseText);
            }
        }
    }
}
