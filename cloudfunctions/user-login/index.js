const cloud = require('wx-server-sdk')
cloud.init()
const db = cloud.database()

exports.main = async (event, context) => {
    const wxContext = cloud.getWXContext()
    const openId = wxContext.OPENID;

    var user = await db.collection('users').where({
        openId: openId
    }).get();
    if (user.data.length != 0) {
        var userInfo = user.data[0];
        var id = userInfo._id;

        userInfo.avatarUrl = userInfo.avatarUrl || event.userInfo.avatarUrl;
        userInfo.country = userInfo.country || event.userInfo.country;
        userInfo.province = userInfo.province || event.userInfo.province;
        userInfo.city = userInfo.city || event.userInfo.city;
        userInfo.gender = typeof (userInfo.gender) === "number" ? userInfo.gender : event.userInfo.gender;
        userInfo.language = userInfo.language || event.userInfo.language;
        userInfo.nickName = userInfo.nickName || event.userInfo.nickName;
        userInfo.unionId = wxContext.UNIONID || "";

        delete userInfo._id;

        await db.collection('users').doc(id).update({
            data: userInfo
        });

        return userInfo;
    } else {
        var userInfo = event.userInfo;
        userInfo.avatarUrl = userInfo.avatarUrl || null;
        userInfo.country = userInfo.country || null;
        userInfo.province = userInfo.province || null;
        userInfo.city = userInfo.city || null;
        userInfo.gender = typeof (userInfo.gender) === "number" ? userInfo.gender : 0;
        userInfo.language = userInfo.language || "zh_CN";
        userInfo.nickName = userInfo.nickName || null;
        userInfo.openId = wxContext.OPENID;
        userInfo.unionId = wxContext.UNIONID || "";

        await db.collection('users').add({
            data: userInfo
        });
        return userInfo;
    }
}