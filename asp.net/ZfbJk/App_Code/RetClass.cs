using System;
using System.Collections.Generic;
/// <summary>
///RetClass 的摘要说明
/// </summary>

namespace ZfbzJk
{
    public class User
    {
        public User()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public string sqrxm;                    //姓名
        public string sqrzjmc;//居民身份证 
        public string sqrzjhm;//证件号码
    }
    public class Fwcqxx
    {
        public Fwcqxx()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public string sqrxm;//申请人姓名
        public string sqrzjhm;//身份证号码
        public string cqrxm;//产权人姓名
        public string cqrzjhm;//身份证号码
        public string fwzl;//房屋坐落
        public string jzmj;//建筑面积
        public string fh;//房号
        public string cqlx;//产权类型  1,产权人    2，共有权人
        public string qssj;//起始时间	
        public string xm_match;//姓名是否和申请人完全匹配   1，匹配  0，不匹配
        public string hm_match;//号码是否和申请人证件号码完全匹配   1，匹配  0，不匹配
        public List<Gyrxx> gyrxxs;
    }
    public class Gyrxx
    {
        public string gyrxm;
        public string gyrzjhm;
    }
    public class Fwpcxx
    {
        public Fwpcxx()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public string cqlrmc;//产权人
        public string zjhm;//证件号码
        public string fwzl;//房屋坐落
        public string jzmj;//建筑面积
        
        public string jcnf;//起始时间	
         
        public string xm_match;//姓名是否和申请人完全匹配   1，匹配  0，不匹配
        public string hm_match;//号码是否和申请人证件号码完全匹配   1，匹配  0，不匹配
    }
    public class Htbaxx
    {
        public Htbaxx()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public string gfr;//购房人
        public string zjhm;//证件号码
        public string fwzl;//房屋坐落
        public string htmj;//合同面积
        public string htje;//合同金额
        public string htlb;//合同类别
        public string htqdsj;//签订时间	
        public string xm_match;//姓名是否和申请人完全匹配   1，匹配  0，不匹配
        public string hm_match;//号码是否和申请人证件号码完全匹配   1，匹配  0，不匹配
    }
    /*
    public class Cx
    {
        public Cx()
        {

        }
        List<Fwcqxx> GetFwCqxxs(List<User> users)
        {
            return new List<Fwcqxx>();
        }

        List<Htbaxx> GetHtbaxxs(List<User> users)
        {
            return new List<Htbaxx>();
        }
    }
     * */
}