const jobService = require("../../jobService")
Page({
    data: {
        isLogin: false,
        userInfo: {}
    },

    onGotUserInfo(e) {
        if (e.detail.errMsg == "getUserInfo:ok") {
            this.onUserLogin(e.detail.userInfo);
        }
    },

    userLoginFunc (userInfo, sb) {
        wx.cloud.callFunction({
            name: "user-login",
            data: {
                userInfo: userInfo
            },
            success: res => {
                if (res.errMsg == "cloud.callFunction:ok") {
                    sb && sb(res.result)
                } else {
                    log.error(`API[user-login]调用失败，`, res)
                }
            },
            fail: err => {
                log.error(`API[${consts.functions.userLogin}]调用失败，`, err)
            }
        })
    },

    onUserLogin(userInfo) {
        var that = this;
        that.userLoginFunc(userInfo, (loginResult) => {
            getApp().globalData.userInfo = loginResult;
            that.setData({
                userInfo: loginResult,
                isLogin: true
            })
        });
    },

    onShow: function (options) {
        var that = this;
        wx.getSetting({
            success(res) {
                if (res.authSetting['scope.userInfo']) {
                    wx.getUserInfo({
                        success: function (res) {
                            that.onUserLogin(res.userInfo);
                        },
                        fail: function () {
                            that.setData({
                                userInfo: {},
                                isLogin: false
                            })
                        }
                    })
                }
            }
        })
    },

    onLoad: function (options) {
        jobService.statPreviewMy()
    }
})