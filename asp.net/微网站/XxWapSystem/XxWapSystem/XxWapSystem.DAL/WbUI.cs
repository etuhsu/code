using System;
using System.Text;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// WbUI ��ժҪ˵����
	/// </summary>
	public class WbUI
	{
		/// <summary>
		/// Ĭ�Ϲ��캯��
		/// </summary>
		public WbUI(){}

		/// <summary>
		/// ��ʾFlash�Լ�ͼƬ�ļ����Զ�������ʾ��Ϣ��
		/// </summary>
		/// <remarks>����ͨ�� 2007-2-6</remarks>
		/// <param name="url">�����ļ���ַ</param>
		/// <returns>��ʽ��֮�����ʾ�ַ���</returns>
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
				builder1.Append(120);	//����ָ��ͼƬ�ļ���ʾʱ������ȣ�����ʹ�������ļ�����
				builder1.Append(")this.style.width=");
				builder1.Append(120);
				builder1.Append(";\">");
			}
			return builder1.ToString();
		}

		/// <summary>
		/// ���ɵ�������
		/// �÷���ea.Web.UI.Navigate.Build(new string[3]{"��ҳ","ѧ������","���ѧ����Ϣ"});
		/// </summary>
		/// <param name="strShotCut">�����ݷ�ʽ��</param>
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
		/// ��ʾ��Ϣ��ʾ�Ի���
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		public static void  Show(System.Web.UI.Page page,string msg)
		{
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
		}

		/// <summary>
		/// �ؼ���� ��Ϣȷ����ʾ��
		/// </summary>
		/// <param name="Control"></param>
		/// <param name="msg">��ʾ��Ϣ</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}

		/// <summary>
		/// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		/// <param name="url">��ת��Ŀ��URL</param>
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
		/// ����Զ���ű���Ϣ
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="script">����ű�</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
			page.ClientScript.RegisterStartupScript(page.GetType(),"message","<script language='javascript' defer>"+script+"</script>");
		}

		/// <summary>
		/// �ͻ��˽ű�:confrim(Msg) I;
		/// </summary>
		/// <param name="Msg">��ȷ�ϵ���Ϣ</param>
		/// <param name="url">ȷ��֮��ת��ĵ�ַ</param>
		/// <returns>confirm�����Ŀͻ��˽ű�</returns>
		public static string Client_Confirm(string Msg, string url)
		{
			string scripts = "<script language=\"javascript\">" +
							"if (confirm('" + Msg + "')) " +
							" { location.href='" + url + "'; }" +
							"</script>";
			return scripts;
		}

		/// <summary>
		/// �ͻ��˽ű�:confrim(Msg) II;
		/// </summary>
		/// <param name="Msg">��ȷ�ϵ���Ϣ</param>
		/// <param name="cfmurl">ȷ��֮��ת��ĵ�ַ</param>
		/// <param name="retrunURL">ȡ��֮��ת��ĵ�ַ</param>
		/// <returns>confirm�����Ŀͻ��˽ű�</returns>
		public static string Client_Confirm(string Msg, string cfmurl, string retrunURL)
		{
			string scripts = "<script language=\"javascript\">" +
							"if (confirm('" + Msg + "')) " +
							" { location.href='" + cfmurl + "'; }" +
							"else { location.href='" + retrunURL + "'; }</script>";
			return scripts;
		}

		/// <summary>
		/// �رմ�������ʾ��Ϣ��
		/// </summary>
		public static string Client_CloseWindow()
		{
			return "<script>window.opener=null;window.close();</script>";
		}

		/// <summary>
		/// �ر� ����ǰ������ʾ��Ϣ
		/// </summary>
		/// <param name="MSG">��ʾ�ر���Ϣ</param>
		public static string Client_CloseWindow(string MSG)
		{
			return "<script>if(confirm('" + MSG + "')){window.opener=null;window.close();}else{return false;}</script>";
		}

		/// <summary>
		/// �ͻ��˽ű�:�ض�����ַ
		/// </summary>
		/// <param name="URL">�ض������ַ</param>
		/// <param name="CopyHistory">�Ƿ��¼��ʷ</param>
		/// <returns>�ض�����ַ�Ŀͻ��˽ű���</returns>
		public static string Client_Redirect(string URL, bool CopyHistory)
		{
			return (CopyHistory) ? "<script language=\"javascript\">top.location.href='" + URL + 
					"';</script>" : "<script language=\"javascript\">top.location.replace('" + URL + "');</script>";
		}
		
		/// <summary>
		/// ���´���
		/// </summary>
		/// <param name="URL">�´��ڵ�URL</param>
		/// <param name="WindowName">�´�����ʾ������</param>
		/// <param name="Toolbar">�Ƿ���ʾ��������yesΪ��ʾ</param>
		/// <param name="Menubar">�Ƿ���ʾ�˵�����yesΪ��ʾ</param>
		/// <param name="Scrollbars">�Ƿ���ʾ��������yesΪ��ʾ</param>
		/// <param name="Resizable">�Ƿ�����ı䴰�ڴ�С��yesΪ����</param>
		/// <param name="Location">�Ƿ���ʾ��ַ����yesΪ����</param>
		/// <param name="Status">�Ƿ���ʾ״̬���ڵ���Ϣ��ͨ�����ļ��Ѿ��򿪣���yesΪ����</param>
		/// <param name="Height">���ڸ߶�</param>
		/// <param name="Width">���ڿ��</param>
		/// <param name="Top">���ھ�����Ļ�Ϸ�������ֵ</param>
		/// <param name="Left">���ھ�����Ļ��������ֵ</param>
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
