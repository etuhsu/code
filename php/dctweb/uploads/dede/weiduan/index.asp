<%
'ǿ����������·��ʷ���������ҳ�棬�����Ǵӻ����ȡҳ��
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
<title>�ޱ����ĵ�</title>
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
if Request.Cookies("UserVisit")("kcount")="" then   '����Cookie������
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
    <td align="center" valign="bottom" ><span style="color: #FF0000; font: bold; font-size: 23px; font-weight: bold; letter-spacing: 8px;">�����з��ز�������Ϣ����ƽ̨</span></td>
  </tr>
</table>
<table width="760" height="384" border="0" cellpadding="0" cellspacing="0" bgcolor="#000000">
  <tr> 
    <td height="30" colspan="5" style="color:#ff0000;"> <table width="768" border="0" cellpadding="0" cellspacing="0">
  <tr> 
    <td width="580" style="color: #FFFF00; font: bold 15px; font-size: 14px; font-weight: bold;"><marquee onmouseout="this.start()" onmouseover=this.stop() scrollamount=3 align="middle">
            <%
			mysql="select count(*) as zts,cast(sum(CAST(Ԥ����� AS float)) as decimal(20,2)) as zmj from j_��Ч�������� where DATEDIFF(day, CAST(ǩ������ AS DATETIME), GETDATE()) = 0"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            ����:�½���Ʒ���ɽ�<%=Rs("zmj")%>ƽ���ף��ɽ�����<%=Rs("zts")%>�ס� 
            <%
			mysql="select count(*) as zzts,cast(sum(CAST(Ԥ����� AS float)) as decimal(20,2)) as zzmj from j_��Ч�������� where DATEDIFF(day, CAST(ǩ������ AS DATETIME), GETDATE()) = 0 and ��;='סլ'"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            ��Ʒס���ɽ�<%=Rs("zzmj")%>ƽ���� ���ɽ�<%=Rs("zzts")%>�ס� 
            <%
			mysql="select count(*) as zzts1 from j_��Ч�������� where DATEDIFF(day, CAST(ǩ������ AS DATETIME), GETDATE()) = 0 and ��;='סլ' and CAST(Ԥ����� AS float)>1 and CAST(Ԥ����� AS float)<=90"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            ��Ʒס���ɽ��У�90ƽ�������³ɽ�<%=Rs("zzts1")%>�ס� 
            <%
			mysql="select count(*) as zzts2 from j_��Ч�������� where DATEDIFF(day, CAST(ǩ������ AS DATETIME), GETDATE()) = 0 and ��;='סլ' and CAST(Ԥ����� AS float)>90 and CAST(Ԥ����� AS float)<=120"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            90-120ƽ���׳ɽ�<%=Rs("zzts2")%>�ס� 
            <%
			mysql="select count(*) as zzts3 from j_��Ч�������� where DATEDIFF(day, CAST(ǩ������ AS DATETIME), GETDATE()) = 0 and ��;='סլ' and CAST(Ԥ����� AS float)>120 and CAST(Ԥ����� AS float)<=144"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            120-144ƽ���׳ɽ�<%=Rs("zzts3")%>�ס� 
            <%
			mysql="select count(*) as zzts4 from j_��Ч�������� where DATEDIFF(day, CAST(ǩ������ AS DATETIME), GETDATE()) = 0 and ��;='סլ' and CAST(Ԥ����� AS float)>144"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
%>
            144ƽ�������ϳɽ�<%=Rs("zzts4")%>�ס� </marquee></td>
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
			mysql="select * from ���ճɽ�"
			Set Rs = Server.CreateObject("Adodb.RecordSet")
			Rs.Open mySql,conn,1,1
			if rs.eof then '�ж����ļ��л����ļ�Ŀ¼
			   rs.close
			   mysql="select * from ���ճɽ�"
			   Rs.Open mySql,conn,1,1
			end if
			'response.write mysql
	Rs.MoveFirst	'�ع�	
	Rs.pagesize = 14  '���ü�¼��page����
	MaxPage = cint(Rs.pagecount) 'ȡ��¼�����page����
	MaxRecords = Rs.Recordcount 'ȡ����¼
	j=0
if int(Request.Cookies("UserVisit")("rcount"))>MaxPage then
  Response.Cookies("UserVisit")("rcount")="1"
  Myp=1
else
   Myp=Request.Cookies("UserVisit")("rcount")
end if
	Rs.Absolutepage = Myp '���ü�¼�Ļҳ 
%>
      <table width="300" border="0" cellspacing="0" cellpadding="0">
        <tr align="center"> 
          <td height="20" colspan="5" align="left" class="hong"><strong>������ǩ��Ʒ���ʹ�����</strong></td>
        </tr>
      </table>
      <table width="300" border="0" cellspacing="0" cellpadding="0" class="abs">
        <tr align="center"> 
          <td width="102" class="abslv">¥������</td>
          <td width="120" class="abslv">��ַ</td>
          <td width="36" class="abslv">��;</td>
          <td width="40" class="abslv">���</td>
        </tr>
        <%Do while not Rs.eof  and j<Rs.pagesize  '��ҳ		%>
        <tr align="center"> 
          <td class="abslv"><%=left(Rs("������Ŀ����"),8)%></td>
          <td class="abslv"><%=left(Rs("��Ŀ��ַ"),9)%></td>
          <td class="abslv"><%=Rs("yt")%></td>
          <td class="abslv"><%=Rs("Ԥ�����")%></td>
        </tr>
        <%
     		      Rs.MoveNext   
		          j = j+1  '��ҳ 
   		       Loop
		       %>
        <%if j<14 then'���ӿ��в���
		      for i=1 to 14-j %>
        <tr align="center"> 
          <td class="abslv">��</td>
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
          <td height="20" colspan="5" align="left" class="hong"><strong>���۷�Դ����������(���·�Դ��Ϣ��Դ���������ز���Ϣ��xx.yyfdcw.com)</strong></td>
        </tr>
      </table>
      <%
ESFconstr="driver={SQL Server};server=192.168.5.253\YYFDCW;initial Catalog=yyfcj_xxw_data;User ID=yyfcj;Password=yyfcj_gov_cn2012"
set ESFconn=server.createobject("adodb.connection")
ESFconn.Open ESFconstr
			mysql="SELECT top 360 Address, Construction, FloorNum, MaxFloor, Price, Phone, Linker,SScribeTime FROM Al_ES_Sale where isdel=0 order by sscribetime desc"
			Set Ks = Server.CreateObject("Adodb.RecordSet")
			Ks.Open mySql,ESFconn,1,1
			if Ks.eof then '�ж����ļ��л����ļ�Ŀ¼
			   Ks.close
			   mysql="SELECT top 360 * FROM Al_ES_Sale where isdel=0 order by sscribetime desc"
			   Ks.Open mySql,ESFconn,1,1
			end if
			'response.write mysql
	Ks.MoveFirst	'�ع�	
	Ks.pagesize = 7  '���ü�¼��page����
	KMaxPage = cint(Ks.pagecount) 'ȡ��¼�����page����
	KMaxRecords = Ks.Recordcount 'ȡ����¼
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
          <td width="169" class="abslv">��ַ</td>
          <td width="42" class="abslv">���</td>
          <td width="60" class="abslv">�ܼ�(��)</td>
          <td width="58" class="abslv">¥��</td>
          <td width="45" class="abslv">��ϵ��</td>
          <td width="74" class="abslv">�绰</td>
        </tr>
        <%Do while not Ks.eof  and K<Ks.pagesize  '��ҳ		%>
        <tr align="center"> 
          <td class="abslv"><%=left(Ks("Address"),13)%></td>
          <td class="abslv"><%=Ks("Construction")%></td>
          <td class="abslv"><%if Ks("Price")="0" then 
		  response.write "����" 
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
		          K = K+1  '��ҳ 
   		       Loop
		       %>
        <%if k<7 then'���ӿ��в���
		      for i=1 to 7-k %>
        <tr align="center"> 
          <td class="abslv">��</td>
          <td class="abslv">��</td>
          <td class="abslv">��</td>
          <td class="abslv">��</td>
          <td class="abslv">��</td>
          <td class="abslv">��</td>
        </tr>
        <%
		     next
		 end if%>
      </table>
      <table width="458" border="0" cellspacing="0" cellpadding="0">
        <tr align="center"> 
          <td height="20" colspan="5" align="left" class="hong"><strong>���ⷿԴ</strong></td>
        </tr>
      </table>
<%
			mysql="select top 360 * from Al_ES_Rent where isdel=0 order by updatetime desc"
			Set Ts = Server.CreateObject("Adodb.RecordSet")
			Ts.Open mySql,ESFconn,1,1
			if Ts.eof then '�ж����ļ��л����ļ�Ŀ¼
			   Ts.close
			   mysql="select top 360 * from Al_ES_Rent where isdel=0 order by updatetime desc"
			   Ts.Open mySql,ESFconn,1,1
			end if
			'response.write mysql
	Ts.MoveFirst	'�ع�	
	Ts.pagesize = 5  '���ü�¼��page����
	TMaxPage = cint(Ts.pagecount) 'ȡ��¼�����page����
	TMaxRecords = Ts.Recordcount 'ȡ����¼
	k=0
if int(Request.Cookies("UserVisit")("tcount"))>TMaxPage then
  Response.Cookies("UserVisit")("tcount")="1"
  TMyp=1
else
   TMyp=Request.Cookies("UserVisit")("tcount")
end if
	Ts.Absolutepage = TMyp '���ü�¼�Ļҳ 
%>
      <table width="450" border="0" cellspacing="0" cellpadding="0" class="abs">
        <tr align="center"> 
          <td width="169" class="abslv">��ַ</td>
          <td width="42" class="abslv">���</td>
          <td width="60" class="abslv">�����</td>
          <td width="58" class="abslv">¥��</td>
          <td width="45" class="abslv">��ϵ��</td>
          <td width="74" class="abslv">�绰</td>
        </tr>
        <%Do while not Ts.eof  and t<Ts.pagesize  '��ҳ		%>
        <tr align="center"> 
          <td class="abslv"><%=left(Ts("Address"),13)%></td>
          <td class="abslv"><%=Ts("Construction")%></td>
          <td class="abslv"><%if Ts("Price")="0" then response.write "����" else response.write Ts("Price")%></td>
          <td class="abslv"><%=Ts("FloorNum")%>/<%=Ts("MaxFloor")%></td>
          <td class="abslv"><%=left(Ts("Linker"),3)%></td>
          <td class="abslv"><%=left(Ts("Phone"),12)%></td>
        </tr>
        <%
     		      Ts.MoveNext   
		          t = t+1  '��ҳ 
   		       Loop
		       %>
        <%if t<5 then'���ӿ��в���
		      for i=1 to 5-t %>
        <tr align="center"> 
          <td class="abslv">��</td>
          <td class="abslv">��</td>
          <td class="abslv">��</td>
          <td class="abslv">��</td>
          <td class="abslv">��</td>
          <td class="abslv">��</td>
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
