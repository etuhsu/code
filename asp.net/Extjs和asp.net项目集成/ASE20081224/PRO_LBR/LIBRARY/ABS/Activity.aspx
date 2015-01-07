<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="Activity.aspx.cs"
    Inherits="Activity" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 0 60px; margin-top: 10px;" class="clearfix">
        <div class="mainTableP2">
            <div class="divLeft">
                <%=WebUtility.GetActivityString() %>
            </div>
            <div class="divRight newsDetail2">
                <div style="overflow: hidden; width: 575px; height: auto">
                    <p>
                        <strong class="fontTT">
                            <%=strTitle %>
                        </strong>
                        <br>
                        <br>
                        <%=strContent %>
                    </p>
                </div>
            </div>
            <div style="clear: both; display: block; font: 0px Sans-Serif">
            </div>
        </div>
    </div>
</asp:Content>
