using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace XxWapSystem.zx_ts
{
    public partial class tsInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSub_click(object sender, EventArgs e)
        {
        Regex r1 = new Regex("^\\d{1,10}(\\.\\d{2})?$");

        //手机号码验证
        Regex r = new Regex("(^(\\d{3,4}-)?\\d{7,8})$|(1[0-9]{10})");

            if (this.txtName.Text == "")
            {
                Response.Write("<script>alert('投诉人姓名不允许为空，请添加投诉人姓名！');location.href='javascript:history.back();'</script>");
            }
            else if (this.txtqyname.Text == "")
            {
                Response.Write("<script>alert('投诉对象不允许为空，请添加投诉企业名称！');location.href='javascript:history.back();'</script>");
            }
            else if (this.txttel.Text.Replace(" ", "").Length > 0 && (!r.IsMatch(this.txttel.Text.Replace(" ", ""))))
            {
                Response.Write("<script>alert('您输入的手机号码格式错误!!!');location.href='javascript:history.back();'</script>");
                this.txttel.Text = "";
                return;
            }
            else
            {
                string sqls = "insert xyda_ts (ctitle,cname,ctel,cqyname,ccontent,dAddTime,bIsAudit) values ('','" + this.txtName.Text + "','" + this.txttel.Text + "','" + this.txtqyname.Text + "','" + this.txtcontent.Text + "','" + DateTime.Now + "','false')";

                DBHelperZxw.ExecuteSql(sqls);
                Response.Write("<script>alert('您发布的投诉信息提交成功！');location.href='tsList.aspx'</script>");
            }
        }

        protected void btnrtn_click(object sender, EventArgs e)
        {
            Response.Redirect("tsList.aspx");
        }

    }
}
