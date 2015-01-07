<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="BaseInfo.aspx.cs"
    Inherits="BaseInfo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="padding: 0 45px; margin-top: 10px;" class="clearfix">
    <div class="divLeft">
        <%=WebUtility.GetPurchaseLeftString() %>
    </div>
    <div class="divRight newsDetail2">
        <div style="overflow: hidden; width: 575px; height: auto">
            <p>
                <strong class="fontTT">
                    <%=strTitle %>
                </strong><a id="a" name="a"></a>
                <br>
                <br>
                <%=strContent %>
            </p>
        </div>
    </div>
</div>
</asp:Content>
