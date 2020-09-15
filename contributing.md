# 项目贡献指南
欢迎参与 findjobtcloud 的贡献，你可以给我们提出意见、建议，报告 bug，或者贡献代码。在参与贡献之前，请阅读以下指引。

## 关于命名规范

## 咨询问题

简单的咨询，如询问如何使用、询问示例是如何实现的或其他和 Findjob 无关的技术问题，请在官方 QQ 群中询问，效率更高。

## 关于 issue
Findjob 的发展，离不开社区的贡献。如果你对 FindJob 的现状有意见、建议或者发现了 bug，欢迎通过 issue 给我们提出。提 issue 之前，请阅读以下指引。

- 搜索以往的 issue ，看是否已经提过，避免重复提出；
- 请确认你遇到的问题，是否在最新版本已被修复；
- 提出意见或建议时，请描述：
  - 现状
  - 给你带来了什么问题
  - 你的期望结果
  - 可能的实现方式（可选）
- 如果是报告 bug，请提供可以复现的条件：
  - 平台
  - 系统版本
  - 微信客户端版本
  - bug 表现
  - 是否必现
  - 最好可以提供截图
  - 最好可以提供示例代码，推荐使用 http://codepen.io
- 如果你的问题已经得到解决，请关闭你的 issue。

###  Fork项目

由于此时大家并没有对当前开源项目仓库进行修改的权限，因此需要通过 fork ，将此仓库复制一份到自己的名字下，从而得到一个自己有权限提交代码的仓库。

[![img](https://testerhome.com/uploads/photo/2019/f9797f26-e893-4768-8d5b-fb27b7fce0b4.png!large)](https://testerhome.com/uploads/photo/2019/f9797f26-e893-4768-8d5b-fb27b7fce0b4.png!large)

Fork 完毕后，会在自己的名下得到一个和原来开源项目仓库一模一样的仓库：

[![img](https://testerhome.com/uploads/photo/2019/1a586a0e-9dc9-4b6d-a140-45aa12899435.png!large)

### 开发+自测+提交代码

当完成了 Fork 操作后，可以 clone 下自己的仓库代码，并在本地基于 master 建立新的分支，进行开发、自测，并在自测通过后提交代码到自己的远程仓库。

### 提交 pull request

通过前一步骤，对应的修改代码已经放到了你自己 fork 出来的仓库里了，此时需要通过提交 pull request （后续简称 PR）来提交一个申请，把你的这部分修改代码合并到原来开源项目的仓库中。

当你的代码 push 到自己的远程仓库后，在 github 仓库首页，会见到一个自动提示，可以直接点击 【Compare & pull request】进入 PR 创建页面。

[![img](https://testerhome.com/uploads/photo/2019/7a2da1e7-5ca3-4a96-a62b-e930f47ccd2a.png!large)](https://testerhome.com/uploads/photo/2019/7a2da1e7-5ca3-4a96-a62b-e930f47ccd2a.png!large)

在 PR 创建页面，完成以下5项检查，最后点击 【Create Pull Request】提交你的修改。

[![img](https://testerhome.com/uploads/photo/2019/a9823009-9c12-4ff5-b747-582b641acc3d.png!large)](https://testerhome.com/uploads/photo/2019/a9823009-9c12-4ff5-b747-582b641acc3d.png!large)

提交完成后，将进入 PR 展示页面，你的 PR 将会出现在开源项目的 PR 列表中，并通知项目作者。

### 后续修改

PR 提交后，作者会进行 Review ，个别项目还会自动触发一些自动化检查和测试。若这些检查没有通过，会在 PR 页面上有对应提示，此时需要再次修改代码。

修改时，不需要重新提交 PR ，只需要直接在 PR 中自己仓库的分支进行修改，push，并在修改完毕后在 PR 中添加评论说明修改已提交即可。

另外，请特别注意，任何 PR 不应该存在和原有官方仓库的代码冲突。若存在，请自行修复。

## 贡献者名单

非常感谢以下几位贡献者对findjob做出的贡献：

[geffzhang](https://github.com/geffzhang)

[mrhuo](https://github.com/mrhuo)

## 参与贡献

如果你有好的意见或建议，欢迎给我们提 Issues 或 Pull Requests，为提升dotnet 生态贡献力量。
详见：[CONTRIBUTING.md](CONTRIBUTING.md)