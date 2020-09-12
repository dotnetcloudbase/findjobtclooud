const jobService = require("../../jobService")
Page({
    data: {
        jobDetail: {},
        isFavorite: false,
        pageOptions: {}
    },

    onLoad: function (options) {
        var that = this;
        jobService.statPreviewJobDetail() 
        //TODO: stat from page. options.from || "list"
        wx.showLoading({
            title: '加载中...'
        })
        var jobDetailInfo = {
            jobTitle: options.title,
            area: options.area,
            salary: options.salary,
            jobCompany: options.company,
            time: options.time,
            source: options.source,
            url: options.url,
            logo: options.logo
        };
        jobService.getJobDetail(options.source, options.url, (detail) => {
            wx.hideLoading()
            if (detail == null) {
                wx.showModal({
                    confirmText: '返回',
                    content: "该职位详情无法获取！",
                    showCancel: false,
                    title: '提示',
                    success(res) {
                        wx.navigateBack()
                    }
                })
                return;
            }
            jobDetailInfo.education = detail.Education;
            jobDetailInfo.experience = detail.Experience;
            jobDetailInfo.industry = detail.CompanyNature;
            jobDetailInfo.companySize = detail.CompanySize;
            jobDetailInfo.requirement = detail.Requirement
                .replace(/(\d[\.|、|\)|）])[ ]{0,}/ig, '\n$1')
                .replace(/\n\n/ig, '\n');
            jobDetailInfo.companyIntroduction = detail.CompanyIntroduction
                .replace("立即应聘", "")
                .replace("企业介绍：", "")
                .replace(/ /ig, '')
                .replace(/\n\n/ig, '\n')
                .replace(/\n\n/ig, '\n');

            that.setData({
                jobDetail: jobDetailInfo,
                pageOptions: options
            })
            that.fetchFavoriteState()
        })
    },

    onSaveFavorite() {
        var that = this;
        var jobDetailInfo = {
            source: that.data.jobDetail.source,
            url: that.data.jobDetail.url,
            jobTitle: that.data.jobDetail.jobTitle,
            area: that.data.jobDetail.area,
            salary: that.data.jobDetail.salary,
            jobCompany: that.data.jobDetail.jobCompany,
            time: that.data.jobDetail.time,
            logo: that.data.jobDetail.logo
        };
        jobService.saveFavorite(jobDetailInfo, (res) => {
            that.fetchFavoriteState()
            if (res) {
                var source = that.data.jobDetail.source;
                var url = that.data.jobDetail.url;
                jobService.statFavoriteJob(source, url);
                wx.showToast({
                    title: '已收藏',
                    icon: "none"
                })
                return;
            }
            wx.showToast({
                title: '已取消收藏',
                icon: "none"
            })
        })
    },

    fetchFavoriteState() {
        var that = this;
        jobService.isFavorite(this.data.jobDetail.url, function (res) {
            that.setData({
                isFavorite: res
            })
        });
    },

    onApplyJob() {
        var that = this
        var source = that.data.jobDetail.source;
        var url = that.data.jobDetail.url;
        jobService.statApplyJob(source, url);
        wx.showModal({
            confirmText: '确认',
            content: `此功能暂时不可用`,
            showCancel: false,
            title: "提示"
        })
    },

    onShareAppMessage: function (res) {
        var that = this
        var source = that.data.jobDetail.source;
        var url = that.data.jobDetail.url;
        jobService.statShareJobToFriend(source, url);
    },

    onShareTimeline: function (res) {
        var that = this
        var source = that.data.jobDetail.source;
        var url = that.data.jobDetail.url;
        jobService.statShareJobToTimeline(source, url);
        var queryString = []
        Object.keys(op).forEach(key=>{
            queryString.push(`${key}=${op[key]}`)
        });
        queryString.push("from=timeline")
        return {
            title: `${that.data.jobDetail.jobTitle} ${that.data.jobDetail.salary}`,
            query: queryString.join("&")
        }
    }
})