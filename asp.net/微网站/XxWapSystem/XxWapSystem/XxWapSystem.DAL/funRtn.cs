using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// ���ܺ�����ִ�н����������(FunctionReturn)��
	/// </summary>
	public class funRtn
	{
		///˽�г�Ա�б�
		private int m_rtnID;				///���ص�������Ϣ���
		private StringBuilder m_rtnMsg;		///���ص�������Ϣ
		public static int gSuccess=100;		///ִ�гɹ������ֱ��
		public static int gFail=-1;			///ִ��ʧ�ܵ����ֱ��


		/// <summary>
		/// Ĭ�Ϲ��캯��,Ĭ�Ϸ���ʧ�ܱ�ǡ�
		/// </summary>
		public funRtn()
		{
			this.m_rtnID=gSuccess;
			this.m_rtnMsg=new StringBuilder();
			this.m_rtnMsg.Append("");
		}

		/// <summary>
		/// ���캯����
		/// </summary>
		/// <param name="rtnID">������Ϣ���,��ֱ��ȡgFail��</param>
		/// <param name="rtnMsg">������Ϣ��</param>
		public funRtn(int rtnID,string rtnMsg)
		{
			this.m_rtnID=rtnID;
			this.m_rtnMsg=new StringBuilder();
			this.m_rtnMsg.Append(rtnMsg);
		}

		/// <summary>
		/// ֻ����������Ϣ���,Ĭ������¿���������myRtn.rtnID=ea.funRtn.gFail;
		/// </summary>
		public int rtnID
		{
			get { return this.m_rtnID; }
			set { this.m_rtnID=value;  }
		}

		/// <summary>
		/// ֻ����������Ϣ,��ʹ�������﷨��myResult.rtnMsg.Append(""Test");
		/// </summary>
		public StringBuilder rtnMsg
		{
			get 
			{ 
				if(this.m_rtnID==gSuccess)
					return this.m_rtnMsg.Replace("<li>","<li style='color:blue;list-style:none; margin:0; padding:0;'>");
				else
					return this.m_rtnMsg.Replace("<li>","<li style='color:red;list-style:none; margin:0; padding:0;'>");
			}
		}

		/// <summary>
		/// ����ԭʼ��������Ϣ(��li����Ұ�����ȷ�ʹ�����Ϣ)
		/// </summary>
		public string srcRtnMsg
		{
			get{ return this.m_rtnMsg.ToString().Replace("<li>","").Replace("</li>","");}
		}

		/// <summary>
		/// ȷ���������ݿ�����Ƿ�ɹ���
		/// </summary>
		public bool IsSuccessed
		{
			get { return this.m_rtnID==gSuccess; }
		}

		/// <summary>
		/// �����������������Ϣ��ź�������Ϣ�������ַ�����ʽ����(�ڵ���ʱʹ�ñȽϷ���)��
		/// </summary>
		public override string ToString()
		{
			return "������Ϣ��ţ�" +this.m_rtnID.ToString()+"<br>"+"������Ϣ���ݣ�"+this.m_rtnMsg.ToString();
		}
	}
}
