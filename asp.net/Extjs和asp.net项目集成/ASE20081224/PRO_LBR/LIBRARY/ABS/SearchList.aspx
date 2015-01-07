<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="SearchList.aspx.cs" Inherits="SearchList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
function showMore()
{
    var div=document.getElementById("div_more");
    if(div.style.display=="none")
        div.style.display="block";
    else
        div.style.display="none";
}
</script>
<div id="login">
<div class="in">
<table cellpadding="0" cellspacing="0" border="0" width="100%">
<tr>
	<td align="right" width="15%" style="height: 18px">关键字：&nbsp;&nbsp;</td>
	<td align="left" style="width: 31%; height: 18px;"><asp:TextBox ID="edt_keyword" runat="server" Width="270px" CssClass="text1" MaxLength="50"></asp:TextBox></td>
	<td align="right" width="15%" style="height: 18px">价格区间：&nbsp;&nbsp;</td>
	<td align="left" width="25%" style="height: 18px"><asp:TextBox ID="edt_begin_num" runat="server" CssClass="text1" Width="50"></asp:TextBox>&nbsp;至&nbsp;
	<asp:TextBox ID="edt_end_num" runat="server" CssClass="text1" Width="50"></asp:TextBox>
        &nbsp;
        </td>
	<td width="10%" style="height: 18px"><input class=button1 type=submit value=" 确 认 " name=Submit id="btn_search" runat="server" onserverclick="btn_search_ServerClick" /></td>
</tr>
<tr>
	<td align="right" width="15%" style="height: 18px"><asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="edt_begin_num"
            ErrorMessage="必须输入金额" MaximumValue="9999999" MinimumValue="0" Type="Currency"></asp:RangeValidator>
        </td>
	<td align="left" style="width: 31%; height: 18px;">
        <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="edt_end_num"
            ErrorMessage="必须输入金额" MaximumValue="9999999" MinimumValue="0" Type="Currency"></asp:RangeValidator></td>
	<td align="right" width="15%" style="height: 18px"></td>
	<td align="left" width="25%" style="height: 18px">
        </td>
	<td width="10%" style="height: 18px"></td>
</tr>
</table>
</div>

<asp:Repeater ID="rp_list" runat="server" >
<ItemTemplate>
    <div class="lie">
    <table cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td width="120"><a href='SingleHeader.aspx?prh_id=<%# Eval("PRH_ID")%>'><img src='<%# GetFile(Eval("PRD_PIC1"))%>' width="120" height="120" border="0" /></a></td>
    <td width="20"><img src="img_all/space.gif" width="20" height="1" /></td>
    <td width="340" valign="middle" class="listProT1"><a href='SingleHeader.aspx?prh_id=<%# Eval("PRH_ID")%>'><%# Eval("PRD_LOCALNAME") %></a></BR>描述：<%# Eval("PRH_DESC") %></td>
    <td><img src="img_all/space.gif" width="50" height="1" /></td>
    <td width="114" valign="middle" align="left">市场价:<%# Eval("PRD_MARKET_PRICE","{0:C}") %><br />ABS价:<span class="STYLE2"><%# Eval("PRD_MEMBER_PRICE","{0:C}") %></span><br />
    <img src="img/az-shopping-cart.gif" width="29" height="21" /><%# GetRepertory(Eval("XPR_NUM"))%></td>
    </tr>
    </table>
    </div>
</ItemTemplate>
<FooterTemplate>
</FooterTemplate>
</asp:Repeater>
<%=next_str%>
</div>
</asp:Content>

