<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="login">
<div class="in">
<table cellpadding="0" cellspacing="0" border="0"  >
<tr>
<td><img src="img_all/space.gif" width="160" height="1" /></td>
<td><img src="img/gan.jpg" width="64" height="66" /></td>
<td><img src="img_all/space.gif" width="40" height="1" /></td>
<td style="font-size: 15px; font-weight: bold; color: #000000;" width="406" align="left";><%=hf_error.Value %></td>
</tr>
</table>
</div>
</div>
    <asp:HiddenField ID="hf_error" runat="server" />
</asp:Content>

