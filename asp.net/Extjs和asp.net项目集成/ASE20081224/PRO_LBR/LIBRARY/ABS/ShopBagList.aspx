<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="ShopBagList.aspx.cs" Inherits="ShopBagList" Title="Untitled Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type ="text/javascript">
 function checkSingle(checkObj)
 {
    var hiddenObj=document.getElementById("<% =hf_shopbag.ClientID %>");
    if(checkObj.checked)
    {
        //alert(checkObj.value);
        hiddenObj.value+=","+checkObj.value;
    }
    else
    {
        //alert("-"+checkObj.value);
        hiddenObj.value = hiddenObj.value.replace(","+checkObj.value,"");
    }
 }
</script>
<div style="padding: 0 60px; margin-top: 10px;">
    <div class=path><a href="index.aspx">首页</a> &gt;&gt; <a href="ShopBagList.aspx" id="font12">&nbsp; 我的购物车</a></div>
    <br />
    <div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
<asp:CustomValidator id="cvlid" runat="server"></asp:CustomValidator>
<asp:GridView id="gv_list" runat="server" OnRowDataBound="gv_list_RowDataBound" AutoGenerateColumns="False" Width="836px"
 DataKeyNames="SPB_ID" DataSourceID="sds_shopbag" OnRowUpdating="gv_list_RowUpdating" OnRowUpdated="gv_list_RowUpdated"
  PageSize="100" OnRowDeleted="gv_list_RowDeleted" CssClass="gridview_m" GridLines="None">
<Columns>
<asp:TemplateField><ItemTemplate>
                        <INPUT id="Checkbox2" onclick="checkSingle(this)" type="checkbox" value='<%# Eval("SPB_ID") %>' runat="server"/>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="名称"><EditItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("PRH_LOCALNAME") %>'></asp:Label>
                     
</EditItemTemplate>
<ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("PRH_LOCALNAME") %>'></asp:Label>
                     
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="属性"><EditItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("PRD_DESC") %>'></asp:Label>
                     
</EditItemTemplate>
<ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("PRD_DESC") %>'></asp:Label>
                     
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="价格"><EditItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Eval("PRD_MEMBER_PRICE","{0:C}") %>'></asp:Label>
                     
</EditItemTemplate>
<ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Eval("PRD_MEMBER_PRICE","{0:C}") %>'></asp:Label>
                     
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="数量"><EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SPB_QTY") %>'></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="请输入整数并且大于0" MaximumValue="999999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    
</EditItemTemplate>
<ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SPB_QTY") %>'></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="金额"><EditItemTemplate>
                         <asp:Label ID="Label5" runat="server" Text='<%# Eval("PRD_AMOUNT","{0:C}") %>'></asp:Label>
                     
</EditItemTemplate>
<ItemTemplate>
                         <asp:Label ID="Label5" runat="server" Text='<%# Eval("PRD_AMOUNT","{0:C}") %>'></asp:Label>
                     
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="状态"><EditItemTemplate>
<asp:Label id="Label6" runat="server" Text='<%# GetString(Eval("PRD_NUM")) %>'></asp:Label> 
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label6" runat="server" Text='<%# GetString(Eval("PRD_NUM")) %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowEditButton="True" HeaderText="操作"></asp:CommandField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Columns>

<RowStyle Height="26px"></RowStyle>
<EmptyDataTemplate>
                没有购物记录
            
</EmptyDataTemplate>

<HeaderStyle Font-Size="13px" Font-Names="宋体" Font-Bold="True"></HeaderStyle>
</asp:GridView> <asp:SqlDataSource id="sds_shopbag" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>" DeleteCommand="DELETE FROM WSHOPBAG WHERE SPB_ID=@original_SPB_ID AND SPB_PSP_ID=@SPB_PSP_ID AND SPB_STATUS=0" SelectCommand="PROC_WSHOPBAG_GETLIST" SelectCommandType="StoredProcedure" UpdateCommand="UPDATE WSHOPBAG SET SPB_QTY=@SPB_QTY WHERE SPB_ID=@original_SPB_ID AND SPB_PSP_ID=@SPB_PSP_ID AND SPB_STATUS=0" OldValuesParameterFormatString="original_{0}">
            <DeleteParameters>
                <asp:Parameter Name="original_SPB_ID" Type="Int32"/>
                <asp:ControlParameter ControlID="hf_uid"  Name="SPB_PSP_ID" PropertyName="Value"
                    Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="original_SPB_ID" Type="Int32"/>
                <asp:ControlParameter ControlID="hf_uid"  Name="SPB_PSP_ID" PropertyName="Value"
                    Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="hf_uid"  Name="SPB_PSP_ID" PropertyName="Value"
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource> 
</ContentTemplate>
        <Triggers>
<asp:AsyncPostBackTrigger ControlID="btn_clear" EventName="ServerClick"></asp:AsyncPostBackTrigger>
</Triggers>
        
       </asp:UpdatePanel>
        <table cellspacing=0 cellpadding=3 border=0 width="836px">
            <tr>
              <td align=left bgcolor=#f5f5f5 colspan=4 class="tdPadding"></td>
              <td align=center bgcolor=#f5f5f5 colspan=4 class="tdPadding">
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
                  <asp:Label runat="server" ID="lb_amount"></asp:Label>
                  </ContentTemplate>
              </asp:UpdatePanel>
                &nbsp;
                  </td>
            </tr>
            <tr>
              <td align="center" colspan=8>
              <span id=submitorder>
                <input class=button3  type=button value=" 清空购物车 " id="btn_clear" onserverclick="btn_clear_ServerClick" runat="server"/>
                &nbsp;&nbsp;
                <input class=button3 type=button value=" 继续购物 " id="btn_continu" onclick="history.back();" runat="server" onserverclick="btn_continu_ServerClick"/>
                &nbsp;&nbsp;
                <input class=button3  type=button value=" 生成订单 " id="btn_createorder" runat="server" onserverclick="btn_createorder_ServerClick" />
                </span></td>
            </tr>
      </table>
      <table cellspacing=0 cellpadding=8 width="100%" border=0>
        <tbody>
          <tr>
            <td align=left><strong>提示：</strong><br />
              1. 
              如果您选择了缺货的商品，我们将无法在正常的承诺时间内将订单送到您处，您可能需要等待一定的时间。 <br />
              2. 
              单笔交易，当商品总价小于300元时您需支付相应的运费，大于或等于300元时，上海地区免收运费，其他地区减收部分运费。商品一般三天内送达，天气或其它不可抗力因素除外。<br />
              3. 
              以上各项优惠活动只能参与一次不能重复参加，如需咨询祥情欢迎拨打购物热线400-820-5077。<br />
              <br />
              <strong>购物流程：</strong> 选择商品 → <span class=blue>提交购物车</span> → 输入送货信息 → 选择付款方式 → 提交订单 → 
              提交成功<br />
              &nbsp;<br /></td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
    <asp:HiddenField ID="hf_uid" runat="server" />
    <asp:HiddenField ID="hf_shopbag" runat="server" />
</asp:Content>

