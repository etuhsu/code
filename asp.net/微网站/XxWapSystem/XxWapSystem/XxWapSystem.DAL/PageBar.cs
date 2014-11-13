using System;
using System.Text;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// PageBar ��ժҪ˵����
	/// </summary>
	public class PageBar
	{
		/// <summary>
		/// ��ǰ��ҳ���
		/// </summary>
		protected int _curPage;

		/// <summary>
		/// ��ҳ��С 
		/// </summary>
		protected int _pageSize;

		/// <summary>
		/// ��ѯ�ַ���
		/// </summary>
		protected string _queryString;

		/// <summary>
		/// ��¼����
		/// </summary>
		protected int _recordNum;

		/// <summary>
		/// ����ҳ������
		/// </summary>
		protected int _maxPageIndex=5;

		/// <summary>
		/// ���ӵ���һҳ����ʾ��Ϣ 
		/// </summary>
		public string First = "��ҳ";

		/// <summary>
		/// ���ӵ����һҳ����ʾ��Ϣ 
		/// </summary>
		public string Last = "βҳ";

		/// <summary>
		/// ���ӵ���һҳ����ʾ��Ϣ
		/// </summary>
		public string Next = "��ҳ";

		/// <summary>
		/// ���ӵ�ǰһҳ����ʾ��Ϣ
		/// </summary>
		public string Prev = "ǰҳ";

		/// <summary>
		/// ҳ����С����ʾ��Ϣ,��Ҳ����ʹ��"Pages"��Ϊ��ʾ
		/// </summary>
		public string Pages = "ҳ��";

		/// <summary>
		/// Ĭ�Ϲ��캯��
		/// </summary>
		/// <param name="curPage">��ǰҳ��</param>
		/// <param name="recordNum">��¼����</param>
		/// <param name="pageSize">��ҳ��С</param>
		/// <param name="maxPageIndex">ҳ������ʾ������ҳ������,Ĭ��Ϊ5,�ɸ��ݰ��������ɵ���</param>
		/// <param name="query">��ѯ�ַ���,��SomaPage.aspx?page=2֮�������Ҫ��һ��������"classid=3"(�����˲������ӷ�!)</param>
		public PageBar(int curPage, int recordNum, int pageSize, int maxPageIndex,string query)
		{
			this.CurPage = curPage;
			this.RecordNum = recordNum;
			this.PageSize = pageSize;
			this._maxPageIndex=maxPageIndex;
			this.QueryString = query;
		}

		/// <summary>
		/// �������յķ�ҳ���
		/// </summary>
		/// <returns>���HTML�ַ���</returns>
		protected string GetText()
		{
			int num2;
			int MaxPageIndex = _maxPageIndex;	//���ҳ��
			StringBuilder builder = new StringBuilder();
			int num3 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.RecordNum) / ((double) this.PageSize)));
			if (num3 == 0)
			{
				num3 = 1;
			}
			if (this.CurPage > num3)
			{
				this.CurPage = 1;
			}
			if (this.CurPage <= MaxPageIndex)
			{
				num2 = 1;
			}
			else
			{
				num2 = (Convert.ToInt32(Math.Floor(((double) (this.CurPage - 1)) / ((double) MaxPageIndex))) * MaxPageIndex) + 1;
			}
			builder.Append("<table cellpadding=0 cellspacing=0 width=100%><tr><td>");
			if (this.CurPage > 1)
			{
				builder.Append("<a href=?page=1");
				builder.Append(this.QueryString);
				builder.Append(">");
				builder.Append(this.First);
				builder.Append("</a> | <a href=?page=");
				builder.Append((int) (this.CurPage - 1));
				builder.Append(this.QueryString);
				builder.Append(">");
				builder.Append(this.Prev);
				builder.Append("</a>");
			}
			else
			{
				builder.Append("<font class=gray>");
				builder.Append(this.First);
				builder.Append("</font> | <font class=gray>");
				builder.Append(this.Prev);
				builder.Append("</font>");
			}
			if (this.CurPage < num3)
			{
				builder.Append(" | <a href=?page=");
				builder.Append((int) (this.CurPage + 1));
				builder.Append(this.QueryString);
				builder.Append(">");
				builder.Append(this.Next);
				builder.Append("</a> | <a href=?page=");
				builder.Append(num3);
				builder.Append(this.QueryString);
				builder.Append(">");
				builder.Append(this.Last);
				builder.Append("</a>");
			}
			else
			{
				builder.Append(" | <font class=gray>");
				builder.Append(this.Next);
				builder.Append("</font> | <font class=gray>");
				builder.Append(this.Last);
				builder.Append("</font>");
			}
			builder.Append("</td><td align=right>");
			builder.Append(this.Pages);
			builder.Append(" ");
			builder.Append(this.CurPage);
			builder.Append("/");
			builder.Append(num3);
			builder.Append("&nbsp; &nbsp;");
			if (num2 > 1)
			{
				builder.Append("<a href=?page=");
				builder.Append((int) (num2 - 1));
				builder.Append(this.QueryString);
				builder.Append(">[<<]</a> ");
			}
			for (int i = num2; i < (num2 + MaxPageIndex); i++)
			{
				if (i == this.CurPage)
				{
					builder.Append("<font class=gray>[" + i + "]</font> ");
				}
				else
				{
					builder.Append("<a href=?page=");
					builder.Append(i);
					builder.Append(this.QueryString);
					builder.Append(">[");
					builder.Append(i);
					builder.Append("]</a> ");
				}
				if (i == num3)
				{
					break;
				}
			}
			if ((num2 + MaxPageIndex) <= num3)
			{
				builder.Append("<a href=?page=");
				builder.Append((int) (num2 + MaxPageIndex));
				builder.Append(this.QueryString);
				builder.Append(">[>>]</a> ");
			}
			builder.Append("</td></tr></table>");
			return builder.ToString();
		}

		/// <summary>
		/// ��ǰҳ
		/// </summary>
		public int CurPage
		{
			get
			{
				return this._curPage;
			}
			set
			{
				this._curPage = value;
			}
		}

		/// <summary>
		/// ��ҳ��С
		/// </summary>
		public int PageSize
		{
			get
			{
				return this._pageSize;
			}
			set
			{
				this._pageSize = value;
			}
		}

		/// <summary>
		/// ��ѯ�ַ���
		/// </summary>
		public string QueryString
		{
			get
			{
				return this._queryString;
			}
			set
			{
				this._queryString = value;
			}
		}

		/// <summary>
		/// ��¼����
		/// </summary>
		public int RecordNum
		{
			get
			{
				return this._recordNum;
			}
			set
			{
				this._recordNum = value;
			}
		}

		/// <summary>
		/// ���յ�������
		/// </summary>
		public string Text
		{
			get
			{
				return this.GetText();
			}
		}

	}
}
