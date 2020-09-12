const CONST = require("./consts")
let _service = (function () {
    const API_BASE = "https://service-o8aj7zd4-1257277642.gz.apigw.tencentcs.com/release"
    const API_GET_JOBS = API_BASE + "/api/jobs/getjobs"
    const API_GET_JOB_DETAIL = API_BASE + "/api/jobs/getdetailsinfo"
    const API_GET_LOCATED_CITY = API_BASE + "/api/geocode/regeo"
    const DEBUG_ENABLED = false

    let loggerInfo = function (msg, param) {
        console.log("INFO: " + msg, param)
    };
    let loggerError = function (msg, param) {
        console.error("ERROR: " + msg, param)
        if (DEBUG_ENABLED) {
            wx.showModal({
                showCancel: false,
                content: `${msg}${!param ? "" :"\n" + JSON.stringify(param)}`
            })
        }
    };
    let dateFormat = function (fmt, date) {
        date = date || new Date()
        let ret;
        let opt = {
            "y+": date.getFullYear().toString(), // 年
            "M+": (date.getMonth() + 1).toString(), // 月
            "d+": date.getDate().toString(), // 日
            "H+": date.getHours().toString(), // 时
            "m+": date.getMinutes().toString(), // 分
            "s+": date.getSeconds().toString() // 秒
        };
        for (let k in opt) {
            ret = new RegExp("(" + k + ")").exec(fmt);
            if (ret) {
                fmt = fmt.replace(ret[1], (ret[1].length == 1) ? (opt[k]) : (opt[k].padStart(ret[1].length, "0")))
            };
        };
        return fmt;
    };
    let getJobs = function (keyword, sources, city, pageIndex, callback) {
        wx.request({
            url: API_GET_JOBS,
            method: "GET",
            data: {
                pageindex: pageIndex,
                sources: sources,
                city: city,
                searchkey: keyword
            },
            success(res) {
                loggerInfo(`请求接口【${API_GET_JOBS}】成功`, res)
                var data = JSON.parse(res.data.Body || "[]") || [];
                var jobs = data.map(p => {
                    var logo = ""
                    var source = ""
                    switch (p.Source) {
                        case "Liepin":
                            logo = "/images/logo_liepin.png"
                            source = "猎聘网"
                            break;
                        case "ZLZhaopin":
                            logo = "/images/logo_zhilian.png"
                            source = "智联招聘"
                            break;
                        case "QC51":
                            logo = "/images/logo_qianchengwuyou.png"
                            source = "前程无忧"
                            break;
                        case "BOSS":
                            logo = "/images/logo_boss.png"
                            source = "BOSS直聘"
                            break;
                    }
                    var sourceValue = CONST.SITES.filter(p => p.name == source)[0].value;
                    return {
                        "logo": logo,
                        "source": source,
                        "jobTitle": (p.PositionName || "").trim(),
                        "salary": (p.Salary || "").trim(),
                        "jobCompany": (p.CorporateName || "").trim(),
                        "area": (p.WorkingPlace || "").trim(),
                        "time": (p.ReleaseDate || "").trim(),
                        "detailsUrl": (p.DetailsUrl || "").trim(),
                        "sourceValue": sourceValue
                    }
                });
                callback && callback(jobs)
            },
            fail(res) {
                callback && callback([])
                loggerError("获取职位列表出错！", res)
            }
        })
    };
    let getJobDetail = function (source, url, callback) {
        wx.request({
            url: API_GET_JOB_DETAIL,
            method: "GET",
            data: {
                source: source,
                url: url
            },
            success(res) {
                loggerInfo(`请求接口【${API_GET_JOB_DETAIL}】成功`, res)
                if (!res.data.Body) {
                    callback && callback(null)
                    return;
                }
                callback && callback(JSON.parse(res.data.Body))
            },
            fail(res) {
                callback && callback(null)
                loggerError("获取职位详情出错！", res)
            }
        })
    };
    let getCityByLatlng = function (lat, lng, callback) {
        wx.request({
            url: API_GET_LOCATED_CITY,
            method: "GET",
            data: {
                location: `${lng},${lat}`
            },
            success(res) {
                loggerInfo(`请求接口【${API_GET_LOCATED_CITY}】成功`, res)
                if (!res.data.Body) {
                    callback && callback(null)
                    return;
                }
                callback && callback(res.data.Body)
            },
            fail(res) {
                callback && callback(null)
                loggerError("反解析地理位置失败！", res)
            }
        })
    };
    let isFavorite = function (url, callback) {
        wx.cloud.callFunction({
            name: 'is-favorite',
            data: {
                url: url
            }
        }).then(res => {
            loggerInfo(`调用云函数【is-favorite】成功`, res)
            callback && callback(res.result);
        }).catch(err => {
            callback && callback(false);
            loggerError("调用云函数[is-favorite]失败！", err)
        });
    };
    let saveFavorite = function (jobInfo, callback) {
        wx.cloud.callFunction({
            name: 'save-favorite',
            data: jobInfo
        }).then(res => {
            loggerInfo(`调用云函数【save-favorite】成功`, res)
            callback && callback(res.result);
        }).catch(err => {
            callback && callback(null);
            loggerError("调用云函数[save-favorite]失败！", err)
        });
    };
    let deleteFavorite = function (url, callback) {
        wx.cloud.callFunction({
            name: 'save-favorite',
            data: {
                url: url
            }
        }).then(res => {
            loggerInfo(`调用云函数【save-favorite】成功`, res)
            callback && callback(res.result);
        }).catch(err => {
            callback && callback(null);
            loggerError("调用云函数[save-favorite]失败！", err)
        });
    };
    let getMyFavorites = function (callback) {
        wx.cloud.callFunction({
            name: 'user-favorite'
        }).then(res => {
            loggerInfo(`调用云函数【user-favorite】成功`, res)
            callback && callback(res.result || []);
        }).catch(err => {
            callback && callback([]);
            loggerError("调用云函数[user-favorite]失败！", err)
        });
    };
    //统计方法
    const EventType = {
        PREVIEW: "preview",
        CLICK: "click",
        LOCATION: "location",
        SEARCH: "search",
        APPLY: "apply",
        FAVORITE: "favorite",
        SHARE_TO_FRIEND: "shareToFriend",
        SHARE_TO_TIME_LINE: "shareToTimeline"
    }
    let stat = function (page, event, extras) {
        try {
            setTimeout(() => {
                var date = dateFormat("yyyy-MM-dd")
                console.log(`[${date}] STAT: [${event}] ${page}`, extras)
                wx.cloud.callFunction({
                    name: 'post-stat',
                    data: {
                        date: date,
                        type: event,
                        page: page,
                        extra: extras
                    }
                }).then(res => {
                    loggerInfo(`调用云函数【post-stat】成功`, res)
                }).catch(err => {
                    loggerError("调用云函数[post-stat]失败！", err)
                });
            }, 100);
        } catch (error) {
            console.warn("POST STATISTIC DATA ERROR, ", error);
            loggerError("调用云函数[post-stat]失败！", error)
        }
    }
    let statPreviewJobIndex = function () {
        stat("/pages/job/index", EventType.PREVIEW)
    };
    let statPreviewJobDetail = function () {
        stat("/pages/job/detail", EventType.PREVIEW)
    };
    let statPreviewMy = function () {
        stat("/pages/job/my", EventType.PREVIEW)
    };
    let statPreviewMyFavorite = function () {
        stat("/pages/my/favorites", EventType.PREVIEW)
    };
    let statPreviewAbout = function () {
        stat("/pages/my/about", EventType.PREVIEW)
    };
    let statUseGetLocation = function () {
        stat(null, EventType.LOCATION)
    };
    let statSearch = function (keyword, source, city) {
        stat(null, EventType.SEARCH, {
            keyword,
            source,
            city
        })
    };
    let statApplyJob = function (source, url) {
        stat(null, EventType.APPLY, {
            source,
            url
        })
    };
    let statFavoriteJob = function (source, url) {
        stat(null, EventType.FAVORITE, {
            source,
            url
        })
    };
    let statShareJobToFriend = function (source, url) {
        stat(null, EventType.SHARE_TO_FRIEND, {
            source,
            url
        })
    };
    let statShareJobToTimeline = function (source, url) {
        stat(null, EventType.SHARE_TO_TIME_LINE, {
            source,
            url
        })
    };

    let getStatPV = function (callback) {
        wx.cloud.callFunction({
            name: 'get-stat-pv'
        }).then(res => {
            loggerInfo(`调用云函数【get-stat-pv】成功`, res)
            callback && callback(res.result || []);
        }).catch(err => {
            callback && callback([]);
            loggerError("调用云函数[get-stat-pv]失败！", err)
        });
    };
    let getStatTopSearch = function (callback) {
        wx.cloud.callFunction({
            name: 'get-stat-top-search'
        }).then(res => {
            loggerInfo(`调用云函数【get-stat-top-search】成功`, res)
            callback && callback(res.result || []);
        }).catch(err => {
            callback && callback([]);
            loggerError("调用云函数[get-stat-top-search]失败！", err)
        });
    };
    let getStatTopCity = function (callback) {
        wx.cloud.callFunction({
            name: 'get-stat-top-city'
        }).then(res => {
            loggerInfo(`调用云函数【get-stat-top-city`, res)
            callback && callback(res.result || []);
        }).catch(err => {
            callback && callback([]);
            loggerError("调用云函数[get-stat-top-city]失败！", err)
        });
    };
    return {
        getJobs,
        getJobDetail,
        getCityByLatlng,
        isFavorite,
        saveFavorite,
        deleteFavorite,
        getMyFavorites,

        statPreviewJobIndex,
        statPreviewJobDetail,
        statPreviewMy,
        statPreviewMyFavorite,
        statPreviewAbout,
        statUseGetLocation,
        statSearch,
        statApplyJob,
        statFavoriteJob,
        statShareJobToFriend,
        statShareJobToTimeline,

        getStatPV,
        getStatTopSearch,
        getStatTopCity
    };
})();
module.exports = _service