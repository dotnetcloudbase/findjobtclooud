const cloud = require('wx-server-sdk')
cloud.init()
const db = cloud.database()

exports.main = async (event, context) => {
    var statInfo = {
        date: event.date,
        type: event.type,
        page: event.page,
        extra: event.extra
    };
    await db.collection('stats').add({
        data: statInfo
    });
    return true
}