using System;
using System.Collections.Generic;
using System.Text;

namespace HotelModels
{

    /// <summary>
    /// 房间状态表实体Bean
    /// </summary>
    public class RoomStateBean
    {
        private int _StateId;

        public int StateId
        {
            get { return _StateId; }
            set { _StateId = value; }
        }
        private string _StateName;

        public string StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }

    }
}
