using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FindJobBlazorSite
{
    /// <summary>
    /// https://service-o8aj7zd4-1257277642.gz.apigw.tencentcs.com/release/api/stat/pv
    /// https://service-o8aj7zd4-1257277642.gz.apigw.tencentcs.com/release/api/stat/apply
    /// https://service-o8aj7zd4-1257277642.gz.apigw.tencentcs.com/release/api/stat/topsearch
    /// https://service-o8aj7zd4-1257277642.gz.apigw.tencentcs.com/release/api/stat/topcity
    /// </summary>
    public class WxCloudApi
    {
        private const string API_BASE_URL = "https://service-o8aj7zd4-1257277642.gz.apigw.tencentcs.com/release";
        private async Task<WxCloudApiResponse> InvokeScfApi(string api)
        {
            using (var httpClient = new HttpClient())
            {
                var scfResponse = await httpClient.GetFromJsonAsync<WxScfApiResponse>(api);
                if (scfResponse.HasError)
                {
                    throw new Exception(scfResponse.ErrorMessage);
                }
                return JsonSerializer.Deserialize<WxCloudApiResponse>(scfResponse.Body);
            }
        }

        public async Task<List<StatPv>> GetStatPv()
        {
            var response = await InvokeScfApi($"{API_BASE_URL}/api/stat/pv");
            if (response.HasError)
            {
                throw new Exception(response.ErrorMessage);
            }
            return JsonSerializer.Deserialize<List<StatPv>>(response.ResponseData);
        }

        public async Task<List<StatApply>> GetStatApply()
        {
            var response = await InvokeScfApi($"{API_BASE_URL}/api/stat/apply");
            if (response.HasError)
            {
                throw new Exception(response.ErrorMessage);
            }
            return JsonSerializer.Deserialize<List<StatApply>>(response.ResponseData);
        }

        public async Task<List<StatTopSearch>> GetStatTopSearch()
        {
            var response = await InvokeScfApi($"{API_BASE_URL}/api/stat/topsearch");
            if (response.HasError)
            {
                throw new Exception(response.ErrorMessage);
            }
            return JsonSerializer.Deserialize<List<StatTopSearch>>(response.ResponseData);
        }

        public async Task<List<StatTopCity>> GetStatTopCity()
        {
            var response = await InvokeScfApi($"{API_BASE_URL}/api/stat/topcity");
            if (response.HasError)
            {
                throw new Exception(response.ErrorMessage);
            }
            return JsonSerializer.Deserialize<List<StatTopCity>>(response.ResponseData);
        }
    }

    public class WxScfApiResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Body { get; set; }
        public bool HasError => ErrorCode > 0;
    }

    public class WxCloudApiResponse
    {
        [JsonPropertyName("errcode")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("errmsg")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("resp_data")]
        public string ResponseData { get; set; }

        public bool HasError => ErrorCode > 0;
    }

    public class StatPv
    {
        [JsonPropertyName("_id")]
        public string Date { get; set; }

        [JsonPropertyName("pv")]
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{Date}: {Value}";
        }
    }

    public class StatApply
    {
        [JsonPropertyName("_id")]
        public string Date { get; set; }

        [JsonPropertyName("pv")]
        public int Value { get; set; }
    }

    public class StatTopSearch
    {
        [JsonPropertyName("_id")]
        public string Keyword { get; set; }

        [JsonPropertyName("count")]
        public int Value { get; set; }
    }

    public class StatTopCity
    {
        [JsonPropertyName("_id")]
        public string City { get; set; }

        [JsonPropertyName("count")]
        public int Value { get; set; }
    }
}
