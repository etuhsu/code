<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="SingleHeader.aspx.cs"
    Inherits="SingleHeader" Title="Untitled Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
    function openwin()
    {
        var win="BigPicture.aspx?imgUrl="+document.getElementById("ctl00_ContentPlaceHolder1_hddImg").value;
        window.open(win,"查看产品大图","height=600,width=800,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no,title=no");
    }
    function addBookmark(title,url) {
        if (window.sidebar) { 
            window.sidebar.addPanel(title, url,""); 
        } 
        else if( document.all ) {
            window.external.AddFavorite( url, title);
        } 
        else if( window.opera && window.print ) {
            return true;
        }
    }
    </script>

    <asp:UpdatePanel id="upPanelTop" runat="server">
   <contenttemplate>
    <!--路径-->
    <div id="path">
        <asp:HyperLink ID="hlkLineName" runat="server">
            <asp:Literal ID="ltrLineName" runat="server"></asp:Literal></asp:HyperLink>&nbsp;&gt;&nbsp;
        <asp:HyperLink ID="hlkLineName1" runat="server">
            <asp:Literal ID="ltrLineName1" runat="server"></asp:Literal></asp:HyperLink>&nbsp;&gt;&nbsp;
        <asp:HyperLink ID="hlkCategoryName" runat="server">
            <asp:Literal ID="ltrCategoryName" runat="server"></asp:Literal></asp:HyperLink>&nbsp;&gt;&nbsp;
        <a id="font12">
            <asp:Literal ID="ltrHeaderName" runat="server"></asp:Literal></a><asp:HiddenField
                ID="hf_prh_id" runat="server" />
    </div>
    <div id="content" class="clearfix">
        <div id="main-left">
            <div>
                <asp:HiddenField ID="hddImg" runat="server"></asp:HiddenField>
                <asp:Image ID="img_main" Width="383" Height="344" runat="server" /></div>
            <div>
                <a href="#" onclick="openwin()">
                    <img src="img_all/big.gif" width="86" height="25" border="0" /></a></div>
            <div>
                <img src="img_all/add.gif" width="12" height="12" />&nbsp;<a href="javascript:addBookmark('www.abs.cn',this.location.href)">加入收藏夹</a>&nbsp;&nbsp;
                <asp:LinkButton ID="lnkBtnRecomandToFriend" runat="server" OnClick="lnkBtnRecomandToFriend_Click">
                <img src="img_all/ico_email.gif" width="12" height="10" />&nbsp;推荐给好友
                </asp:LinkButton></div>
        </div>
        <div id="main-right">
            <div id="font-top">
                <asp:Label ID="lb_main_name" runat="server"></asp:Label></div>
            <p>
                描述<br />
                <asp:Label ID="lb_content" runat="server"></asp:Label></p>
            <div class="clearfix" id="divPrice" runat="server">
                <div id="tab-top">
                    产品编码：<asp:Label ID="lb_main_code" runat="server"></asp:Label><br />
                    规格描述：<asp:Label ID="lb_spec_desc" runat="server"></asp:Label><br />
                    <asp:Label ID="lb_main_market_price" runat="server"></asp:Label><span class="font14_red"><asp:Label
                        ID="lb_main_member_price" runat="server"></asp:Label></span>&nbsp;&nbsp;<img src="img/az-shopping-cart.gif"
                            width="29" height="21" />
                    <asp:Label ID="lb_main_repertory" runat="server"></asp:Label></div>
            </div>
            <div class="clearfix" id="tab-middle">
                <div>
                    选择颜色：</div>
                <asp:Repeater ID="rptColor" runat="server" DataSourceID="sdsColor" OnItemCommand="rptColor_ItemCommand">
                    <HeaderTemplate>
                        <div style="margin: 10px 0;">
                            <ul class="ula">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:ImageButton ID="IBtn_main_color" BorderColor="red" BorderWidth="1" runat="server"
                                CommandArgument='<%#Eval("PRD_COLOR") %>' CommandName="Color" ImageUrl='<%# GetFile(Eval("PRD_COLOR_PIC")) %>'
                                AlternateText='<%# Eval("PRD_COLOR") %>' Width="30px" Height="30px" />
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul> </div>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HiddenField ID="hf_main_color" runat="server" />
                <asp:HiddenField ID="hf_main_prd_id" runat="server" />
                <asp:SqlDataSource ID="sdsColor" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>"
                    SelectCommand="SELECT DISTINCT [PRD_COLOR], [PRD_COLOR_PIC] FROM [BPRODUCT] WHERE ([PRD_PRH_ID] = @PRD_PRH_ID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hf_prh_id" Name="PRD_PRH_ID" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <div>
                    选择尺寸：<asp:DropDownList ID="ddlSize" runat="server" OnDataBound="ddlSize_DataBound"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlSize_SelectedIndexChanged">
                        <asp:ListItem Value="0">--请选择尺寸--</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div id="tab-bottom">
                颜色：<asp:Label ID="lblColor" runat="server"></asp:Label><br />
                尺寸：<asp:Label ID="lblSize" runat="server"></asp:Label><br />
                数量：<input size="6" class="text1" name="userName" value="1" id="edt_main_num" runat="server" />件&nbsp;&nbsp;&nbsp;<asp:CustomValidator
                    ID="cv_main" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator></div>
            <div style="margin-top: 65px; text-align: right;">
                <input id="btnBuyNow" class="button3" type="button" value=" 立即购买 " runat="server"
                    onserverclick="btnBuyNow_ServerClick" />&nbsp;&nbsp;&nbsp;
                <input id="btnAddToCart" class="button3" type="button" value=" 放入购物车 " onserverclick="btnAddToCart_ServerClick"
                    runat="server" /></div>
        </div>
    </div>
    <div id="maincol">
        <div id="main-tit">
            <img src="img/page04_07.gif" width="55" height="14" /></div>
        <div id="subcol">
            <div id="subline-left" class="clearfix">
                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:ImageButton ID="imgBtnLink" CommandName="Link" CommandArgument='<%#Eval("PRH_ID") %>'
                                ImageUrl='<%# GetFile(Eval("PRH_PIC1")) %>' AlternateText='<%#Eval("PRH_LOCALNAME") %>'
                                Width="120" Height="120" runat="server" />
                            <p>
                                <%#Eval("PRH_LOCALNAME") %>
                            </p>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div id="subline-bottom">
        </div>
    </div>
    
   </contenttemplate>
    </asp:UpdatePanel>

</asp:Content>
