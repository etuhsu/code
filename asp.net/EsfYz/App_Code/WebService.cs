using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Data;
using EsfYz;

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

    //产权信息
    [WebMethod]
    public Syqxx GetSyqxx(string cqzh, string cqr)
    {
        string sjbh, sql = "";
        Syqxx syqxx = null;
        sjbh = _GetSjbh(cqzh, cqr);
        if (sjbh != "")
        {
            sql = "select syqrmc as \"xm\",syqzh as \"cqzh\",clh,zjmc as \"zjlx\",zjhm,cqqdsj as \"fzrq\",gyqk,sjbh from fdcmain.rs_syqjbxx where sjbh='"+sjbh+"'";
            syqxx = new Syqxx();
            ToolKit toolkit = new ToolKit();
            DataRow datarow = toolkit.Get_Row(sql);
            syqxx.xm = datarow["xm"].ToString();
            syqxx.cqzh = datarow["cqzh"].ToString();
            syqxx.clh = datarow["clh"].ToString();
            syqxx.zjlx = datarow["zjlx"].ToString();
            syqxx.zjhm = datarow["zjhm"].ToString();
            syqxx.fzrq = datarow["fzrq"].ToString();
            syqxx.gyqk = datarow["gyqk"].ToString();
            syqxx.sjbh = datarow["sjbh"].ToString();
            syqxx.tdzh = toolkit.ExecuteOracleStr("select tdzh from fdcmain.rs_syqtdxx where  where sjbh='" + sjbh + "'");
            datarow = toolkit.Get_Row("select fwmc,fwzl,fwzcs as \"fwzlc\" from fdcmain.ep_jzwzjbxx where clh='" + syqxx.clh + "'");
            syqxx.fwmc = datarow["fwmc"].ToString();
            syqxx.fwzl = datarow["fwzl"].ToString();
            syqxx.fwzlc = datarow["fwzlc"].ToString();
        }
        return syqxx;
    }
    //共有情况
    [WebMethod]
    public List<Gyqxx> GetGyqxx(string cqzh, string cqr)
    {
        string sjbh, sql = "";
        Gyqxx gyqxx = null;
        List<Gyqxx> gyqxxs = null;
        sjbh = _GetSjbh(cqzh, cqr);
        if (sjbh != "")
        {
            sql = "select gyqr,zjmc,zjhm from fdcmain.rs_gyqlxx where sjbh='" + sjbh + "'";
            DataTable datatable = new ToolKit().Get_Tbl(sql);
            gyqxxs =new List<Gyqxx>();
            foreach (DataRow datarow in datatable.Rows)
            {
                gyqxx = new Gyqxx();
                gyqxx.gyqr = datarow["gyqr"].ToString();
                gyqxx.zjhm = datarow["zjhm"].ToString();
                gyqxx.zjlx = datarow["zjmc"].ToString();
                gyqxxs.Add(gyqxx);
            }
        }
        return gyqxxs;
    }
    //房屋信息
    [WebMethod]
    public List<Fwxx> GetFwxx(string cqzh, string cqr)
    {
        Fwxx fwxx = null;
        List<Fwxx> fwxxs = null;
        string sjbh,clh="",fh="";
        int n=0;
        Boolean zz = false;
        sjbh = _GetSjbh(cqzh, cqr);
        if (sjbh != "")
        {
            ToolKit toolkit = new ToolKit();
            DataTable datatable = null;
            string sql = "";
            clh = toolkit.ExecuteOracleStr("select clh from fdcmain.rs_syqfwjbxx where sjbh='" + sjbh + "'");
            string dcbz = toolkit.ExecuteOracleStr("select dcbz from fdcmain.rs_syqfwjbxx where sjbh='" + sjbh + "'");
            if (dcbz == "1")
            {
                n = toolkit.ExecuteOracleInt("select count(*) from fdcmain.rs_syqfjxx where sjbh='" + sjbh + "'");
                if (n == 1) fh = toolkit.ExecuteOracleStr("select fh from fdcmain.rs_syqfjxx where sjbh='" + sjbh + "'");
                if (fh == "总证" || fh == "整幢" || fh == "整栋")
                {
                    sql = "select fh  from fdcmain.ep_jzwfjjbxx where clh='" + clh + "'";
                    zz = true;
                }
                else
                {
                    sql = "select fh from fdcmain.rs_syqfjxx where sjbh='" + sjbh + "'";
                }

            }
            else if (dcbz == "2" || dcbz == "3")
            {
                sql = "select fh from fdcmain.rs_syqfjxx where sjbh='" + sjbh + "'";
            }
            else
            {
                return fwxxs;
            }
            datatable = toolkit.Get_Tbl(sql);
            fwxxs = new List<Fwxx>();
            foreach (DataRow datarow in datatable.Rows)
            {
                fh = datarow["fh"].ToString();
                if (zz == true)
                {
                    sql = "select fh,cb,cc,yt as \"fwyt\",jzmj,fwjg from fdcmain.ep_jzwfjjbxx where clh='" + clh + "' and fh='" + fh + "'";
                }
                else
                {
                    sql = "select fh,fwcb as \"cb\", szcs as \"cc\", yt as \"fwyt\",jzmj ,fwjg from fdcmain.rs_syqfjxx where sjbh='" + sjbh + "' and fh='" + fh + "'";
                }
                DataRow row = toolkit.Get_Row(sql);
                fwxx = new Fwxx();
                fwxx.fh = row["fh"].ToString();
                fwxx.cb = row["cb"].ToString();
                fwxx.cc = row["cc"].ToString() != "" ? row["cc"].ToString() : toolkit.ExecuteOracleStr("select cc from  fdcmain.ep_jzwfjjbxx where clh='" + clh + "' and fh='" + fh + "'");
                fwxx.fwjg = row["fwjg"].ToString();
                fwxx.jzmj = row["jzmj"].ToString();
                fwxx.yt = row["fwyt"].ToString();

                //   fwxx.fwxz = datarow["fh"].ToString();

                //  fwxx.fwzt = datarow["fh"].ToString();
               sql = "select fz,cf,dy,ky,jg,cq,qtxz,ys from fdcmain.ep_jzwfjqtxx where clh='" + clh + "' and fh='" + fh + "'";
               
                 row = toolkit.Get_Row(sql);

             fwxx.sfdy = row["dy"].ToString() == "1" || row["ky"].ToString() == "1" || row["jg"].ToString() == "1" ? "1" : "0";


                 fwxx.sfcf = row["cf"].ToString();

                fwxx.fwzt = row["cf"].ToString() == "0" && row["dy"].ToString() == "0" && row["ky"].ToString() == "0" && row["jg"].ToString() == "0" && row["fz"].ToString() == "1"?"1":"0";

                fwxx.sfzbyw = toolkit.ExecuteOracleInt(" select count(*) from fdcmain.rs_syqfjxx where clh='" + clh + "' and fh='" + fh + "' and ywbz='1'") > 0 ? "1" : "0";

 

                fwxxs.Add(fwxx);
            }

        }
        return fwxxs;
    }
    //select fh,fwcb as "cb",yt, szcs as "cc",'fwxz',yt as "fwyt",jzmj,fwjg,'fwzt','sfdy','sfcf',ywbz as "sfzbyw" from fdcmain.rs_syqfjxx where sjbh='LH1000652188';
    public string _GetSjbh(string cqzh, string cqr)
    {
        string sjbh = "", sql = "";
        sql = "  select sjbh from( " +
        " select sjbh from fdcmain.rs_syqjbxx where trim(syqrmc)='" + cqr + "' and trim(syqzh)='" + cqzh + "' and sjbh in(select sjbh from fdcmain.ep_fjywxx " +
                        " where  trim(syqr)='" + cqr + "' and trim(syqzh)='" + cqzh + "' and  ywdl not in('房屋抵押权登记','内部限制业务','内部业务','商品房预售管理','他项权利登记','限制登记','预告登记','注销登记'))"+
        " order by substr(sjbh,4,9) desc) " +
            " where rownum=1 ";
        ToolKit toolkit = new ToolKit();
        sjbh = toolkit.ExecuteOracleStr(sql);
        if (sjbh == null) sjbh = "";
        return sjbh;
    }
}


