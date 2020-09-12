const cloud = require('wx-server-sdk')
cloud.init()
const db = cloud.database()
const $ = db.command.aggregate

exports.main = async () => {
    let curDate = new Date((+new Date()) - 30 * 24 * 3600 * 1000);
    return (await db.collection('stats')
    .aggregate()
    .addFields({
        matched: $.and([
            $.gte(['$date', curDate]),
            $.eq(['$type', 'apply'])
        ]),
    })
    .match({
        matched: !0
    })
    .group({
        _id: '$date',
        pv: $.sum(1)
    })
    .sort({
        _id: 1,
    })
    .end()).list;
}