# API接口说明

找工作提供2个接口， 聚合查询招聘网站的岗位数据 以及查看岗位的详细信息。

1. 查询招聘网站的岗位数据
   - path： /api/jobs/getjobs?sources=xxxx&city=xxx&searchkey=xxxxx&pageindex=1
   - method: httpget
   - 格式： json
2. 查看岗位的详细信息
   - path： /api/jobs/getdetailsinfo?source=xxxx&url=xxx 
   - method: httpget
   - 格式： json

# 应用配置

使用Redis 用户的最新查询数据，默认缓存10分钟。