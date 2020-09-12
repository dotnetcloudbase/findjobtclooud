using LBS.Amap.SDK.Models;
using LBS.Amap.SDK.Models.Direction;
using System.Threading.Tasks;

namespace LBS.Amap.SDK
{
    public interface IAmapWebApi
    {
        /// <summary>
        /// 获取行政区域
        /// </summary>
        /// <param name="param"><see cref="DistrictParameter"/></param>
        /// <returns><seealso cref="DistrictResponse"/></returns>
        Task<DistrictResponse> GetDistrictAsync(DistrictParameter param);

        /// <summary>
        /// 获取行政区域
        /// </summary>
        /// <param name="param"><see cref="DistrictParameter"/></param>
        /// <returns></returns>
        Task<string> GetDistrictStringAsync(DistrictParameter param);

        /// <summary>
        /// 获取IP定位
        /// </summary>
        /// <param name="param"><see cref="IPLocationParameter"/></param>
        /// <returns><see cref="IPLocationResponse"/></returns>
        Task<IPLocationResponse> GetIPLocationAsync(IPLocationParameter param);

        /// <summary>
        /// 获取IP定位
        /// </summary>
        /// <param name="param"><see cref="IPLocationParameter"/></param>
        /// <returns></returns>
        Task<string> GetIPLocationStringAsync(IPLocationParameter param);

        /// <summary>
        /// 获取地理 
        /// </summary>
        /// <param name="param"><see cref="GeoParameter"/></param>
        /// <returns><see cref="GeoResponse"/></returns>
        Task<GeoResponse> GetGeoCodeAsync(GeoParameter param);

        /// <summary>
        /// 获取地理
        /// </summary>
        /// <param name="param"><see cref="GeoParameter"/></param>
        /// <returns></returns>
        Task<string> GetGeoCodeStringAsync(GeoParameter param);

        /// <summary>
        /// 获取逆地理编码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ReGeoResponse> GetRegeoAsync(ReGeoParameter param);

        /// <summary>
        /// 获取逆地理编码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<string> GetRegeoStringAsync(ReGeoParameter param);

        /// <summary>
        /// 获取步行路径规划
        /// </summary>
        /// <param name="param"><see cref="WalkingParameter"/></param>
        /// <returns><see cref="WalkingResponse"/></returns>
        Task<WalkingResponse> GetWalkingAsync(WalkingParameter param);

        /// <summary>
        /// 获取步行路径规划
        /// </summary>
        /// <param name="param"><see cref="WalkingParameter"/></param>
        /// <returns></returns>
        Task<string> GetWalkingStringAsync(WalkingParameter param);

        /// <summary>
        /// 获取静态地图
        /// </summary>
        /// <param name="param"><see cref="StaticMapParameter"/></param>
        /// <returns><see cref="byte[]"/></returns>
        Task<byte[]> GetStaticMapAsync(StaticMapParameter param);

        /// <summary>
        /// 转换坐标
        /// </summary>
        /// <param name="param"><see cref="CoordinateConvertParameter"/></param>
        /// <returns><see cref="CoordinateConvertResponse"/></returns>
        Task<CoordinateConvertResponse> ConvertCoordinateAsync(CoordinateConvertParameter param);

        /// <summary>
        /// 转换坐标
        /// </summary>
        /// <param name="param"><see cref="CoordinateConvertParameter"/></param>
        /// <returns></returns>
        Task<string> ConvertCoordinateStringAsync(CoordinateConvertParameter param);

        /// <summary>
        /// 获取天气
        /// </summary>
        /// <param name="param"><see cref="WeatherParameter"/></param>
        /// <returns><see cref="WeatherResponse"/></returns>
        Task<WeatherResponse> GetWeatherInfoAsync(WeatherParameter param);

        /// <summary>
        /// 获取天气
        /// </summary>
        /// <param name="param"><see cref="WeatherParameter"/></param>
        /// <returns></returns>
        Task<string> GetWeatherInfoStringAsync(WeatherParameter param);

        /// <summary>
        /// 获取输入提示
        /// </summary>
        /// <param name="param"><see cref="TipParameter"/></param>
        /// <returns><see cref="TipResponse"/></returns>
        Task<TipResponse> GetTipsAsync(TipParameter param);

        /// <summary>
        /// 获取输入提示
        /// </summary>
        /// <param name="param"><see cref="TipParameter"/></param>
        /// <returns></returns>
        Task<string> GetTipsStringAsync(TipParameter param);
    }
}
