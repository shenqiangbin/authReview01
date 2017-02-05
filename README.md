复习 窗体认证

介绍
主页是登录界面，点击登录后直接登录。登录后显示用户名，没有登录时，无法访问【新闻】【关于】界面，会自动跳转到登录页，登录后会自动跳回。【新闻】页因角色控制。会提示无访问权限

可直接利用使用：修改todo内容即可

主要文件：HomeController、UserAuthorize、Web.config

功能一：
登录和注销功能：模块登录，登录成功后，显示用户名称。
（要实现自定义cookie名字，和登录路径）

功能二：
用户登录后，才能访问某些界面，否则跳转到登录页。且登录成功后，跳回原来的界面。
（使用AuthorizeAttribute过滤器）

功能三：
添加角色限制，只有某些角色才能访问某些界面。（无权限访问时，显示无访问权限界面，没有登录时，显示登录界面）
（重写AuthorizeAttribute过滤器，在验证过程中，加入角色的校验，根据登录的用户和url去库中查角色是否在访问这个url的权限。
这个没有使用AuthorizeAttribute中的Role，因为这个是写死的，也没有将role写在cookie中，这个只适合角色不变动的情况）

