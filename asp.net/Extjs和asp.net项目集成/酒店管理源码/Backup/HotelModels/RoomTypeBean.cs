using System;
using System.Collections.Generic;
using System.Text;
//该源码首发自www.51aspx.com(５１ａsｐｘ．ｃｏｍ)

namespace HotelModels
{
    public class RoomTypeBean
    {
        private int _TypeId;

        public int TypeId
        {
            get { return _TypeId; }
            set { _TypeId = value; }
        }
        private string _TypeName;

        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
        private double _TypePrice;

        public double TypePrice
        {
            get { return _TypePrice; }
            set { _TypePrice = value; }
        }
        private string _IsTv;

        public string IsTv
        {
            get { return _IsTv; }
            set { _IsTv = value; }
        }
        private string _IsKongTiao;

        public string IsKongTiao
        {
            get { return _IsKongTiao; }
            set { _IsKongTiao = value; }
        }
        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

    }
}
