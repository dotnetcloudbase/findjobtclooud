const cloud = require('wx-server-sdk')
cloud.init()
const db = cloud.database()
const $ = db.command.aggregate

exports.main = async () => {
    return (await db.collection('stats')
        .aggregate()
        .match({
            type: "search"
        })
        .group({
            _id: $.toLower('$extra.keyword'),
            count: $.sum(1)
        })
        .sort({
            count: 1,
        })
        .limit(10)
        .end()).list;
}