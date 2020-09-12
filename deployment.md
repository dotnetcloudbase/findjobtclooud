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

的`env`的值替换成自己的云环境ID。

右击`cloudfunctions`，选择当前云环境。


分别右击`get-stat-apply, get-stat-pv, get-stat-top-city, get-stat-top-search, is-favorite, post-stat, save-favorite, user-favorite,user-login`云函数，选择在终端打开，输入如下命令安装依赖：

```bash
npm install --save tcb-router
```

##  云数据库初始化

##  部署云开发云函数

##  部署腾讯云SCF云函数

##  部署Api网关

##  运行小程序项目

点击编译，运行项目。

##  部署运营网站