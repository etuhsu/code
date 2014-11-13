using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// ���ڴ������ݷ�ҳʱ��һЩ��Ϣ��������
	/// </summary>
	public class PagerInfo
	{
		#region ���к���

		/// <summary>
		/// ���캯����
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
		/// ���캯����
		/// </summary>
		/// <param name="TableName">����ҳ�ı�������ͼ��</param>
		/// <param name="GetFields">��Ҫ���ص���,Ĭ��Ϊ*,��������</param>
		/// <param name="OrderField">�����ֶ���(Ĭ��Ϊ��,Ϊ��ʱ�����κ��������)</param>
		/// <param name="PageSize">ҳ�ߴ�(ÿҳ�ļ�¼��)</param>
		/// <param name="PageIndex">ҳ��(��ǰ�ڵڼ�����ҳ)</param>
		/// <param name="IsDesc">��������(��0����)</param>
		/// <param name="Fliter">�����ַ���(ע�ⲻ��Where�ؼ���,Ĭ��Ϊ��)</param>
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
		/// ��������������ڲ����ݡ�
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
		/// ����������Ϣ�ַ�����
		/// </summary>
		/// <returns>������Ϣ�ַ�����</returns>
		public override string ToString()
		{
			System.Text.StringBuilder sb=new System.Text.StringBuilder();
			sb.Append("����ҳ�ı�������ͼ����"+this.m_TableName+"<br>");
			sb.Append("��Ҫ���ص��У�"+this.m_GetFields+"<br>");
			sb.Append("�����ֶ�����"+this.m_OrderField+"<br>");
			sb.Append("ҳ�ߴ�(ÿҳ�ļ�¼��)��"+this.m_PageSize+"<br>");
			sb.Append("ҳ��(��ǰ�ڵڼ�����ҳ)��"+this.m_PageIndex+"<br>");

			sb.Append("�Ƿ�������"+this.m_IsDesc+"<br>");
			sb.Append("�����ַ�����"+this.m_Fliter+"<br>");
			sb.Append("��¼������"+this.m_RecordCount+"<br>");
			if (this.m_PageData!=null)
			{
				sb.Append("��ǰ���ݱ��м�¼����"+this.m_PageData.Rows.Count.ToString());
			}
			return sb.ToString();
		}

		#endregion
		
		#region ˽�г�Ա
		private string m_TableName;			//����ҳ�ı�������ͼ��
		private string m_GetFields;			//��Ҫ���ص���,Ĭ��Ϊ*,��������
		private string m_OrderField;	//�����ֶ���(Ĭ��Ϊ��)
		private int m_PageSize;				//ҳ�ߴ�(ÿҳ�ļ�¼��)
		private int m_PageIndex;			//ҳ��(��ǰ�ڵڼ�����ҳ)
		
		private bool m_IsDesc;				//��������,�Ƿ�Ϊ����(��0ֵ����)
		private string m_Fliter;			//�����ַ���(ע�ⲻ��Where�ؼ���,Ĭ��Ϊ��)
		private int m_RecordCount;			//��ǰ���Ա���ҳ�ļ�¼������
		private DataTable m_PageData;		//������ǰ��ҳ�����ݵ����ݱ�
		#endregion

		#region ����

		/// <summary>
		/// ����ҳ�ı�������ͼ����
		/// </summary>
		public string TableName
		{
			set{ m_TableName=value; }
			get{ return m_TableName; }
		}

		/// <summary>
		/// ��Ҫ���ص���,Ĭ��Ϊ*,�������С�
		/// </summary>
		public string GetFields
		{
			set{ m_GetFields=value; }
			get{ return m_GetFields; }
		}

		/// <summary>
		/// �����ֶ���(Ĭ��Ϊ��)��
		/// </summary>
		public string OrderField
		{
			set{ m_OrderField=value; }
			get{ return m_OrderField; }
		}

		/// <summary>
		/// ÿ����ҳ�ļ�¼����
		/// </summary>
		public int PageSize
		{
			set{ m_PageSize=value; }
			get{ return m_PageSize; }
		}

		/// <summary>
		/// ��ǰ�ķ�ҳҳ�š�
		/// </summary>
		public int PageIndex
		{
			set{ m_PageIndex=value; }
			get{ return m_PageIndex; }
		}


		/// <summary>
		/// �Ƿ�Ϊ����
		/// </summary>
		public bool IsDesc
		{
			set{ m_IsDesc=value; }
			get{ return m_IsDesc; }
		}

		/// <summary>
		/// �û����˼�¼�������ַ�����
		/// ����ַ���Ϊ���򷵻����м�¼(������)��
		/// </summary>
		public string Fliter
		{
			set{ m_Fliter=value; }
			get{ return m_Fliter; }
		}

		/// <summary>
		/// ��ǰ���Ա���ҳ�ļ�¼��������
		/// </summary>
		public int RecordCount
		{
			set{ m_RecordCount=value; }
			get{ return m_RecordCount; }
		}

		/// <summary>
		/// ������ǰ��ҳ�����ݵ����ݱ�
		/// </summary>
		public DataTable PageData
		{
			set { m_PageData=value; }
			get { return m_PageData; }
		}
			
		#endregion

		#region ��ҳ����

		/// <summary>
		/// ִ�з�ҳ������
		/// ע���ʱ�ķ�ҳ��Ϣ�����㹻��������׳��쳣��
		/// </summary>
		public void DoPager()
		{
			if (this.m_TableName==string.Empty)
			{
				throw new Exception("����ҳ�ı�������Ϊ�ա�");
			}
			if (this.m_GetFields==string.Empty)
			{
				this.m_GetFields="*";	//�����Ҫ����ȡ���ֶ�Ϊ����ȡ�����ֶ�
			}
			if (this.m_PageSize<0)
			{
				return;		//�����ҳ��СС�ڻ��������ֱ���˳�
			}
			if (this.m_PageIndex<=0)
			{
				this.m_PageIndex=1;
			}

			//��ѯ���������ļ�¼����
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
			parameters[5].Value = 1;	//��ѯ��¼����
			parameters[6].Value = this.m_IsDesc;
			parameters[7].Value = this.m_Fliter;	
			this.m_RecordCount=(int)DBHelper.RunProcedure("UP_PageRecord",parameters,"ds").Tables[0].Rows[0][0];

			//������ĳҳɾ�����м�¼��ҳ����Ȼͣ���ڸ�ҳ������
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

			//��ѯ���������ĵ�ǰ��ҳ�ļ�¼��
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
			parameters1[5].Value = 0;	//��ѯĳҳ�ļ�¼
			parameters1[6].Value = this.m_IsDesc;
			parameters1[7].Value = this.m_Fliter;
			this.PageData= DBHelper.RunProcedure("UP_PageRecord",parameters1,"ds").Tables[0];
		}

		#endregion
	}
}
