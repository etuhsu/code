using System;
using System.Collections.Generic;
using System.Text;

namespace HotelModels
{
    public class RoomBean
    {
        private int _RoomId;

        public int RoomId
        {
            get { return _RoomId; }
            set { _RoomId = value; }
        }
        private string _Number;

        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        private int _BedNumber;

        public int BedNumber
        {
            get { return _BedNumber; }
            set { _BedNumber = value; }
        }
        private int _TypeId;

        public int TypeId
        {
            get { return _TypeId; }
            set { _TypeId = value; }
        }
        private int _StateId;

        public int StateId
        {
            get { return _StateId; }
            set { _StateId = value; }
        }
        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

    }
}
