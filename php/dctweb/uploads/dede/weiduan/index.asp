<%
'强制浏览器重新访问服务器下载页面，而不是从缓存读取页面
Response.Buffer = True
Response.Expires = -1
Response.ExpiresAbsolute = Now() - 1
Response.Expires = 0
Response.CacheControl = "no-cache"
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type"  content="text/html; charset=gb2312" />
<meta http-equiv="Refresh" content="60" >
<title>无标题文档</title>
<style type="text/css">
<!--
body{margin:0 0 0 0;
padding:0 0 0 0;
background-color:#000000;

}
td {font-size:12px;}
.hong{color:#FF0000;}
.lv{color:#00FF00;}
.huan{color:#FFFF00}
.abs{ border:1px solid #FF0000; border-collapse:collapse}
.abslv{ border:1px solid #FF0000; border-collapse:collapse;color:#00FF00;height:18px}
-->
</style>
</head>
<script language="JavaScript"> 
function fucCheckLength(strTemp) 
{ 
  var strs
  if (strTemp<10) {strs="0"+strTemp}else{strs=strTemp}
  return strs
}
function Time(){ 
  var now=new Date() 
  position.innerHTML=now.getYear()+"-"+(now.getMonth()+1)+"-"+now.getDate()+" "+fucCheckLength(now.getHours())+":"+fucCheckLength(now.getMinutes())+":"+fucCheckLength(now.getSeconds());
  setTimeout("Time()",1000) 
}
</script> 
<body leftmargin="0" topmargin="0" rightmargin="0" backcolor="0000ff">
<%
if Request.Cookies("UserVisit")("kcount")="" then   '若该Cookie不存在
    Response.Cookies("UserVisit")("kcount")=1
	Response.Cookies("UserVisit")("rcount")=1
	Response.Cookies("UserVisit")("tcount")=1
else
    Response.Cookies("UserVisit")("kcount")=Request.Cookies("UserVisit")("kcount")+1
	Response.Cookies("UserVisit")("rcount")=Request.Cookies("UserVisit")("rcount")+1
	Response.Cookies("UserVisit")("tcount")=Request.Cookies("UserVisit")("tcount")+1
end if

%>
<%
	  on error resume next
constr="driver={SQL Server};server=yyfdcw;initial Catalog=fdc;User ID=web;Password=5916519"
set conn=server.createobject("adodb.connection")
conn.Open constr
%>
<table width="760" height="30" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td align="center" valign="bottom" ><span style="color: #FF0000; font: bold; font-size: 23px; font-weight: bold; letter-spacing: 8px;">岳阳市房地产交易信息发布平台</span></td>
  </tr>
</table>
<table width="760" height="384" border="0" cellpadding="0" cellspacing="0" bgcolor="#000000">
  <tr> 
    <td height="30" colspan="5" style="color:#ff0000;"> <table width="768" border="0" cellpadding="0" cellspacing="0">
  <tr> 
    <td width="580" style="color: #FFFF00; font: bold 15px; font-size: 14px; font-weight: bold;"><marquee onmouseout="this.start()" onmouseover=this.stop() scrollamount=3 align="middle">
            <%
			mysql="select count(*) as zts,cast(sum(CAST(预售面积 AS float)) as decimal(20,2)) as zmj from j_有效销售其他 where DATEDIFF(day, CAST(签订日期 AS DATETIME), GETDATE()) = 0"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            今日:新建商品房成交<%=Rs("zmj")%>平方米，成交套数<%=Rs("zts")%>套。 
            <%
			mysql="select count(*) as zzts,cast(sum(CAST(预售面积 AS float)) as decimal(20,2)) as zzmj from j_有效销售其他 where DATEDIFF(day, CAST(签订日期 AS DATETIME), GETDATE()) = 0 and 用途='住宅'"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            商品住房成交<%=Rs("zzmj")%>平方米 ，成交<%=Rs("zzts")%>套。 
            <%
			mysql="select count(*) as zzts1 from j_有效销售其他 where DATEDIFF(day, CAST(签订日期 AS DATETIME), GETDATE()) = 0 and 用途='住宅' and CAST(预售面积 AS float)>1 and CAST(预售面积 AS float)<=90"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            商品住房成交中：90平方米以下成交<%=Rs("zzts1")%>套。 
            <%
			mysql="select count(*) as zzts2 from j_有效销售其他 where DATEDIFF(day, CAST(签订日期 AS DATETIME), GETDATE()) = 0 and 用途='住宅' and CAST(预售面积 AS float)>90 and CAST(预售面积 AS float)<=120"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            90-120平方米成交<%=Rs("zzts2")%>套。 
            <%
			mysql="select count(*) as zzts3 from j_有效销售其他 where DATEDIFF(day, CAST(签订日期 AS DATETIME), GETDATE()) = 0 and 用途='住宅' and CAST(预售面积 AS float)>120 and CAST(预售面积 AS float)<=144"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            120-144平方米成交<%=Rs("zzts3")%>套。 
            <%
			mysql="select count(*) as zzts4 from j_有效销售其他 where DATEDIFF(day, CAST(签订日期 AS DATETIME), GETDATE()) = 0 and 用途='住宅' and CAST(预售面积 AS float)>144"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            144平方米以上成交<%=Rs("zzts4")%>套。 </marquee></td>
    <td width="188" align="center"><span id="position" style="color: #FFFF00; font: bold 15px; font-size: 15px; font-weight: bold;"> 
            <script>Time()</script>
            </span></td>
  </tr>
  <tr align="left"> 
    <td colspan="2"><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" width="760" height="8">
              <param name="movie" value="pmd.swf" />
              <param name="quality" value="high" />
              <embed src="pmd.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="760" height="8"></embed></object></td>
  </tr>
</table></td>
  </tr>
  <tr> 
    <td width="305" align="center" valign="top"> 
      <%
			mysql="select * from 今日成交"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
			if rs.eof then '判断是文件夹还是文件目录
			   rs.close
			   mysql="select * from 昨日成交"
			   Rs.Open mySql,conn,1,1
			end if
			'response.write mysql
	Rs.MoveFirst	'回滚	
	Rs.pagesize = 14  '设置纪录的page属性
	MaxPage = cint(Rs.pagecount) '取纪录的最大page属性
	MaxRecords = Rs.Recordcount '取最大纪录
	j=0
if int(Request.Cookies("UserVisit")("rcount"))>MaxPage then
  Response.Cookies("UserVisit")("rcount")="1"
  Myp=1
else
   Myp=Request.Cookies("UserVisit")("rcount")
end if
	Rs.Absolutepage = Myp '设置纪录的活动页 
%>
      <table width="300" border="0" cellspacing="0" cellpadding="0">
        <tr align="center"> 
          <td height="20" colspan="5" align="left" class="hong"><strong>今日已签商品房和存量房</strong></td>
        </tr>
      </table>
      <table width="300" border="0" cellspacing="0" cellpadding="0" class="abs">
        <tr align="center"> 
          <td width="102" class="abslv">楼盘名称</td>
          <td width="120" class="abslv">地址</td>
          <td width="36" class="abslv">用途</td>
          <td width="40" class="abslv">面积</td>
        </tr>
        <%Do while not Rs.eof  and j<Rs.pagesize  '分页		%>
        <tr align="center"> 
          <td class="abslv"><%=left(Rs("开发项目名称"),8)%></td>
          <td class="abslv"><%=left(Rs("项目地址"),9)%></td>
          <td class="abslv"><%=Rs("yt")%></td>
          <td class="abslv"><%=Rs("预售面积")%></td>
        </tr>
        <%
     		      Rs.MoveNext   
		          j = j+1  '分页 
   		       Loop
		       %>
        <%if j<14 then'增加空行补充
		      for i=1 to 14-j %>
        <tr align="center"> 
          <td class="abslv">　</td>
          <td class="abslv"></td>
          <td class="abslv"></td>
          <td class="abslv"></td>
        </tr>
        <%
		     next
		 end if%>
      </table></td>
    <td width="5">&nbsp;</td>
    <td colspan="3" align="left" valign="top"> <table width="458" border="0" cellspacing="0" cellpadding="0">
        <tr align="center"> 
          <td height="20" colspan="5" align="left" class="hong"><strong>出售房源　　　　　(以下房源信息来源于岳阳房地产信息网xx.yyfdcw.com)</strong></td>
        </tr>
      </table>
      <%
ESFconstr="driver={SQL Server};server=192.168.5.253\YYFDCW;initial Catalog=yyfcj_xxw_data;User ID=yyfcj;Password=yyfcj_gov_cn2012"
set ESFconn=server.createobject("adodb.connection")
ESFconn.Open ESFconstr
			mysql="SELECT top 360 Address, Construction, FloorNum, MaxFloor, Price, Phone, Linker,SScribeTime FROM Al_ES_Sale where isdel=0 order by sscribetime desc"
			Set Ks = Server.CreateObject("Adodb.RecordSet")
			Ks.Open mySql,ESFconn,1,1
			if Ks.eof then '判断是文件夹还是文件目录
			   Ks.close
			   mysql="SELECT top 360 * FROM Al_ES_Sale where isdel=0 order by sscribetime desc"
			   Ks.Open mySql,ESFconn,1,1
			end if
			'response.write mysql
	Ks.MoveFirst	'回滚	
	Ks.pagesize = 7  '设置纪录的page属性
	KMaxPage = cint(Ks.pagecount) '取纪录的最大page属性
	KMaxRecords = Ks.Recordcount '取最大纪录
	k=0
if int(Request.Cookies("UserVisit")("kcount"))>KMaxPage then
  Response.Cookies("UserVisit")("kcount")="1"
  KMyp=1
else
   KMyp=Request.Cookies("UserVisit")("kcount")
end if
	Ks.Absolutepage = KMyp
%>
      <table width="450" border="0" cellspacing="0" cellpadding="0" class="abs">
        <tr align="center"> 
          <td width="169" class="abslv">地址</td>
          <td width="42" class="abslv">面积</td>
          <td width="60" class="abslv">总价(万)</td>
          <td width="58" class="abslv">楼层</td>
          <td width="45" class="abslv">联系人</td>
          <td width="74" class="abslv">电话</td>
        </tr>
        <%Do while not Ks.eof  and K<Ks.pagesize  '分页		%>
        <tr align="center"> 
          <td class="abslv"><%=left(Ks("Address"),13)%></td>
          <td class="abslv"><%=Ks("Construction")%></td>
          <td class="abslv"><%if Ks("Price")="0" then 
		  response.write "面议" 
		  elseif ks("Price")<900 then 
		  response.write Ks("Price") 
		  else 
		  response.write FormatNumber(Ks("Price")/10000,2,-2)
		  end if
		  %>
		  </td>
          <td class="abslv"><%=Ks("FloorNum")%>/<%=Ks("MaxFloor")%></td>
          <td class="abslv"><%=left(Ks("Linker"),3)%></td>
          <td class="abslv"><%=left(Ks("Phone"),12)%></td>
        </tr>
        <%
     		      Ks.MoveNext   
		          K = K+1  '分页 
   		       Loop
		       %>
        <%if k<7 then'增加空行补充
		      for i=1 to 7-k %>
        <tr align="center"> 
          <td class="abslv">　</td>
          <td class="abslv">　</td>
          <td class="abslv">　</td>
          <td class="abslv">　</td>
          <td class="abslv">　</td>
          <td class="abslv">　</td>
        </tr>
        <%
		     next
		 end if%>
      </table>
      <table width="458" border="0" cellspacing="0" cellpadding="0">
        <tr align="center"> 
          <td height="20" colspan="5" align="left" class="hong"><strong>出租房源</strong></td>
        </tr>
      </table>
<%
			mysql="select top 360 * from Al_ES_Rent where isdel=0 order by updatetime desc"
			Set Ts = Server.CreateObject("Adodb.RecordSet")
			Ts.Open mySql,ESFconn,1,1
			if Ts.eof then '判断是文件夹还是文件目录
			   Ts.close
			   mysql="select top 360 * from Al_ES_Rent where isdel=0 order by updatetime desc"
			   Ts.Open mySql,ESFconn,1,1
			end if
			'response.write mysql
	Ts.MoveFirst	'回滚	
	Ts.pagesize = 5  '设置纪录的page属性
	TMaxPage = cint(Ts.pagecount) '取纪录的最大page属性
	TMaxRecords = Ts.Recordcount '取最大纪录
	k=0
if int(Request.Cookies("UserVisit")("tcount"))>TMaxPage then
  Response.Cookies("UserVisit")("tcount")="1"
  TMyp=1
else
   TMyp=Request.Cookies("UserVisit")("tcount")
end if
	Ts.Absolutepage = TMyp '设置纪录的活动页 
%>
      <table width="450" border="0" cellspacing="0" cellpadding="0" class="abs">
        <tr align="center"> 
          <td width="169" class="abslv">地址</td>
          <td width="42" class="abslv">面积</td>
          <td width="60" class="abslv">月租金</td>
          <td width="58" class="abslv">楼层</td>
          <td width="45" class="abslv">联系人</td>
          <td width="74" class="abslv">电话</td>
        </tr>
        <%Do while not Ts.eof  and t<Ts.pagesize  '分页		%>
        <tr align="center"> 
          <td class="abslv"><%=left(Ts("Address"),13)%></td>
          <td class="abslv"><%=Ts("Construction")%></td>
          <td class="abslv"><%if Ts("Price")="0" then response.write "面议" else response.write Ts("Price")%></td>
          <td class="abslv"><%=Ts("FloorNum")%>/<%=Ts("MaxFloor")%></td>
          <td class="abslv"><%=left(Ts("Linker"),3)%></td>
          <td class="abslv"><%=left(Ts("Phone"),12)%></td>
        </tr>
        <%
     		      Ts.MoveNext   
		          t = t+1  '分页 
   		       Loop
		       %>
        <%if t<5 then'增加空行补充
		      for i=1 to 5-t %>
        <tr align="center"> 
          <td class="abslv">　</td>
          <td class="abslv">　</td>
          <td class="abslv">　</td>
          <td class="abslv">　</td>
          <td class="abslv">　</td>
          <td class="abslv">　</td>
        </tr>
        <%
		     next
		 end if%>
      </table></td>
  </tr>
</table>
<%
rs.close
ks.close
ts.close

set rs=nothing
set ks=nothing
set ts=nothing

conn.close
ESFconn.close

set rs=nothing
set ks=nothing
set ts=nothing
%>
</body>
