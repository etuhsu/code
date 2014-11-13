using System;
using System.Collections.Generic;

/// <summary>
///RetClass 的摘要说明
/// </summary>
namespace EsfYz
{
    /*
     以下字段为存量房房屋基本信息表字段，需在接口中抛出一条或多条信息给我，以方便我将该房屋信息copy过来：
 、\、、证件类型、证件号码、房产面积、发证日期、土地证号、房号、房屋坐落、房屋性质？、房屋用途、抵押状态、抵押劝人、房屋总楼层、所在楼层、房屋结构、收件编号（测量号、房号）

 共有权人、共有权人证件类型、共有权证件号码


 产权查询列表需展示字段：
 序号、测量号、房号、产别、用途、建筑面积、房屋结构、房屋状态、是否抵押、是否查封、是否在办业务、是否挂牌（产权人姓名、产权证号）
 */
    //产权信息
    public class Syqxx
    {
        public string xm;//产权人姓名
        public string cqzh;//产权证号
        public string clh;//房屋测量号
        // public string fh;//房号
        public string zjlx;//证件类型
        public string zjhm;//证件号码
        //public string fcmj;//房产面积
        public string fzrq;//发证日期
        public string tdzh;//土地证号
        public string fwmc;//房屋名称
        public string fwzl;//房屋坐落
        // public string fwxz;//房屋性质
        // public string fwyt;//房屋用途
        //   public string dyzt;//抵押状态
        //   public string dyqr;//抵押劝人
        public string fwzlc;//房屋总楼层
        //public string szlc;//所在楼层
        // public string fwjg;//房屋结构
        public string gyqk;//共有情况
        public string sjbh;//收件编号

    }
    //共有情况
    public class Gyqxx
    {
        public string gyqr;//共有权人
        public string zjlx;//共有权人证件类型
        public string zjhm;//共有权证件号码
    }
    //房屋信息
    public class Fwxx
    {
        //public string clh;//测量号
        public string fh;//房号
        public string cb;//产别
        public string yt;//用途
        public string cc;//层次
        public string fwxz;//房屋性质
        public string jzmj;//建筑面积
        public string fwjg;//房屋结构
        public string fwzt;//房屋状态
        public string sfdy;//是否抵押
        public string sfcf;//是否查封
        public string sfzbyw;//是否在办业务
    }

    /*
     * select * from fdcmain.ep_fjywxx
where ywdl not in('房屋抵押权登记','内部限制业务','内部业务','商品房预售管理','他项权利登记','限制登记','预告登记','注销登记'
) 
     
    public static class GetToolkit
    {
        //产权信息
        public static  Syqxx GetSyqxx(string cqzh, string cqr)
        {
            return new Syqxx();
        }
        //共有情况
        public static  List<Gyqxx> GetGyqxx(string cqzh, string cqr)
        {
            return new List<Gyqxx>();
        }
        //房屋信息
        public static List<Fwxx> GetFwxx(string cqzh, string cqr)
        {
            return new List<Fwxx>();
        }

        public static string _GetSjbh()
        {
            return "";
        }
    }*/
}
