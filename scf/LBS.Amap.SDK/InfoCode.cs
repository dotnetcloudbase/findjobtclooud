namespace LBS.Amap.SDK
{
    /// <summary>
    /// 错误码
    /// </summary>
    public enum InfoCode
    {
        /// <summary>
        /// 请求正常
        /// </summary>
        OK = 10000,

        /// <summary>
        /// key不正确或过期
        /// </summary>
        INVALID_USER_KEY = 10001,

        /// <summary>
        /// 没有权限使用相应的服务或者请求接口的路径拼写错误
        /// </summary>
        SERVICE_NOT_AVAILABLE = 10002,

        /// <summary>
        /// 访问已超出日访问量
        /// </summary>
        DAILY_QUERY_OVER_LIMIT = 10003,

        /// <summary>
        /// 单位时间内访问过于频繁
        /// </summary>
        ACCESS_TOO_FREQUENT = 10004,

        /// <summary>
        /// IP白名单出错，发送请求的服务器IP不在IP白名单内
        /// </summary>
        INVALID_USER_IP = 10005,

        /// <summary>
        /// 绑定域名无效
        /// </summary>
        INVALID_USER_DOMAIN = 10006,

        /// <summary>
        /// 数字签名未通过验证
        /// </summary>
        INVALID_USER_SIGNATURE = 10007,

        /// <summary>
        /// MD5安全码未通过验证
        /// </summary>
        INVALID_USER_SCODE = 10008,

        /// <summary>
        /// 请求key与绑定平台不符
        /// </summary>
        USERKEY_PLAT_NOMATCH = 10009,

        /// <summary>
        /// IP访问超限
        /// </summary>
        IP_QUERY_OVER_LIMIT = 10010,

        /// <summary>
        /// 服务不支持https请求
        /// </summary>
        NOT_SUPPORT_HTTPS = 10011,

        /// <summary>
        /// 权限不足，服务请求被拒绝
        /// </summary>
        INSUFFICIENT_PRIVILEGES = 10012,

        /// <summary>
        /// Key被删除
        /// </summary>
        USER_KEY_RECYCLED = 10013,

        /// <summary>
        /// 云图服务QPS超限
        /// </summary>
        QPS_HAS_EXCEEDED_THE_LIMIT = 10014,

        /// <summary>
        /// 受单机QPS限流限制
        /// </summary>
        GATEWAY_TIMEOUT = 10015,

        /// <summary>
        /// 服务器负载过高
        /// </summary>
        SERVER_IS_BUSY = 10016,

        /// <summary>
        /// 所请求的资源不可用
        /// </summary>
        RESOURCE_UNAVAILABLE = 10017,

        /// <summary>
        /// 使用的某个服务总QPS超限
        /// </summary>
        CQPS_HAS_EXCEEDED_THE_LIMIT = 10019,

        /// <summary>
        /// 某个Key使用某个服务接口QPS超出限制
        /// </summary>
        CKQPS_HAS_EXCEEDED_THE_LIMIT = 10020,

        /// <summary>
        /// 来自于同一IP的访问，使用某个服务QPS超出限制
        /// </summary>
        CIQPS_HAS_EXCEEDED_THE_LIMIT = 10021,

        /// <summary>
        /// 某个Key，来自于同一IP的访问，使用某个服务QPS超出限制
        /// </summary>
        CIKQPS_HAS_EXCEEDED_THE_LIMIT = 10022,

        /// <summary>
        /// 某个Key的QPS超出限制
        /// </summary>
        KQPS_HAS_EXCEEDED_THE_LIMIT = 10023,

        /// <summary>
        /// 某个Key的QPS超出限制
        /// </summary>
        ABROAD_DAILY_QUERY_OVER_LIMIT = 10029,

        /// <summary>
        /// 请求参数非法
        /// </summary>
        INVALID_PARAMS = 20000,

        /// <summary>
        /// 缺少必填参数
        /// </summary>
        MISSING_REQUIRED_PARAMS = 20001,

        /// <summary>
        /// 请求协议非法
        /// </summary>
        ILLEGAL_REQUEST = 20002,

        /// <summary>
        /// 其他未知错误
        /// </summary>
        UNKNOWN_ERROR = 20003,

        /// <summary>
        /// 查询坐标或规划点（包括起点、终点、途经点）在海外，但没有海外地图权限
        /// </summary>
        INSUFFICIENT_ABROAD_PRIVILEGES = 20011,

        /// <summary>
        /// 查询信息存在非法内容
        /// </summary>
        ILLEGAL_CONTENT = 20012,

        /// <summary>
        /// 规划点（包括起点、终点、途经点）不在中国陆地范围内
        /// </summary>
        OUT_OF_SERVICE = 20800,

        /// <summary>
        /// 划点（起点、终点、途经点）附近搜不到路
        /// </summary>
        NO_ROADS_NEARBY = 20801,

        /// <summary>
        /// 路线计算失败，通常是由于道路连通关系导致
        /// </summary>
        ROUTE_FAIL = 20802,

        /// <summary>
        /// 起点终点距离过长
        /// </summary>
        OVER_DIRECTION_RANGE = 20803,

        /// <summary>
        /// 余额耗尽
        /// </summary>
        QUOTA_PLAN_RUN_OUT = 40000,

        /// <summary>
        /// 围栏个数达到上限
        /// </summary>
        GEOFENCE_MAX_COUNT_REACHED = 40001,

        /// <summary>
        /// 购买服务到期
        /// </summary>
        SERVICE_EXPIRED = 40002,

        /// <summary>
        /// 海外服务余额耗尽
        /// </summary>
        ABROAD_QUOTA_PLAN_RUN_OUT = 40003

    }
}
