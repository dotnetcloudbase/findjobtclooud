##  在开发者工具中新建项目

打开微信开发者工具，添加小程序项目，选择合适的文件夹，使用自己的APP ID，勾选云开发服务，新建项目。

## 下载代码

进入到项目目录中删除所有文件，使用如下命令将代码下载到本地：

```bash
git clone https://github.com/dotnetcloudbase/findjobtclooud.git
```
把findjobtclooud文件夹中文件剪切到小程序项目根目录  

##  初始化云环境并修改参数

点击开发者工具的云开发，启用云服务。新建自己的云环境，复制云环境ID，然后把`app.js`和所有`cloudfunctions`文件夹下所有云函数的`index.js`中的：

```javascript
cloud.init({
  env: "xxxxxx" // 替换成自己的云环境ID
})
```

其中的`env`的值替换成自己的云环境ID。

##  云数据库初始化

在《微信开发者工具》里顶部菜单里点击“云开发”，打开“云开发控制台”，切换到“数据库”界面，在左侧的集合名称面板，添加 “favorites”、“stats”、“users” 三个集合。完成云数据库初始化。

##  部署云开发云函数

右击`cloudfunctions`，选择当前云环境。

分别右击`get-stat-apply, get-stat-pv, get-stat-top-city, get-stat-top-search, is-favorite, post-stat, save-favorite, user-favorite, user-login`云函数，选择在终端打开，输入如下命令安装依赖：

```bash
npm install --save tcb-router
```

##  部署腾讯云SCF云函数

SCF 云函数的部署参见[在腾讯云云函数计算上部署.NET Core 3.1](https://www.cnblogs.com/shanyou/p/scf-dotnet-customruntime.html)

##  部署Api网关

云函数通过API网关发布，具体发布文档参见[api网关和云函数](https://docs.qq.com/doc/DWHJ5VnNuWmFYcEV0?pub=1&dver=2.1.0)

##  运行小程序项目

点击编译，运行项目。

##  部署运营网站

运营网站的部署参见 [腾讯云 云开发 部署 Blazor网站](https://www.cnblogs.com/shanyou/p/13645172.html)
