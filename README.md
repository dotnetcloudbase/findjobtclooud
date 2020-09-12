# 项目名称：快速找工作findjob

## 1. 项目介绍

首先感谢官方提供了这次比赛。刚好最近看到腾讯云云函数SCF 推出Custom Runtime定制化运行功能，正在使用C#封装Custom Runtime的云函数，需要找一个场景来进行验证工作，当前微信小程序使用js 作为开发语言， 云开发的云函数也支持多种语言，但是他们都不支持C#，腾讯云 SCF Custom Runtime的云函数可以让更多的后端程序员投身全栈开发。
本次参加这次大赛的初衷是以大赛的要求来充分验证使用C#打造全场景的云原生应用开发，参加比赛的场景是使用小程序快速查找各大招聘网站的岗位，用户在小程序种输入岗位关键词和城市【支持全部城市岗位（不选城市）】，将查询条件提交给后端云函数向各大招聘网站提交查询请求，合并查询结果返回给小程序，同时将相同查询条件的请求使用Redis缓存到服务端。用户在小程序端可以保存他感兴趣的岗位，也可以在微信小程序种发起申请岗位（调用招聘网站的小程序，这一部分理论上技术可行，更多的是商务，因此目前未实现）。用户在小程序端的相关操作进行一个访问统计，用户登录和保存感兴趣岗位数据，以及用户的访问统计数据使用云开发的云函数 封装api和数据库保存数据， 同时将云开发的数据通过Custom Runtime的云函数进行封装成API 提供给 运营站点进行展示， 运营站点使用基于WebAssembly技术的前端框架blazor 进行开发，通过云开发部署到静态网站托管。
这个项目充分调用了小程序的能力，并且结合云开发的优势，同时扩展云开发的云函数，当前云开发的云函数不支持Custom Runtime，云开发的云函数也是基于腾讯云SCF封装。微信小程序可以在ios和android上运行，解决了移动App必须去兼容多端的接口，减少工作量，开发出来的小程序稳定，用完就走，方便用户使用。 云开发进一步的简化了微信小程序的开发，真正做到云原生应用开发，当前云开发不支持C#语言，本项目的主要目的就是展示使用C#语言在云开发的应用。

## 2. 各页面功能展示

## 3. 项目架构

### 功能架构

项目 功能上由小程序 和运营网站构成， 用户使用微信小程序快速找工具，相关的运营数据保存在云开发的云存储中，通过运营网站进行展示。
![功能架构](https://github.com/dotnetcloudbase/findjobtclooud/tree/master/resources/funcarch.png)

### 系统架构

本项目以云开发为核心，主要包括：云函数，云数据库，云存储，和HTTP API（SCF云函数）和 .NET SCF Custom Runtime 五个部分。除了云开发外，还有小程序端，运营系统，第三方服务器等部分。
![系统架构](https://github.com/dotnetcloudbase/findjobtclooud/tree/master/resources/softarch.png)

## 4. 体验二维码

## 5. 部署指南

### 5.1 在开发者工具中新建项目

打开微信开发者工具，添加小程序项目，选择合适的文件夹，使用自己的APP ID，勾选云开发服务，新建项目。

### 5.2 下载代码

进入到项目目录中删除所有文件，使用如下命令将代码下载到本地：

```bash
git clone https://github.com/dotnetcloudbase/findjobtclooud.git
```
把findjobtclooud文件夹中文件剪切到小程序项目根目录  
### 5.3 初始化云环境并修改参数

点击开发者工具的云开发，启用云服务。新建自己的云环境，复制云环境ID，然后把`app.js`和所有`cloudfunctions`文件夹下所有云函数的`index.js`中的：

```javascript
cloud.init({
  env: "xxxxxx" // 替换成自己的云环境ID
})
```

的`env`的值替换成自己的云环境ID。

右击`cloudfunctions`，选择当前云环境。


分别右击`get-stat-apply, get-stat-pv, get-stat-top-city, get-stat-top-search, is-favorite, post-stat, save-favorite, user-favorite,user-login`云函数，选择在终端打开，输入如下命令安装依赖：

```bash
npm install --save tcb-router
```

### 5.4 云数据库初始化

### 5.6 部署云开发云函数

### 5.7 部署腾讯云SCF云函数

### 5.8 部署Api网关

### 5.9 运行小程序项目

点击编译，运行项目。

### 5.10 部署运营网站

## 开源协议

项目基于 MIT 协议， 详细请参考 [LICENSE](LICENSE) 

## 参考文档

- [云开发文档](https://developers.weixin.qq.com/miniprogram/dev/wxcloud/basis/getting-started.html)
- [Custom Runtime](https://cloud.tencent.com/document/product/583/47274)
