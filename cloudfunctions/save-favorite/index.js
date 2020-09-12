const cloud = require('wx-server-sdk')
cloud.init()
const db = cloud.database()

exports.main = async (event, context) => {
    const openId = cloud.getWXContext().OPENID;
    var favorite = await db.collection('favorites').where({
        openId: openId,
        url: event.url
    }).get();
    if (favorite.data.length == 0) {
        var favoriteInfo = {
            openId: openId,
            source: event.source,
            url: event.url,
            jobTitle: event.jobTitle,
            area: event.area,
            salary: event.salary,
            jobCompany: event.jobCompany,
            time: event.time,
            logo: event.logo
        };
        await db.collection('favorites').add({
            data: favoriteInfo
        });
        return true
    }
    await db.collection('favorites').doc(favorite.data[0]._id).remove();
    return false
}