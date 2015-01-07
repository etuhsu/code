using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HotelDAL;

namespace HotelBLL
{
    public class IsTableBLL
    {
        IsTableDAO itd = new IsTableDAO();


        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public string GetIsAll()
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = itd.GetIsAll();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("IsId", dr["IsId"].ToString());
                jsonHelp.AddItem("IsName", dr["IsName"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }
    }
}
