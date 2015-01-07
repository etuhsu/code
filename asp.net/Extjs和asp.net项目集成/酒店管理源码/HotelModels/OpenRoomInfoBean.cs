using System;
using System.Collections.Generic;
using System.Text;

namespace HotelModels
{
    public class OpenRoomInfoBean
    {
        private int _OpenRoomId;

        public int OpenRoomId
        {
            get { return _OpenRoomId; }
            set { _OpenRoomId = value; }
        }
        private int _RoomId;

        public int RoomId
        {
            get { return _RoomId; }
            set { _RoomId = value; }
        }
        private string _GuestNumber;

        public string GuestNumber
        {
            get { return _GuestNumber; }
            set { _GuestNumber = value; }
        }
        private string _GuestName;

        public string GuestName
        {
            get { return _GuestName; }
            set { _GuestName = value; }
        }
        private double _GuestMoney;

        public double GuestMoney
        {
            get { return _GuestMoney; }
            set { _GuestMoney = value; }
        }
        private DateTime _OpenTime;

        public DateTime OpenTime
        {
            get { return _OpenTime; }
            set { _OpenTime = value; }
        }
        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

    }
}
