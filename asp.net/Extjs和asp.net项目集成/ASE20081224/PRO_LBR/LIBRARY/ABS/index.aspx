<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs"
    Inherits="index" Title="Untitled Page" %>

<%@ Register TagPrefix="ResCt" TagName="CImageAd" Src="Control/CImageAd.ascx" %>
<%@ Register TagPrefix="ResCt" TagName="CImagePageCast" Src="~/Control/CImagePageCast.ascx" %>
<%@ Register TagPrefix="ResCt" TagName="CImagePageList" Src="~/Control/CImagePageList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="clearfix">
        <div id="pic" style="width: 900px; margin: 10px 0; border: 1px solid #666666;" class="clearfix">
            <div id="l">
                <ResCt:CImagePageCast ID="cpc_main" runat="server" />
            </div>
            <ResCt:CImageAd ID="Cia_main" runat="server" />
        </div>
        <ResCt:CImagePageList ID="cpl_main" runat="server" />
    </div>
</asp:Content>
