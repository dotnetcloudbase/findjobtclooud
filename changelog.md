## 2020-08-17
- 新建小程序项目 findjob

## 2020-08-20
- 封装scf 云函数的核心逻辑
- scf 函数的API网关代理函数封装
- 在SCFContext 中传递配置的函数Handler名称，用于封装函数，用于指定开发规范

## 2020-08-21
- 封装findjob 逻辑
- 添加redis 缓存，使用EasyCaching组件
- 采用线程安全的集合

## 2020-08-22
- 迁入小程序基础版本，添加职位页面和我的页面，完成用户登录功能
- 封装云函数
- 修改redis 缓存

## 2020-08-23
- 修改 scf bootstrap file 格式

## 2020-08-24
- 添加经纬度转换为城市接口
- 接入 /api/jobs/getjobs 接口
- 完成首页列表展示
- 完成城市定位功能

## 2020-08-25
- 接入 /api/jobs/getdetailsinfo 接口
- 完成职位详情界面，并显示数据
- 完成收藏列表界面，并显示数据
- 提取配置到配置文件
- 更新文件 SCFServiceCollectionExtensions.cs

## 2020-08-26

- 完成小程序全部功能
- 优化 redis 缓存

## 2020-08-28
- 新增 echart 图表

## 2020-08-31
- 完善统计功能。小程序提交各种统计数据到服务器。
- echart 问题，移除小程序端的统计界面

## 2020-09-06
- 增加 Blazor 统计网站模板

## 2020-09-08
- 增加 scf Yhd.FindJobStat 项目
- 增加 scf XUnitTestFindJobStat 项目
- 增加 scf stat 项目

## 2020-09-09
- 完成 Blazor 运营网站
