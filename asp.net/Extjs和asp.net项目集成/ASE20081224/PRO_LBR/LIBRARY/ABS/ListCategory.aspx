<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="ListCategory.aspx.cs" Inherits="ListCategory" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content" class="clearfix">
<%=WebUtility.GetLeftString()%>
<div id="right">
		<%=ViewState["IMAGE_STR"].ToString() %>
		<div id="list">
		  <p>时尚床品系列</p>
		</div>
		<div id="show" class="clearfix">
			<%=ViewState["LST_IMAGE"].ToString()%>
		</div>
	</div>
</div>
</asp:Content>

