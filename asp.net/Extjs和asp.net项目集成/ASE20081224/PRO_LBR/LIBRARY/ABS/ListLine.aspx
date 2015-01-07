<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="ListLine.aspx.cs" Inherits="ListLine" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="clearfix">
<%=WebUtility.GetLeftString()%>
<div id="right">
<%=ViewState["IMAGE_STR"].ToString()%>
<div id="list"><p><%=Request.QueryString["prl_name"] %></p></div>
	<div id="show" class="clearfix">
		<%=ViewState["LST_IMAGE"].ToString() %>
	</div>
</div>
</div>
</asp:Content>

