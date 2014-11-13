using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// 用于处理数据分页时的一些信息的描述。
	/// </summary>
	public class PagerInfo
	{
		#region 公有函数

		/// <summary>
		/// 构造函数。
		/// </summary>
		public PagerInfo() 
		{
			this.m_TableName=string.Empty;
			this.m_GetFields="*";
			this.m_OrderField=string.Empty;
			this.m_PageSize=0;
			this.m_PageIndex=0;
			this.m_IsDesc=false;
			this.m_Fliter=string.Empty;
			this.m_RecordCount=0;
			this.m_PageData=new DataTable();
		}

		/// <summary>
		/// 构造函数。
		/// </summary>
		/// <param name="TableName">被分页的表名或视图名</param>
		/// <param name="GetFields">需要返回的列,默认为*,即所有列</param>
		/// <param name="OrderField">排序字段名(默认为空,为空时不做任何排序操作)</param>
		/// <param name="PageSize">页尺寸(每页的记录数)</param>
		/// <param name="PageIndex">页码(当前在第几个分页)</param>
		/// <param name="IsDesc">排序类型(非0则降序)</param>
		/// <param name="Fliter">过滤字符串(注意不带Where关键字,默认为空)</param>
		public PagerInfo(string TableName,string GetFields,string OrderField,
			int PageSize,int PageIndex,bool IsDesc,string Fliter)
		{
			this.m_TableName=TableName;
			this.m_GetFields=GetFields;
			this.m_OrderField=OrderField;
			this.m_PageSize=PageSize;
			this.m_PageIndex=PageIndex;
			this.m_IsDesc=IsDesc;
			this.m_Fliter=Fliter;
			this.m_RecordCount=0;
			this.m_PageData=new DataTable();
		}

		/// <summary>
		/// 重置描述对象的内部数据。
		/// </summary>
		public void Reset()
		{
			this.m_TableName=string.Empty;
			this.m_GetFields="*";
			this.m_OrderField=string.Empty;
			this.m_PageSize=0;
			this.m_PageIndex=0;
			this.m_IsDesc=false;
			this.m_Fliter=string.Empty;
			this.m_RecordCount=0;
			this.m_PageData=new DataTable();
		}

		/// <summary>
		/// 返回描述信息字符串。
		/// </summary>
		/// <returns>描述信息字符串。</returns>
		public override string ToString()
		{
			System.Text.StringBuilder sb=new System.Text.StringBuilder();
			sb.Append("被分页的表名或视图名："+this.m_TableName+"<br>");
			sb.Append("需要返回的列："+this.m_GetFields+"<br>");
			sb.Append("排序字段名："+this.m_OrderField+"<br>");
			sb.Append("页尺寸(每页的记录数)："+this.m_PageSize+"<br>");
			sb.Append("页码(当前在第几个分页)："+this.m_PageIndex+"<br>");

			sb.Append("是否降序排序："+this.m_IsDesc+"<br>");
			sb.Append("过滤字符串："+this.m_Fliter+"<br>");
			sb.Append("记录总数："+this.m_RecordCount+"<br>");
			if (this.m_PageData!=null)
			{
				sb.Append("当前数据表中记录数："+this.m_PageData.Rows.Count.ToString());
			}
			return sb.ToString();
		}

		#endregion
		
		#region 私有成员
		private string m_TableName;			//被分页的表名或视图名
		private string m_GetFields;			//需要返回的列,默认为*,即所有列
		private string m_OrderField;	//排序字段名(默认为空)
		private int m_PageSize;				//页尺寸(每页的记录数)
		private int m_PageIndex;			//页码(当前在第几个分页)
		
		private bool m_IsDesc;				//排序类型,是否为降序(非0值则降序)
		private string m_Fliter;			//过滤字符串(注意不带Where关键字,默认为空)
		private int m_RecordCount;			//当前可以被分页的记录的总数
		private DataTable m_PageData;		//包含当前分页的数据的数据表
		#endregion

		#region 属性

		/// <summary>
		/// 被分页的表名或视图名。
		/// </summary>
		public string TableName
		{
			set{ m_TableName=value; }
			get{ return m_TableName; }
		}

		/// <summary>
		/// 需要返回的列,默认为*,即所有列。
		/// </summary>
		public string GetFields
		{
			set{ m_GetFields=value; }
			get{ return m_GetFields; }
		}

		/// <summary>
		/// 排序字段名(默认为空)。
		/// </summary>
		public string OrderField
		{
			set{ m_OrderField=value; }
			get{ return m_OrderField; }
		}

		/// <summary>
		/// 每个分页的记录数。
		/// </summary>
		public int PageSize
		{
			set{ m_PageSize=value; }
			get{ return m_PageSize; }
		}

		/// <summary>
		/// 当前的分页页号。
		/// </summary>
		public int PageIndex
		{
			set{ m_PageIndex=value; }
			get{ return m_PageIndex; }
		}


		/// <summary>
		/// 是否为降序。
		/// </summary>
		public bool IsDesc
		{
			set{ m_IsDesc=value; }
			get{ return m_IsDesc; }
		}

		/// <summary>
		/// 用户过滤记录的条件字符串。
		/// 如果字符串为空则返回所有记录(不过滤)。
		/// </summary>
		public string Fliter
		{
			set{ m_Fliter=value; }
			get{ return m_Fliter; }
		}

		/// <summary>
		/// 当前可以被分页的记录的总数。
		/// </summary>
		public int RecordCount
		{
			set{ m_RecordCount=value; }
			get{ return m_RecordCount; }
		}

		/// <summary>
		/// 包含当前分页的数据的数据表。
		/// </summary>
		public DataTable PageData
		{
			set { m_PageData=value; }
			get { return m_PageData; }
		}
			
		#endregion

		#region 分页功能

		/// <summary>
		/// 执行分页操作。
		/// 注意此时的分页信息必须足够，否则会抛出异常。
		/// </summary>
		public void DoPager()
		{
			if (this.m_TableName==string.Empty)
			{
				throw new Exception("被分页的表名不能为空。");
			}
			if (this.m_GetFields==string.Empty)
			{
				this.m_GetFields="*";	//如果需要被获取的字段为空则取所有字段
			}
			if (this.m_PageSize<0)
			{
				return;		//如果分页大小小于或等于零则直接退出
			}
			if (this.m_PageIndex<=0)
			{
				this.m_PageIndex=1;
			}

			//查询满足条件的记录总数
			SqlParameter[] parameters = {
											new SqlParameter("@TableName", SqlDbType.VarChar, 255),
											new SqlParameter("@GetFields", SqlDbType.VarChar, 2000),
											new SqlParameter("@OrderField", SqlDbType.VarChar, 255),
											new SqlParameter("@PageSize", SqlDbType.Int),
											new SqlParameter("@PageIndex", SqlDbType.Int),
											new SqlParameter("@IsRtnCount", SqlDbType.Bit),
											new SqlParameter("@IsDesc", SqlDbType.Bit),
											new SqlParameter("@strFliter", SqlDbType.VarChar,2000),
			};
			parameters[0].Value = this.m_TableName;
			parameters[1].Value = this.m_GetFields;
			parameters[2].Value = this.m_OrderField;
			parameters[3].Value = this.m_PageSize;
			parameters[4].Value = this.m_PageIndex;
			parameters[5].Value = 1;	//查询记录总数
			parameters[6].Value = this.m_IsDesc;
			parameters[7].Value = this.m_Fliter;	
			this.m_RecordCount=(int)DBHelper.RunProcedure("UP_PageRecord",parameters,"ds").Tables[0].Rows[0][0];

			//修正在某页删除所有记录后页面依然停留在该页的问题
			if((m_PageIndex-1)*m_PageSize>=m_RecordCount)
			{
				if(m_RecordCount%m_PageSize==0)
				{
					m_PageIndex=m_RecordCount/m_PageSize;
				}
				else
				{
					m_PageIndex=m_RecordCount/m_PageSize+1;
				}
			}
			if (this.m_PageIndex<=0)
			{
				this.m_PageIndex=1;
			}

			//查询满足条件的当前分页的记录表
			SqlParameter[] parameters1 = {
											 new SqlParameter("@TableName", SqlDbType.VarChar, 255),
											 new SqlParameter("@GetFields", SqlDbType.VarChar, 2000),
											 new SqlParameter("@OrderField", SqlDbType.VarChar, 255),
											 new SqlParameter("@PageSize", SqlDbType.Int),
											 new SqlParameter("@PageIndex", SqlDbType.Int),
											 new SqlParameter("@IsRtnCount", SqlDbType.Bit),
											 new SqlParameter("@IsDesc", SqlDbType.Bit),
											 new SqlParameter("@strFliter", SqlDbType.VarChar,2000),
			};
			parameters1[0].Value = this.m_TableName;
			parameters1[1].Value = this.m_GetFields;
			parameters1[2].Value = this.m_OrderField;
			parameters1[3].Value = this.m_PageSize;
			parameters1[4].Value = this.m_PageIndex;
			parameters1[5].Value = 0;	//查询某页的记录
			parameters1[6].Value = this.m_IsDesc;
			parameters1[7].Value = this.m_Fliter;
			this.PageData= DBHelper.RunProcedure("UP_PageRecord",parameters1,"ds").Tables[0];
		}

		#endregion
	}
}
