using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using ZfbzJk;

/// <summary>
///WebService 的摘要说明
/// </summary>  
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
   public List<Fwcqxx> GetFwCqxxs(List<User> users)
    {
        List<Fwcqxx> fwcqxxs = null;
        foreach (User user in users)
        {
            ToolKit toolkit = new ToolKit();
            string sjbh="",clh = "" ;
            string sql = " select distinct sjbh,clh,zjzmj,hh from fdcmain.rs_syqfwjbxx where sjbh in( " +
                       " select distinct sjbh from fdcmain.ep_fjywxx " +
                       " where ywdl in('房屋所有权初始登记','数据录入','其他登记','房屋所有权转移登记','房屋所有权变更登记','预告登记','变更登记','转移登记','预告登记','初始登记','总登记') " +
                       " ) and sjbh in( select sjbh from fdcmain.rs_syqjbxx  where  trim(replace(syqrmc,' ',''))='"+user.sqrxm+"' or  trim(replace(zjhm,' ','')) like '%"+user.sqrzjhm+"%' ) ";
          //  DataTable datatable = toolkit.Get_Tbl(sql);
            foreach (DataRow datarow in toolkit.Get_Tbl(sql).Rows)
            {
                if (fwcqxxs == null)
                {
                    fwcqxxs = new List<Fwcqxx>();
                }
                Fwcqxx fwcqxx = new Fwcqxx();
                sjbh=datarow["sjbh"].ToString();
                clh = datarow["clh"].ToString();
                fwcqxx.sqrxm = user.sqrxm;
                fwcqxx.sqrzjhm = user.sqrzjhm;
                fwcqxx.fwzl=toolkit.ExecuteOracleStr(" select fwzl from fdcmain.ep_jzwzjbxx where clh='"+clh+"'");
                fwcqxx.jzmj=datarow["zjzmj"].ToString();
                fwcqxx.fh = datarow["hh"].ToString();
                if (fwcqxx.fh == "多重")
                {
                    fwcqxx.fh = toolkit.ExecuteOracleStr("select fh from fdcmain.rs_syqfjxx where sjbh='"+sjbh+"' and rownum=1");
                    fwcqxx.fh = fwcqxx.fh + "等";
                }
                else if (fwcqxx.fh == "总证" || fwcqxx.fh == "整幢" || fwcqxx.fh == "整栋")
                {
                    fwcqxx.fh = "整栋";
                }

                fwcqxx.cqlx = "所有权人";
                DataRow row = toolkit.Get_Row("select trim(replace(syqrmc,' ','')) as \"syqrmc\" ,trim(replace(cqqdsj,' ',''))  as \"cqqdsj\",trim(replace(zjhm,' ',''))  as \"zjhm\"  from fdcmain.rs_syqjbxx where sjbh='" + sjbh + "'");
                fwcqxx.qssj = row["cqqdsj"].ToString();
                fwcqxx.cqrzjhm = row["zjhm"].ToString();
                fwcqxx.cqrxm = row["syqrmc"].ToString();
                fwcqxx.xm_match = fwcqxx.cqrxm== user.sqrxm? "1":"0";
                fwcqxx.hm_match = fwcqxx.cqrzjhm == user.sqrzjhm? "1" : "0";

             ////共有权人信息
                
                foreach (DataRow tmepdatarow in toolkit.Get_Tbl("select distinct gyqr,zjhm from fdcmain.rs_gyqlxx where gyqr is not null  and length(trim(replace(gyqr,' ','')))>0 and sjbh='" + sjbh + "'").Rows)
                {
                    
                        Fwcqxx tempfwcqxx = new Fwcqxx();
                        tempfwcqxx.sqrxm = user.sqrxm;
                        tempfwcqxx.sqrzjhm = user.sqrzjhm;
                        tempfwcqxx.cqrxm = tmepdatarow["gyqr"].ToString();
                        tempfwcqxx.cqrzjhm = tmepdatarow["zjhm"].ToString();
                        tempfwcqxx.fwzl = fwcqxx.fwzl;
                        tempfwcqxx.jzmj = fwcqxx.jzmj;
                        tempfwcqxx.fh = fwcqxx.fh;
                        tempfwcqxx.cqlx = "共有权人 ";
                        tempfwcqxx.qssj = fwcqxx.qssj;
                        fwcqxx.xm_match = fwcqxx.cqrxm == user.sqrxm ? "1" : "0";
                        fwcqxx.hm_match = fwcqxx.cqrzjhm == user.sqrzjhm ? "1" : "0";
                        fwcqxxs.Add(tempfwcqxx);
                    
                 /*   if (fwcqxx.gyrxxs == null)
                    {
                        fwcqxx.gyrxxs = new List<Gyrxx>();
                    }
                   Gyrxx gyrxx = new Gyrxx();
                   gyrxx.gyrxm = tmepdatarow["gyqr"].ToString();

                   gyrxx.gyrxm = tmepdatarow["zjhm"].ToString();
                   fwcqxx.gyrxxs.Add(gyrxx);
                    */
                }












                fwcqxxs.Add(fwcqxx);
            }
        }
        return fwcqxxs;
    }
  
    [WebMethod]
    public List<Htbaxx> GetHtbaxxs(List<User> users)
    {
        List<Htbaxx> htbaxxs = new List<Htbaxx>();
        foreach (User user in users)
        {
            string sqlstr = "select 乙方,预购人身份证件,开发项目名称,预售面积,成交金额,合同类型,签订日期 from 合同流程控制 where 乙方 like '%" + user.sqrxm + "%' and 预购人身份证件 like '%" + user.sqrzjhm + "%'";
            DataSet dt = DBHelper.Query(sqlstr);
            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
                Htbaxx htbaxx = new Htbaxx();
                htbaxx.gfr = dt.Tables[0].Rows[i]["乙方"].ToString();
                htbaxx.zjhm = dt.Tables[0].Rows[i]["预购人身份证件"].ToString();
                htbaxx.fwzl = dt.Tables[0].Rows[i]["开发项目名称"].ToString();
                htbaxx.htmj = dt.Tables[0].Rows[i]["预售面积"].ToString();
                htbaxx.htje = dt.Tables[0].Rows[i]["成交金额"].ToString();
                htbaxx.htlb = dt.Tables[0].Rows[i]["合同类型"].ToString();
                htbaxx.htqdsj = dt.Tables[0].Rows[i]["签订日期"].ToString();
                htbaxx.xm_match = "1";
                htbaxx.hm_match = "1";
                htbaxxs.Add(htbaxx);
            }
        }
        return htbaxxs;
    }
}

