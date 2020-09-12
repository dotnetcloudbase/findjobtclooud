using LBS.Amap.SDK.Http;
using LBS.Amap.SDK.Models;
using LBS.Amap.SDK.Models.Direction;
using System.Threading.Tasks;

namespace LBS.Amap.SDK
{
    internal class AmapWebApi : IAmapWebApi
    {
        private readonly AmapHttpClient _httpClient;

        public AmapWebApi(AmapHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CoordinateConvertResponse> ConvertCoordinateAsync(CoordinateConvertParameter param)
        {
            return await _httpClient.GetAsync<CoordinateConvertResponse>(AmapUriConst.ConvertCoordinate, param);
        }

        public async Task<string> ConvertCoordinateStringAsync(CoordinateConvertParameter param)
        {
            return await _httpClient.GetAsync(AmapUriConst.ConvertCoordinate, param);
        }

        public async Task<DistrictResponse> GetDistrictAsync(DistrictParameter param)
        {
            return await _httpClient.GetAsync<DistrictResponse>(AmapUriConst.District, param);
        }

        public async Task<string> GetDistrictStringAsync(DistrictParameter param)
        {
            return await _httpClient.GetAsync(AmapUriConst.District, param);
        }

        public async Task<GeoResponse> GetGeoCodeAsync(GeoParameter param)
        {
            return await _httpClient.GetAsync<GeoResponse>(AmapUriConst.GeoCode, param);
        }

        public async Task<string> GetGeoCodeStringAsync(GeoParameter param)
        {
            return await _httpClient.GetAsync(AmapUriConst.GeoCode, param);
        }


        public async Task<ReGeoResponse> GetRegeoAsync(ReGeoParameter param)
        {            
            return await _httpClient.GetAsync<ReGeoResponse>(AmapUriConst.ReGeoCode, param);
        }

        public async Task<string> GetRegeoStringAsync(ReGeoParameter param)
        {
            return await _httpClient.GetAsync(AmapUriConst.ReGeoCode, param);
        }

        public async Task<IPLocationResponse> GetIPLocationAsync(IPLocationParameter param)
        {
            return await _httpClient.GetAsync<IPLocationResponse>(AmapUriConst.IPLocation, param);
        }

        public async Task<string> GetIPLocationStringAsync(IPLocationParameter param)
        {
            return await _httpClient.GetAsync(AmapUriConst.IPLocation, param);
        }

        public async Task<byte[]> GetStaticMapAsync(StaticMapParameter param)
        {
            return await _httpClient.GetByteArrayAsync(AmapUriConst.StaticMap, param);
        }

        public async Task<TipResponse> GetTipsAsync(TipParameter param)
        {
            return await _httpClient.GetAsync<TipResponse>(AmapUriConst.InputTips, param);
        }

        public async Task<string> GetTipsStringAsync(TipParameter param)
        {
            return await _httpClient.GetAsync(AmapUriConst.InputTips, param);
        }

        public async Task<WalkingResponse> GetWalkingAsync(WalkingParameter param)
        {
            return await _httpClient.GetAsync<WalkingResponse>(AmapUriConst.DirectionWalking, param);
        }

        public async Task<string> GetWalkingStringAsync(WalkingParameter param)
        {
            return await _httpClient.GetAsync(AmapUriConst.DirectionWalking, param);
        }

        public async Task<WeatherResponse> GetWeatherInfoAsync(WeatherParameter param)
        {
            return await _httpClient.GetAsync<WeatherResponse>(AmapUriConst.Weather, param);
        }

        public async Task<string> GetWeatherInfoStringAsync(WeatherParameter param)
        {
            return await _httpClient.GetAsync(AmapUriConst.Weather, param);
        }
    }
}
