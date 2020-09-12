using LBS.Amap.SDK.Json;
using LBS.Amap.SDK.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LBS.Amap.SDK.Http
{
    internal class AmapHttpClient
    {
        private readonly HttpClient _client;
        private readonly IOptionsMonitor<AmapOptions> _options;
        public AmapHttpClient(HttpClient client, IOptionsMonitor<AmapOptions> options)
        {
            client.BaseAddress = new Uri("https://restapi.amap.com/");
            _client = client;
            _options = options;
        }

        public async Task<T> GetAsync<T>(string uri, BaseParameter param)
        {
            var result = await GetAsync(uri, param);
            if (string.IsNullOrWhiteSpace(result))
                return default(T);

            if (param.Output == "XML")
            {
                return AmapJsonConvert.DeserializeXmlObject<T>(result);
            }

            return AmapJsonConvert.DeserializeObject<T>(result);
        }

        public async Task<string> GetAsync(string uri, BaseParameter param)
        {
            if (param == null)
                return string.Empty;

            var paramStr = param.ToUriParam();
            paramStr += "&key=" + _options.CurrentValue.Key;
            return await _client.GetStringAsync($"{uri}?{paramStr}").ConfigureAwait(false);
        }

        public async Task<byte[]> GetByteArrayAsync(string uri, BaseParameter param)
        {
            var paramStr = param.ToUriParam();
            paramStr += "&key=" + _options.CurrentValue.Key;
            return await _client.GetByteArrayAsync($"{uri}?{paramStr}").ConfigureAwait(false);
        }
    }
}
