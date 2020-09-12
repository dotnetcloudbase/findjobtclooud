using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Yhd.FindJobStat
{
    /// <summary>
    /// Api 接口请求工具类
    /// </summary>
    public class ApiHttpClient
    {
        /// <summary>
        /// 发起 Get 请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<T> HttpGet<T>(string api, Dictionary<string, string> data = null)
        {
            return InvokeTencentApi<T>("GET", api, data);
        }

        /// <summary>
        /// 发起 Post 请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<T> HttpPost<T>(string api, Dictionary<string, string> data = null)
        {
            return InvokeTencentApi<T>("POST", api, data);
        }

        /// <summary>
        /// 调用腾讯API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <param name="api"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private async Task<T> InvokeTencentApi<T>(string method, string api, Dictionary<string, string> data = null)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = null;
                switch (method.ToUpper())
                {
                    case "GET":
                        if (data != null)
                        {
                            api = api + "?" + string.Join("&", data.Select(p => $"{p.Key}={UrlEncoder.Default.Encode(p.Value)}"));
                        }
                        response = await httpClient.GetAsync(api);
                        break;
                    case "POST":
                        response = await httpClient.PostAsync(api, new FormUrlEncodedContent(data));
                        break;
                }
                response.EnsureSuccessStatusCode();
                var responseText = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseText);
            }
        }
    }
}
