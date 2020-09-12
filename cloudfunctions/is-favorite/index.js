const cloud = require('wx-server-sdk')
cloud.init()
const db = cloud.database()

exports.main = async (event, context) => {
    const openId = cloud.getWXContext().OPENID;
    var favorite = await db.collection('favorites').where({
        openId: openId,
        url: event.url
    }).get();
    return favorite.data.length > 0;
}