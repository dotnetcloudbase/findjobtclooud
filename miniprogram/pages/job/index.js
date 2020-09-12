const CONST = require("../../consts")
const jobService = require("../../jobService")

Page({
    data: {
        keywords: ".net",
        citys: CONST.CITYS,
        sites: CONST.SITES,
        selectedCity: "地区不限",
        selectedSite: "来源不限",
        filterScrollTop: 0,
        showAreaPicker: false,
        showSitePicker: false,
        currentPage: 1,
        jobList: []
    },

    onPageClick(e) {
        this.setData({
            showSitePicker: false,
            showAreaPicker: false
        })
    },

    onAreaChanged(e) {
        var that = this;
        var cityId = e.detail.value[0];
        var city = that.data.citys[cityId];
        that.setData({
            selectedCity: city
        })
    },

    onSiteChanged(e) {
        var that = this;
        var siteId = e.detail.value[0];
        var site = that.data.sites[siteId].name;
        that.setData({
            selectedSite: site
        })
    },

    onToggleAreaPicker(e) {
        var that = this;
        var isShow = that.data.showAreaPicker;
        that.setData({
            showSitePicker: false,
            showAreaPicker: !isShow
        })
    },

    onToggleSitePicker(e) {
        var that = this;
        var isShow = that.data.showSitePicker;
        that.setData({
            showAreaPicker: false,
            showSitePicker: !isShow
        })
    },

    onResetAreaPicker() {
        this.setData({
            selectedCity: "地区不限",
            showAreaPicker: false
        })
        this.doSearch()
    },

    onResetSitePicker() {
        this.setData({
            selectedSite: "来源不限",
            showSitePicker: false
        })
        this.doSearch()
    },

    onInputKeywords(e) {
        this.setData({
            keywords: e.detail.value
        })
    },

    onGetCurrentCity(e) {
        var that = this;
        wx.getLocation({
            type: 'wgs84',
            success(res) {
                const latitude = res.latitude
                const longitude = res.longitude
                jobService.statUseGetLocation()
                jobService.getCityByLatlng(latitude, longitude, (city) => {
                    console.log("city=", city);
                    if (!city) {
                        wx.showToast({
                            title: "解析经纬度失败!",
                            icon: "none"
                        })
                        return;
                    }
                    that.setData({
                        selectedCity: city
                    })
                })
            },
            fail(res) {
                console.log(res)
                wx.showToast({
                    title: "获取位置失败!",
                    icon: "none"
                })
            },
            complete() {
                that.setData({
                    showSitePicker: false,
                    showAreaPicker: false
                })
            }
        })
    },

    onConfirmArea() {
        var selectedCity = this.data.selectedCity;
        this.setData({
            showAreaPicker: false,
            selectedCity: selectedCity || "地区不限"
        })
        if (this.data.keywords) {
            this.doSearch()
        }
    },

    onConfirmSite() {
        var selectedSite = this.data.selectedSite;
        this.setData({
            showSitePicker: false,
            selectedSite: selectedSite || "来源不限"
        })
        if (this.data.keywords) {
            this.doSearch()
        }
    },

    doSearch() {
        this.doSearchWithPage(1)
    },

    doSearchWithPage(pageIndex) {
        this.setData({
            showAreaPicker: false,
            showSitePicker: false
        })
        var keywords = this.data.keywords;
        if (!keywords) {
            wx.showToast({
                title: '请输入关键词!',
                icon: "none"
            })
            wx.stopPullDownRefresh()
            return;
        }
        wx.showLoading({
            title: '搜索中...',
        })
        var sources = CONST.SITES.filter(p => p.name == this.data.selectedSite)[0].value;
        var prevJobList = this.data.jobList;
        var prevPage = this.data.currentPage;
        var city = this.data.selectedCity;
        if (city == "地区不限") {
            city = "";
        }
        if (pageIndex == 1) {
            prevJobList = [];
        }
        jobService.statSearch(keywords, sources, city);
        jobService.getJobs(keywords, sources, city, pageIndex, (jobs) => {
            wx.hideLoading()
            wx.stopPullDownRefresh()
            if (!jobs) {
                prevPage = pageIndex
                prevJobList = []
            } else {
                prevJobList = prevJobList.concat(jobs);
            }
            this.setData({
                currentPage: prevPage,
                jobList: prevJobList
            })
        })
    },

    onReachBottom() {
        this.doSearchWithPage(this.data.currentPage + 1)
    },

    onPullDownRefresh() {
        this.doSearch()
    },

    onPageScroll(t) {
        this.setData({
            filterScrollTop: t.scrollTop
        })
    },

    onViewJobDetail(e) {
        var data = e.currentTarget.dataset.data;
        wx.navigateTo({
            url: `/pages/job/detail?title=${data.jobTitle}&salary=${data.salary}&area=${data.area}&company=${data.jobCompany}&time=${data.time}&source=${data.sourceValue}&url=${data.detailsUrl}&logo=${data.logo}`,
        })
    },

    onShareAppMessage: function (res) {},

    onShareTimeline: function (res) {},

    onLoad() {
        jobService.statPreviewJobIndex()
    }
})