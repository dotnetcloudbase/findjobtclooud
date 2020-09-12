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
            _id: '$extra.city',
            count: $.sum(1)
        })
        .project({
            _id: $.cond({
                if: $.eq(["$_id", ""]),
                then: "城市不限",
                else: "$_id"
            }),
            count: 1
        })
        .sort({
            count: 1,
        })
        .limit(10)
        .end()).list;
}