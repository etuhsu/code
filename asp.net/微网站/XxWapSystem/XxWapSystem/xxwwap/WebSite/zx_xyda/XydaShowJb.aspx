<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XydaShowJb.aspx.cs" Inherits="XxWapSystem.zx_xyda.XydaShowJb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta content="IE=11.0000" http-equiv="X-UA-Compatible">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no">
    <meta name="format-detection" content="telephone=no">
    <title>�������ز�װ���� ���ű���</title>
    <meta name="keywords" content="�������ز�װ����,����װ��,����װ�޹�˾,��������,�����Ҿ�,���ʦ,װ����Ʒ,װ���ռ�,�����Ź�" />
    <meta name="description" content="�������ز�װ��������������Ψһһ��ר�Ŵ���װ����Ϣ���������ý�塣Ϊ���ṩ���µ���ҵ��̬�ʹ�����Ϣ����ȫ��װ�޽��ġ���Ȩ������ҵ���º����õ������������ز�װ����������Ϊ����װ����ҵ��Ȩ���Ĺ���ý�塣" />
    <meta name="apple-mobile-web-app-title" content="�������ز�װ����">
    <meta name="apple-mobile-web-app-capable" content="yes">

    <script src="../js/jquery.js"></script>

    <script src="../js/common.js"></script>

    <link rel="stylesheet" type="text/css" href="../css/v2.css" />
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <link rel="stylesheet" type="text/css" href="../css/base.css" />

    <script type="text/javascript">
        var appdowntip = getCookie('appdowntip');
        var closetip = getCookie('closetip');
        if (navigator.cookieEnabled && appdowntip == null) {
            //document.write('<meta name="apple-itunes-app" content="app-id=543472063">');
            //setCookie('appdowntip',true);
        }
        $(document).ready(function() {
            var apppop = getCookie('apppop');
            if (navigator.cookieEnabled && apppop == null) {
                setCookie('apppop', true);
                //$("#app_downloads").show();
                $("#app_downloads").css("width", document.body.clientWidth);
                $("#app_downloads").css("height", document.body.clientHeight);
                $(".turn_off").click(function() {
                    //$("#app_downloads").hide();
                });
                $(".no_download").click(function() {
                    //$("#app_downloads").hide();
                });
            }
            //get_location();
        });
    </script>

    <link href="../images/apple-touch-icon.png" rel="apple-touch-icon" sizes="144x144">
</head>
<body>
    <div class="app-download-bar" id="app-download-bar" style="display: none;">
        <a id="btn_app_down" href="http://app.house365.com/taofang/?channel=cptfxz" target="_blank">
        </a><span class="downtxt fr" id="closetip">�ر�</span>
    </div>
    <div class="app-open-bar" id="app-open-bar" style="display: none;">
        <span class="open_close" id="app_open_close"></span><span class="open_icon"></span>
        <span class="open_alt">���������ʡ����</span> <span class="opentxt fr" id="openapp">������</span>
    </div>
    <!--ͷ��LOGO-->
    <header class="m_wrap"><SECTION class="topnav_tool" 
id="topbar"><BUTTON class="top_btn" id="btn_back">����</BUTTON> 
<H1>������װ��װ����ҵ������� </H1>
</SECTION></header>
    <!--������Ϣ-->
    <div class="news-wrap">
        <div class="info_h2">
            <span class="info_h2_title">������Ϣ</span><span class="info_h2_more" id="info_box_project_info_btn">����<i
                class="icon_up"></i></span></div>
        <div class="info_box" id="info_box_project_info">
            <div class="info_content">
                <table class="white_title_big" border="0" cellspacing="1" width="100%">
                    <tbody>
                        <tr>
                            <td bgcolor="#ffffff" align="right" width="50%">
                                ��ҵ���ƣ�&nbsp;
                            </td>
                            <td width="50%">
                                <%=cqyname%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                ���õȼ���&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=ccredit%>���÷�ֵ<%=icreditvalue%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                ���ʵȼ���&nbsp;
                            </td>
                            <td>
                                <%=cgrade%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                ������&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=caddress%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                ��ҵ��ַ��&nbsp;
                            </td>
                            <td>
                                <%=caddress%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                Ӫҵִ��ע��ţ�&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=cyyzch%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                ����֤���ţ�&nbsp;
                            </td>
                            <td>
                                <%=czzbh %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                ��֯��������֤��&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=czzjg %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                ˰��Ǽ�֤��&nbsp;
                            </td>
                            <td>
                                <%=cswdj %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                ע���ʱ���&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=izczb %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                ��ҵ���ͣ�&nbsp;
                            </td>
                            <td>
                                <%=ctype %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                ��˾����ʱ�䣺&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=dCreateTime %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                ��ϵ�绰��&nbsp;
                            </td>
                            <td>
                                <%=ctel %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                ���������ˣ�&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=ccor %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                ��ҵ����&nbsp;
                            </td>
                            <td>
                                <%=cqyjl %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                ��Ա������&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=iryzs %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                רҵ������Ա����&nbsp;
                            </td>
                            <td>
                                <%=izyzs %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                ��ͬ��Լ�����&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=cht %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                ��������������&nbsp;
                            </td>
                            <td>
                                <%=cgc %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                ר���������&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=ccheck %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" colspan="2" align="center">
                                ��ҵ���ܣ�&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <%=cintro%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <!--��ҵ��Ա-->
        <div class="info_h2">
            <span class="info_h2_title">��ҵ��Ա</span></div>
        <div class="info_box" id="info_box_project_building">
            <div class="info_content">
                <table cellspacing="0" cellpadding="4" align="center" width="100%" border="1">
                    <asp:Repeater ID="rptcyry" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td width="50%" rowspan="5" align="right">
                                    <img src="<%# SzPic(Eval("cThumbnail").ToString())%>" width="200">
                                </td>
                                <td bgcolor="#e8ebee">
                                    ������<a href="XydaShowRyxx.aspx?id=<%# Eval("iId").ToString()%>" target="_blank">
                                        <%# Eval("cName").ToString()%></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ���ͣ�<%# Eval("cType").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ���õȼ���<%# Eval("ccredit").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ����<%# Eval("cjb").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ֤����ţ�<%# Eval("czjbh").ToString()%>
                                </td>
                            </tr>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_building_btn">չ��<i class="icon_down"></i></span></div>
        </div>
        <!--������-->
        <div class="info_h2">
            <span class="info_h2_title">������</span></div>
        <div class="info_box" id="info_box_project_intro">
            <div class="info_content">
                <table cellspacing="0" bordercolordark="#ffffff" cellpadding="4" align="center" bordercolorlight="#333333"
                    width="100%" border="1">
                    <asp:Repeater ID="rptxm" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#e8ebee">
                                <td align="center">
                                    �������ƣ�<%# Eval("cxmname").ToString()%>
                            </tr>
                            <tr>
                                </td>
                                <td align="center">
                                    ����ʱ�䣺<%# Eval("ckgsj").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    ����������<%# Eval("cpass").ToString()%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_intro_btn">չ��<i class="icon_down"></i></span></div>
        </div>
        <!--������Ϣ-->
        <div class="info_h2">
            <span class="info_h2_title">������Ϣ</span></div>
        <div class="info_box" id="info_box_project_jfbz">
            <div class="info_content">
                <table cellspacing="0" bordercolordark="#ffffff" cellpadding="4" align="center" bordercolorlight="#333333"
                    width="100%" border="1">
                    <asp:Repeater ID="rptlh" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#e8ebee">
                                <td>
                                    ����<%# Eval("csanction").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href='<%# Eval("cThumbnail").ToString()%>' target="_blank">��Ƭ<img src="<%# SzPic(Eval("cThumbnail").ToString())%>" width="200"></a>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    ��ֵ<%# Eval("ivalue").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    ʱ��
                                    <%# Eval("dCreatetime").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ����<%# Eval("cjg").ToString()%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_jfbz_btn">չ��<i class="icon_down"></i></span></div>
        </div>
        <!--��ʾ��Ϣ-->
        <div class="info_h2">
            <span class="info_h2_title">��ʾ��Ϣ</span></div>
        <div class="info_box" id="info_box_project_ptxx">
            <div class="info_content">
                <table cellspacing="0" bordercolordark="#ffffff" cellpadding="4" align="center" bordercolorlight="#333333"
                    width="100%" border="1">
                    <asp:Repeater ID="rptts" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#e8ebee">
                                <td align="center">
                                    ����<%# Eval("csanction").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href='<%# Eval("cThumbnail").ToString()%>' target="_blank">��Ƭ<img src="http://zx.yyfdcw.com<%# Eval("cThumbnail").ToString()%>"
                                        width="320" height="240"></a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    ��ֵ<%# Eval("ivalue").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    ʱ��
                                    <%# Eval("dCreatetime").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    ����<%# Eval("cjg").ToString()%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_ptxx_btn">չ��<i class="icon_down"></i></span></div>
        </div>
        <!--��ʾ��Ϣ-->
        <div class="info_h2">
            <span class="info_h2_title">��ʾ��Ϣ</span></div>
        <div class="info_box" id="Div4">
            <div class="info_content">
                <table cellspacing="0" bordercolordark="#ffffff" cellpadding="4" align="center" bordercolorlight="#333333"
                    width="100%" border="1">
                    <asp:Repeater ID="rptjs" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#e8ebee">
                                <td align="center">
                                    ����<%# Eval("csanction").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href='<%# Eval("cThumbnail").ToString()%>' target="_blank">��Ƭ<img src="http://zx.yyfdcw.com<%# Eval("cThumbnail").ToString()%>"
                                        width="320" height="240"></a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    ��ֵ<%# Eval("ivalue").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    ʱ��
                                    <%# Eval("dCreatetime").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    ����<%# Eval("cjg").ToString()%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="Span4">չ��<i class="icon_down"></i></span></div>
        </div>
    </div>

    <script type="text/javascript">
//����
var share_link =window.location.href;
var share_content="";
var share_title="";
var share_img="";
var dataForWeixin={
	appId:	"",
	img:	share_img,  
	url:	share_link,
	title:	share_title,
	desc:	share_content,
	fakeid:	"",
};
    </script>

    <script src="../js/share.js?version=1.0"></script>

    <!--�ײ�����-->
    <nav class="footernav">
<ul>
<li id="footernav_news"><a href="/news/BuildingNews.aspx">��Ѷ</a></li>
<li id="footernav_newhouse"><a href="/newhouse/List.aspx" target="_self">�·�</a></li>
<li id="footernav_sellhouse"><a href="/sellhouse/List.aspx" target="_self">���ַ�</a></li> 
<li id="footnav_bbs"><a href="/zxindex.aspx" target="_self">װ��</a></li> 
</ul>
</nav>
    <div class="footer">
        <div class="footer_link">
            <a href="#" class="agray">��׼��</a>&nbsp;&nbsp;<a href="javascript:void(0)" class="agray"
                style="color: #507FBD;">������</a>&nbsp;&nbsp;<a href="http://xx.yyfdcw.com" class="agray">���԰�</a></div>
        <div class="f12 fgray" align="center">
            Copyright &copy; 2014 �������ز���<br />
            m.yyfdcw.com ��ICP��13012493��</div>
    </div>
</body>
</html>
