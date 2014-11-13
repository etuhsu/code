using System;
using System.Text;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// WbUI 的摘要说明。
	/// </summary>
	public class WbUI
	{
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public WbUI(){}

		/// <summary>
		/// 显示Flash以及图片文件（自动加上显示信息）
		/// </summary>
		/// <remarks>测试通过 2007-2-6</remarks>
		/// <param name="url">链接文件地址</param>
		/// <returns>格式化之后的显示字符串</returns>
		public static string FlashImg(string url)
		{
			StringBuilder builder1 = new StringBuilder();
			if (url.ToLower().EndsWith(".swf"))
			{
				builder1.Append("<span style='padding:5px'><OBJECT classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://active.macromedia.com/flash2/cabs/swflash.cab#version=4,0,0,0' WIDTH=120 height=90><PARAM NAME=movie VALUE='");
				builder1.Append(url);
				builder1.Append("'> <PARAM NAME=quality VALUE=high><EMBED src='");
				builder1.Append(url);
				builder1.Append("' loop=false menu=false quality=high WIDTH=120 height=90 TYPE='application/x-shockwave-flash' PLUGINSPAGE='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash'></EMBED></OBJECT></span>");
			}
			else
			{
				builder1.Append("<img vspace=5 border=0 src='");
				builder1.Append(url);
				builder1.Append("' onload=\"javascript:if(this.width>");
				builder1.Append(120);	//这里指定图片文件显示时的最大宽度，可以使用配置文件配置
				builder1.Append(")this.style.width=");
				builder1.Append(120);
				builder1.Append(";\">");
			}
			return builder1.ToString();
		}

		/// <summary>
		/// 生成导航条。
		/// 用法：ea.Web.UI.Navigate.Build(new string[3]{"首页","学生管理","添加学生信息"});
		/// </summary>
		/// <param name="strShotCut">管理快捷方式。</param>
		public static string Navigate(string[] strShotCut)
		{	
			StringBuilder sb=new System.Text.StringBuilder();
			int curPos=0;
			if(strShotCut.GetLength(0)>0)
			{
				foreach(string item in strShotCut) 
				{
					sb.Append(item);curPos++;
					if (curPos<strShotCut.GetLength(0)) sb.Append(" | ");
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// 显示消息提示对话框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void  Show(System.Web.UI.Page page,string msg)
		{
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
		}

		/// <summary>
		/// 控件点击 消息确认提示框
		/// </summary>
		/// <param name="Control"></param>
		/// <param name="msg">提示信息</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}

		/// <summary>
		/// 显示消息提示对话框，并进行页面跳转
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		/// <param name="url">跳转的目标URL</param>
		public static void ShowAndRedirect(System.Web.UI.Page page,string msg,string url)
		{
			StringBuilder Builder=new StringBuilder();
			Builder.Append("<script language='javascript' defer>");
			Builder.AppendFormat("alert('{0}');",msg);
			Builder.AppendFormat("top.location.href='{0}'",url);
			Builder.Append("</script>");
			page.ClientScript.RegisterStartupScript(page.GetType(),"message",Builder.ToString());
		}

		/// <summary>
		/// 输出自定义脚本信息
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="script">输出脚本</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
			page.ClientScript.RegisterStartupScript(page.GetType(),"message","<script language='javascript' defer>"+script+"</script>");
		}

		/// <summary>
		/// 客户端脚本:confrim(Msg) I;
		/// </summary>
		/// <param name="Msg">待确认的消息</param>
		/// <param name="url">确认之后转向的地址</param>
		/// <returns>confirm函数的客户端脚本</returns>
		public static string Client_Confirm(string Msg, string url)
		{
			string scripts = "<script language=\"javascript\">" +
							"if (confirm('" + Msg + "')) " +
							" { location.href='" + url + "'; }" +
							"</script>";
			return scripts;
		}

		/// <summary>
		/// 客户端脚本:confrim(Msg) II;
		/// </summary>
		/// <param name="Msg">待确认的消息</param>
		/// <param name="cfmurl">确认之后转向的地址</param>
		/// <param name="retrunURL">取消之后转向的地址</param>
		/// <returns>confirm函数的客户端脚本</returns>
		public static string Client_Confirm(string Msg, string cfmurl, string retrunURL)
		{
			string scripts = "<script language=\"javascript\">" +
							"if (confirm('" + Msg + "')) " +
							" { location.href='" + cfmurl + "'; }" +
							"else { location.href='" + retrunURL + "'; }</script>";
			return scripts;
		}

		/// <summary>
		/// 关闭窗口无提示信息！
		/// </summary>
		public static string Client_CloseWindow()
		{
			return "<script>window.opener=null;window.close();</script>";
		}

		/// <summary>
		/// 关闭 窗口前出现提示信息
		/// </summary>
		/// <param name="MSG">提示关闭信息</param>
		public static string Client_CloseWindow(string MSG)
		{
			return "<script>if(confirm('" + MSG + "')){window.opener=null;window.close();}else{return false;}</script>";
		}

		/// <summary>
		/// 客户端脚本:重定向网址
		/// </summary>
		/// <param name="URL">重定向的网址</param>
		/// <param name="CopyHistory">是否记录历史</param>
		/// <returns>重定向网址的客户端脚本块</returns>
		public static string Client_Redirect(string URL, bool CopyHistory)
		{
			return (CopyHistory) ? "<script language=\"javascript\">top.location.href='" + URL + 
					"';</script>" : "<script language=\"javascript\">top.location.replace('" + URL + "');</script>";
		}
		
		/// <summary>
		/// 打开新窗口
		/// </summary>
		/// <param name="URL">新窗口的URL</param>
		/// <param name="WindowName">新窗口显示的名称</param>
		/// <param name="Toolbar">是否显示工具栏，yes为显示</param>
		/// <param name="Menubar">是否显示菜单栏，yes为显示</param>
		/// <param name="Scrollbars">是否显示滚动栏，yes为显示</param>
		/// <param name="Resizable">是否允许改变窗口大小，yes为允许</param>
		/// <param name="Location">是否显示地址栏，yes为允许</param>
		/// <param name="Status">是否显示状态栏内的信息（通常是文件已经打开），yes为允许</param>
		/// <param name="Height">窗口高度</param>
		/// <param name="Width">窗口宽度</param>
		/// <param name="Top">窗口距离屏幕上方的象素值</param>
		/// <param name="Left">窗口距离屏幕左侧的象素值</param>
		public static string Client_Open(string URL, string WindowName, bool Toolbar, bool Menubar, bool Scrollbars, 
			bool Resizable, bool Location, bool Status, int Height, int Width, int Top, int Left)
		{
			return "<script>window.open('" + URL + "','" + WindowName + "','toolbar=" + Toolbar + ",')</script>";
		}


        public static void ResponseScript()
        {
            throw new NotImplementedException();
        }
    }
}
