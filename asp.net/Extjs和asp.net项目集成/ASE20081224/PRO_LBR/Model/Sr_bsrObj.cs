using System;
using System.Collections.Generic;
using System.Text;

namespace Res.Model
{
    public class Sr_bsrObj
    {
        public Sr_bsrObj()
		{}
		#region Model
		private int _sr_id;
		private string _sr_title;
		private string _sr_proposer;
		private string _sr_client;
		private string _sr_it_cost;
		private string _sr_user_benefit;
		private int _sr_det_id;
		private int _sr_lel_id;
		private int _sr_rat_id;
		private int _sr_sye_id;
		private DateTime _sr_overdate;
		private bool _sr_sr_flag;
		private bool _sr_ar_flag;
        private bool _sr_pro_flag;
		private string _sr_demand_desc;
		private string _sr_creationuid;
		private DateTime _sr_create_dt;
		private string _sr_updateuid;
		private DateTime _sr_update_dt;
		private string _sr_standby1;
		private string _sr_standby2;
		private int _sr_standby3;
        private string _sr_code;


        private DateTime  _sr_sod_update ;
        private DateTime _sr_sod_expect;
        private int _sr_grp_id ;
        private string _sr_it_owner;

        public int SR_GRP_ID
        {
            set { _sr_grp_id = value; }
            get { return _sr_grp_id; }
        }
        public string SR_IT_OWNER
        {
            set { _sr_it_owner = value; }
            get { return _sr_it_owner; }
        }
        public DateTime SR_SOD_EXPECT
        {
            set { _sr_sod_expect = value; }
            get { return _sr_sod_expect; }
        }
        public DateTime SR_SOD_UPDATE
        {
            set { _sr_sod_update = value; }
            get { return _sr_sod_update; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int SR_ID
		{
			set{ _sr_id=value;}
			get{return _sr_id;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string SR_CODE
        {
            set { _sr_code = value; }
            get { return _sr_code; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string SR_TITLE
		{
			set{ _sr_title=value;}
			get{return _sr_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SR_PROPOSER
		{
			set{ _sr_proposer=value;}
			get{return _sr_proposer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SR_CLIENT
		{
			set{ _sr_client=value;}
			get{return _sr_client;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SR_IT_COST
		{
			set{ _sr_it_cost=value;}
			get{return _sr_it_cost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SR_USER_BENEFIT
		{
			set{ _sr_user_benefit=value;}
			get{return _sr_user_benefit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SR_DET_ID
		{
			set{ _sr_det_id=value;}
			get{return _sr_det_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SR_LEL_ID
		{
			set{ _sr_lel_id=value;}
			get{return _sr_lel_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SR_RAT_ID
		{
			set{ _sr_rat_id=value;}
			get{return _sr_rat_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SR_SYE_ID
		{
			set{ _sr_sye_id=value;}
			get{return _sr_sye_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SR_OVERDATE
		{
			set{ _sr_overdate=value;}
			get{return _sr_overdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool SR_SR_FLAG
		{
			set{ _sr_sr_flag=value;}
			get{return _sr_sr_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool SR_PRO_FLAG
		{
            set { _sr_pro_flag = value; }
            get { return _sr_pro_flag; }
		}
        /// <summary>
		/// 
		/// </summary>
		public bool SR_AR_FLAG
		{
			set{ _sr_ar_flag=value;}
			get{return _sr_ar_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SR_DEMAND_DESC
		{
			set{ _sr_demand_desc=value;}
			get{return _sr_demand_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SR_CREATIONUID
		{
			set{ _sr_creationuid=value;}
			get{return _sr_creationuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SR_CREATE_DT
		{
			set{ _sr_create_dt=value;}
			get{return _sr_create_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SR_UPDATEUID
		{
			set{ _sr_updateuid=value;}
			get{return _sr_updateuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SR_UPDATE_DT
		{
			set{ _sr_update_dt=value;}
			get{return _sr_update_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SR_standby1
		{
			set{ _sr_standby1=value;}
			get{return _sr_standby1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SR_standby2
		{
			set{ _sr_standby2=value;}
			get{return _sr_standby2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SR_standby3
		{
			set{ _sr_standby3=value;}
			get{return _sr_standby3;}
		}
		#endregion Model
    }
}
