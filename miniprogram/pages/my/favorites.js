const jobService = require("../../jobService");
Page({
    data: {
        jobList: []
    },

    onLoad: function (options) {
        this.fetchMyFavorites();
        jobService.statPreviewMyFavorite()
    },

    onPullDownRefresh: function () {
        this.fetchMyFavorites();
    },

    onDeleteFavorite(e) {
        var that = this;
        var data = e.currentTarget.dataset.data;
        var url = data.detailsUrl;
        wx.showModal({
            title: '询问',
            content: "确认要删除这条收藏记录吗？",
            success: function (res) {
                if (res.confirm) {
                    jobService.deleteFavorite(url, (res) => {
                        that.fetchMyFavorites();
                    });
                }
            }
        })
    },

    fetchMyFavorites() {
        var that = this;
        wx.showLoading({
            title: '加载中...'
        });
        jobService.getMyFavorites((res) => {
            wx.hideLoading();
            wx.stopPullDownRefresh()
            that.setData({
                jobList: res || []
            });
        });
    },

    onViewJobDetail(e) {
        var data = e.currentTarget.dataset.data;
        wx.navigateTo({
            url: `/pages/job/detail?title=${data.jobTitle}&salary=${data.salary}&area=${data.area}&company=${data.jobCompany}&time=${data.time}&source=${data.source}&url=${data.url}&logo=${data.logo}`,
        })
    }
})