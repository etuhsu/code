using System;
using System.Text;

namespace XxWapSystem.DAL
{
	/// <summary>
	/// PageBar 的摘要说明。
	/// </summary>
	public class PageBar
	{
		/// <summary>
		/// 当前分页编号
		/// </summary>
		protected int _curPage;

		/// <summary>
		/// 分页大小 
		/// </summary>
		protected int _pageSize;

		/// <summary>
		/// 查询字符串
		/// </summary>
		protected string _queryString;

		/// <summary>
		/// 记录数量
		/// </summary>
		protected int _recordNum;

		/// <summary>
		/// 最大分页索引数
		/// </summary>
		protected int _maxPageIndex=5;

		/// <summary>
		/// 链接到第一页的提示信息 
		/// </summary>
		public string First = "首页";

		/// <summary>
		/// 链接到最后一页的提示信息 
		/// </summary>
		public string Last = "尾页";

		/// <summary>
		/// 链接到下一页的提示信息
		/// </summary>
		public string Next = "后页";

		/// <summary>
		/// 链接到前一页的提示信息
		/// </summary>
		public string Prev = "前页";

		/// <summary>
		/// 页数大小的提示信息,如也可以使用"Pages"作为提示
		/// </summary>
		public string Pages = "页数";

		/// <summary>
		/// 默认构造函数
		/// </summary>
		/// <param name="curPage">当前页号</param>
		/// <param name="recordNum">记录数量</param>
		/// <param name="pageSize">分页大小</param>
		/// <param name="maxPageIndex">页面上显示的最大分页索引数,默认为5,可根据版面宽度自由调整</param>
		/// <param name="query">查询字符串,如SomaPage.aspx?page=2之后可能需要跟一个分类编号"classid=3"(别忘了参数连接符!)</param>
		public PageBar(int curPage, int recordNum, int pageSize, int maxPageIndex,string query)
		{
			this.CurPage = curPage;
			this.RecordNum = recordNum;
			this.PageSize = pageSize;
			this._maxPageIndex=maxPageIndex;
			this.QueryString = query;
		}

		/// <summary>
		/// 生成最终的分页表格
		/// </summary>
		/// <returns>表格HTML字符串</returns>
		protected string GetText()
		{
			int num2;
			int MaxPageIndex = _maxPageIndex;	//最大页号
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
		/// 当前页
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
		/// 分页大小
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
		/// 查询字符串
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
		/// 记录数量
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
		/// 最终的输出表格
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
