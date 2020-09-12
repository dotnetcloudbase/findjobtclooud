const jobService = require("../../jobService")
Page({
    onLoad: function (options) {
        jobService.statPreviewAbout()
    },

    onShareAppMessage: function () {
    },

    onShareTimeline() {
    }
})