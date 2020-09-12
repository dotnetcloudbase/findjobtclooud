using System;
using System.Threading.Tasks;
using EasyCaching.Core;
using Microsoft.Extensions.Options;

namespace Yhd.FindJobStat
{
    /// <summary>
    /// AccessToken 管理器接口
    /// </summary>
    public interface IAccessTokenManager
    {
        /// <summary>
        /// 获取 AccessToken
        /// </summary>
        /// <returns></returns>
        Task<string> GetAccessToken();
        /// <summary>
        /// 刷新 AccessToken
        /// </summary>
        /// <returns></returns>
        Task<string> RefreshAccessToken();
    }

    /// <summary>
    /// AccessToken 管理器实现
    /// </summary>
    public class AccessTokenManager : IAccessTokenManager
    {
        private IEasyCachingProvider _provider;
        private WxCloudOption _wxCloudOption;
        private ApiHttpClient _apiHttpClient;

        private static readonly string CacheKey = "AccessToken";
        /// <summary>
        /// 过期时间，官方规定 AccessToken 在 7200 秒后过期，这里采用 7000 秒。
        /// </summary>
        private static readonly TimeSpan ExpireIn = TimeSpan.FromSeconds(7000);

        public AccessTokenManager(IEasyCachingProvider provider, IOptions<WxCloudOption> options, ApiHttpClient apiHttpClient)
        {
            _provider = provider;
            _wxCloudOption = options.Value;
            _apiHttpClient = apiHttpClient;
        }

        /// <summary>
        /// 获取 AccessToken
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAccessToken()
        {
            var cacheToken = (await _provider.GetAsync<string>(CacheKey)).Value;
            if (!string.IsNullOrEmpty(cacheToken))
            {
                return cacheToken;
            }
            var accessTokenResponse = await GetAccessTokenFromApi();
            if (accessTokenResponse.HasError())
            {
                throw new Exception(accessTokenResponse.ErrorMessage);
            }
            var accessToken = accessTokenResponse.AccessToken;
            await _provider.SetAsync(CacheKey, accessToken, ExpireIn);
            return accessToken;
        }

        /// <summary>
        /// 刷新 AccessToken。清除缓存，重新获取
        /// </summary>
        /// <returns></returns>
        public async Task<string> RefreshAccessToken()
        {
            await _provider.RemoveAsync(CacheKey);
            return await GetAccessToken();
        }

        /// <summary>
        /// 调用微信API，获取 AccessToken
        /// </summary>
        /// <returns></returns>
        private async Task<AccessTokenModel> GetAccessTokenFromApi()
        {
            var api = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={_wxCloudOption.AppID}&secret={_wxCloudOption.AppSecret}";
            return await _apiHttpClient.HttpGet<AccessTokenModel>(api);
        }
    }
}
