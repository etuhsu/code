<%@ page language="C#" autoeventwireup="true" inherits="Login, App_Web_hqr6mqoj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>酒店管理用户登录</title>
    <link href="/HotelUI/Ext/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <link href="Css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/HotelUI/Ext/adapter/ext/ext-base.js"></script>
    <script type="text/javascript" src="/HotelUI/Ext/ext-all.js"></script>
    <link href="/HotelUI/Css/newhead.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
   <form id="form1" runat="server">
    <TABLE cellSpacing=0 cellPadding=0 width=1004 border=0>
  <TR>
    <TD colSpan=6><IMG height=92 alt="" src="Images/login/crm_3.gif" 
    width=345></TD>
    <TD colSpan=4><IMG height=92 alt="" src="Images/login/crm_2.gif" 
    width=452></TD>
    <TD><IMG height=92 alt="" src="Images/login/crm_3.gif" width=207></TD></TR>
  <TR>
    <TD colSpan=6><IMG height=98 alt="" src="Images/login/crm_4.gif" 
    width=345></TD>
    <TD colSpan=4><IMG height=98 alt="" src="Images/login/crm_5.gif" 
    width=452></TD>
    <TD><IMG height=98 alt="" src="Images/login/crm_6.gif" width=207></TD></TR>
  <TR>
    <TD rowSpan=5><IMG height=370 alt="" src="Images/login/crm_7.gif" 
    width=59></TD>
    <TD colSpan=5><IMG height=80 alt="" src="Images/login/crm_8.gif" 
    width=286></TD>
    <TD colSpan=4><IMG height=80 alt="" src="Images/login/crm_9.gif" 
    width=452></TD>
    <TD><IMG height=80 alt="" src="Images/login/crm_10.gif" width=207></TD></TR>
  <TR>
    <TD><IMG height=110 alt="" src="Images/login/crm_11.gif" width=127></TD>
    <TD background=Images/login/crm_12.gif colSpan=6 align="center">
      <TABLE id=table1 cellSpacing=0 cellPadding=0 width="98%" 
      border=0>
        <TR>
          <TD>
			

            <TABLE id=table2 cellSpacing=1 cellPadding=0 width="100%" 
            border=0>
              <TBODY>
              <TR>
                <TD align=middle width=81><FONT color=#ffffff>用户名：</FONT></TD>
                <TD>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox></TD>
              </TR>
              <TR>
                <TD align=middle width=81><FONT 
                  color=#ffffff>密&nbsp; 码：</FONT></TD>
                <TD>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="152px"></asp:TextBox></TD>
              </TR>
				</TBODY></TABLE>
				</TD></TR></TABLE>
        </TD>
    <TD colSpan=2 rowSpan=2><IMG height=158 alt="" src="Images/login/crm_13.gif" 
      width=295></TD>
    <TD rowSpan=2><IMG height=158 alt="" src="Images/login/crm_14.gif" 
    width=207></TD></TR>

  <TR>
    <TD rowSpan=3><IMG height=180 alt="" src="Images/login/crm_15.gif" 
    width=127></TD>
    <TD rowSpan=3><IMG height=180 alt="" src="Images/login/crm_16.gif" 
    width=24></TD>
    <TD>
        <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="Images/login/crm_17.gif" OnClick="btnLogin_Click" /></TD>
    <TD><IMG height=48 alt="" src="Images/login/crm_18.gif" width=21></TD>
    <TD colSpan=2>
        <asp:ImageButton ID="btnOut" runat="server" ImageUrl="Images/login/crm_19.gif" OnClick="btnOut_Click" /><a href="Login.aspx"></a></TD>
    <TD><IMG height=48 alt="" src="Images/login/crm_20.gif" 
  width=101></TD></TR>
  <TR>
    <TD colSpan=5 rowSpan=2><IMG height=132 alt="" src="Images/login/crm_21.gif" 
      width=292></TD>
    <TD rowSpan=2><IMG height=132 alt="" src="Images/login/crm_22.gif" 
    width=170></TD>
    <TD colSpan=2><IMG height=75 alt="" src="Images/login/crm_23.gif" 
    width=332></TD></TR>
  <TR>
    <TD colSpan=2><IMG height=57 alt="" src="Images/login/crm_24.gif" 
    width=332></TD></TR>
  <TR>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=59></TD>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=127></TD>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=24></TD>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=86></TD>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=21></TD>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=28></TD>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=56></TD>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=101></TD>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=170></TD>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=125></TD>
    <TD><IMG height=1 alt="" src="images/admin/spacer.gif" width=207></TD>
  </TR>
  </TABLE>
    </form>
</body>
</html>
