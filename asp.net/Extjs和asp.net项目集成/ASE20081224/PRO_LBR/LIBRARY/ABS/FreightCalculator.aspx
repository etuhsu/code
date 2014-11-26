<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="FreightCalculator.aspx.cs"
    Inherits="FreightCalculator" Title="Untitled Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 0 60px; margin-top: 10px;" class="clearfix">
        <div class="mainTableP2">
            <div class="divLeft">
                <%=WebUtility.GetPurchaseLeftString() %>
            </div>
            <div class="divRight newsDetail2">
                <div style="overflow: hidden; width: 575px; height: auto">
                    <p>
                        <strong class="fontTT">运费计算器 </strong>
                        <br> 
                        <br>
                        商品重量：<asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>&nbsp; kg<asp:RequiredFieldValidator
                            ID="rfvWeight" runat="server" ControlToValidate="txtWeight" ErrorMessage="请输入商品重量！">*</asp:RequiredFieldValidator>
                        <br />
                        商品总值：<asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>&nbsp; 元<asp:RequiredFieldValidator
                            ID="rfvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="请输入商品总额！">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <contenttemplate>
送达城市：<asp:DropDownList id="ddlProvince" runat="server" DataValueField="PRV_ID" DataTextField="PRV_LOCALNAME" DataSourceID="sdsProvince" AutoPostBack="True">
                        </asp:DropDownList> <asp:DropDownList id="ddlCity" runat="server" DataValueField="CTY_ID" DataTextField="CTY_LOCALNAME" DataSourceID="sdsCity">
                        </asp:DropDownList> <asp:SqlDataSource id="sdsCity" runat="server" SelectCommand="SELECT CTY_ID,CTY_LOCALNAME FROM RCITY WHERE CTY_PRV_ID=@PRV_ID" ConnectionString="<%$ ConnectionStrings:SQLConnString %>">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlProvince" Name="PRV_ID" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource> <asp:SqlDataSource id="sdsProvince" runat="server" SelectCommand="SELECT PRV_ID,PRV_LOCALNAME FROM RPROVINCE" ConnectionString="<%$ ConnectionStrings:SQLConnString %>"></asp:SqlDataSource> <P>&nbsp;</P><P>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <asp:Button id="btnCalculate" onclick="btnCalculate_Click" runat="server" Text="计算"></asp:Button> </P>
                        </contenttemplate>
                                                    <triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnCalculate" EventName="Click"></asp:AsyncPostBackTrigger>
                        </triggers>
                                                </asp:UpdatePanel>
                        <p>
                            &nbsp;<p>
                                当商品总价小于300元时您需支付相应的运费，大于或等于300元时，上海地区免收运费，其他地区减收部分运费。</p>
                            <p>
                                &nbsp;</p>
                            <p>
                                &nbsp; &nbsp;&nbsp;
                                <asp:ValidationSummary ID="vsMessage" runat="server" />
                                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                    <contenttemplate>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
</contenttemplate>
                                </asp:UpdatePanel></p>
                </div>
            </div>
            <div style="clear: both; display: block; font: 0px Sans-Serif">
            </div>
        </div>
    </div>
</asp:Content>
