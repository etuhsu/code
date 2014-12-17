    基于.Net平台的extjs单用户Blog系统简介　

　　该系统是由vifir.com推出的一个用于演示extjs在.net平台下使用的系统。系统后台使用.Net平台，语言为C#，技术构架为NHibernate+Spring.Net+Vifir实现，支持多种数据库，采用三层结构，数据访问层DAO、业务逻辑层及表示层完全分离。DAO层使用的泛型DAO，只需要一个DAO接口即可，不需要写具体的实现。

　系统演示：http://www.vifir.com/resources/records/codes/wlrblog-net/wlrblog-net.html
　
　源码下载及讨论地址：http://www.51aspx.com/CV/ExtJsBlog


　源码下载说明：该系统的源码尽提供给vifir.com的VIP会员学习研究使用，注册成为VIP会员将送一本《ExtJS实用开发指南》以及更多实用源码及参考资料，详情：http://www.vifir.com/tobeVIP.html。

　
  系统安装说明：
　安装后，需要修改Web.config文件中的数据库配置，把用户名及密码改正确，数据库的配置内容如下：
 <databaseSettings>
    <add key="db.datasource" value="(local);Integrated Security=true"/>
    <add key="db.user" value="sa"/>
    <add key="db.password" value="sa"/>
    <add key="db.database" value="vifirblog"/>
    <add key="db.generateDdl" value="true"/>
  </databaseSettings>
  <appSettings>
　其中db.user表示用户名，db.password表示密码，db.database表示数据库名，db.generateDdl表示是否让程序启动的时候自动生成表系统所需要的表结构。db.generateDdl默认为true，第一次运行成功后会自动建表结构，然后请手动修改成false即可。

　使用说明：
　http://localhost/manage将会进入登录页面，默认的系统管理员用户名及密码均为admin。
　

　　　
