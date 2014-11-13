using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_xyda
{
    public partial class xydaList : System.Web.UI.Page
    {
        public string ScriptStr = string.Empty;
        public string RequestStr = string.Empty;
        public string AllBudingCount = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqyname = Request["qyname"];
            string sqlstr = string.Empty;

            string WhereStr = BuileWhere();
            DataSet dtall = DBHelperZxw.Query("select * from xyda_jb" + WhereStr + " order by icreditvalue desc");
            AllBudingCount = dtall.Tables[0].Rows.Count.ToString();
            sqlstr = "select top 10 * from xyda_jb " + WhereStr + " order by icreditvalue desc";
            DataSet dt = DBHelperZxw.Query(sqlstr);
            this.rptMessage.DataSource = dt;
            this.rptMessage.DataBind();
            //Response.Write(sqlstr);
        }

        private string BuileWhere()
        {
            string StrWhere = " where 1=1 ";
            string sjcname = Request["jcname"];
            string ty = Request["ty"];
            string requestc = Request["c"];

            string tystr = string.Empty;
            if (!string.IsNullOrEmpty(ty))
            {
                switch (ty)
                {
                    case "1":
                        tystr = "壹级";
                        break;
                    case "2":
                        tystr = "贰级";
                        break;
                    case "3":
                        tystr = "叁级";
                        break;
                    case "4":
                        tystr = "暂定";
                        break;
                }
                if (ty == "0")
                {
                    ScriptStr = ScriptStr + "$(\"#t" + ty + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#t" + ty + "\").parent().toggleClass('checked');";
                }
                else
                {
                    ScriptStr = ScriptStr + "$(\"#t" + ty + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#t" + ty + "\").parent().toggleClass('checked');choose_opts.put(\"HType\", \"" + tystr + "\");choose_opt_labels['HType']='资质等级';";
                }
                RequestStr = "&ty=" + ty;
            }

            string cstr = string.Empty;
            if (!string.IsNullOrEmpty(requestc))
            {
                switch (requestc)
                {
                    case "1":
                        cstr = "A级";
                        break;
                    case "2":
                        cstr = "B级";
                        break;
                    case "3":
                        cstr = "C级";
                        break;
                    case "4":
                        cstr = "D级";
                        break;
                }

                if (requestc == "0")
                {
                    ScriptStr = ScriptStr + "$(\"#c" + requestc + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#c" + requestc + "\").parent().toggleClass('checked');";
                }
                else
                {
                    ScriptStr = ScriptStr + "$(\"#c" + requestc + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#c" + requestc + "\").parent().toggleClass('checked');choose_opts.put(\"HType\", \"" + cstr + "\");choose_opt_labels['HType']='信用等级';";
                }
                RequestStr = "&c=" + requestc;
            }
            if (!Equals(sjcname, null))
            {
                StrWhere += " and cqyname like '%" + sjcname + "%'";
            }
            if (!Equals(ty, null) && ty != "0")
            {
                StrWhere += " and cgrade ='" + tystr + "'";
            }
            if (!Equals(requestc, null) && requestc != "0")
            {
                StrWhere += " and ccredit ='" + cstr + "'";
            }

            return StrWhere;
        }
    }
}
