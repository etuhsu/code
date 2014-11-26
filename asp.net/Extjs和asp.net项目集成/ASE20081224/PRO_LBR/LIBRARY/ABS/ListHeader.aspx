<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="ListHeader.aspx.cs"
    Inherits="ListHeader" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content" class="clearfix">
        <%=WebUtility.GetLeftString() %>
        <div id="right-b">
            <div class="clearfix" style="margin-top:10px;">
                <%=ViewState["LST_IMAGE"].ToString() %>
            </div>
        </div>
    </div>
</asp:Content>
