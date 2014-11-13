using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// 功能函数的执行结果描述对象(FunctionReturn)。
	/// </summary>
	public class funRtn
	{
		///私有成员列表。
		private int m_rtnID;				///返回的描叙信息编号
		private StringBuilder m_rtnMsg;		///返回的描述信息
		public static int gSuccess=100;		///执行成功的数字标记
		public static int gFail=-1;			///执行失败的数字标记


		/// <summary>
		/// 默认构造函数,默认返回失败标记。
		/// </summary>
		public funRtn()
		{
			this.m_rtnID=gSuccess;
			this.m_rtnMsg=new StringBuilder();
			this.m_rtnMsg.Append("");
		}

		/// <summary>
		/// 构造函数。
		/// </summary>
		/// <param name="rtnID">描述信息编号,可直接取gFail。</param>
		/// <param name="rtnMsg">描述信息。</param>
		public funRtn(int rtnID,string rtnMsg)
		{
			this.m_rtnID=rtnID;
			this.m_rtnMsg=new StringBuilder();
			this.m_rtnMsg.Append(rtnMsg);
		}

		/// <summary>
		/// 只读的描述信息编号,默认情况下可以这样：myRtn.rtnID=ea.funRtn.gFail;
		/// </summary>
		public int rtnID
		{
			get { return this.m_rtnID; }
			set { this.m_rtnID=value;  }
		}

		/// <summary>
		/// 只读的描述信息,可使用如下语法：myResult.rtnMsg.Append(""Test");
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
		/// 返回原始的描述信息(含li标记且包含正确和错误信息)
		/// </summary>
		public string srcRtnMsg
		{
			get{ return this.m_rtnMsg.ToString().Replace("<li>","").Replace("</li>","");}
		}

		/// <summary>
		/// 确定本次数据库操作是否成功。
		/// </summary>
		public bool IsSuccessed
		{
			get { return this.m_rtnID==gSuccess; }
		}

		/// <summary>
		/// 将操作结果的描述信息编号和描述信息内容以字符串形式返回(在调试时使用比较方便)。
		/// </summary>
		public override string ToString()
		{
			return "描述信息编号：" +this.m_rtnID.ToString()+"<br>"+"描述信息内容："+this.m_rtnMsg.ToString();
		}
	}
}
