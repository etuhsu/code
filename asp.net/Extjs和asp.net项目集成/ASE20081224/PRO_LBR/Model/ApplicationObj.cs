using System;
using System.Collections.Generic;
using System.Text;

namespace Res.Model
{
   public class ApplicationObj
    {
        public ApplicationObj()
		{}
        private int _app_id;
		private string _app_cause;
       private string _app_ate_id;
       private string _app_ads_id;
       private string _app_user_id;
		private DateTime _app_date;
		private string _app_from_time;
		private string _app_to_time;
		private string _app_num_time;


       private int _app_lee_ote_id;
		private string _app_creationuid;
        private DateTime _app_create_dt;
        private string _app_updateuid;
        private DateTime _app_update_dt;
		/// <summary>
		/// 
		/// </summary>

		public int APP_ID
		{
			set{ _app_id=value;}
			get{return _app_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime APP_CREATE_DT
		{
			set{ _app_create_dt=value;}
			get{return _app_create_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string APP_UPDATEUID
		{
			set{ _app_updateuid=value;}
			get{return _app_updateuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime APP_UPDATE_DT
		{
			set{ _app_update_dt=value;}
			get{return _app_update_dt;}
		}
		public int APP_LEE_OTE_ID
		{
            set { _app_lee_ote_id = value; }
            get { return _app_lee_ote_id; }
		}

		public string APP_CAUSE
		{
			set{ _app_cause=value;}
			get{return _app_cause;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string APP_ATE_ID
		{
			set{ _app_ate_id=value;}
			get{return _app_ate_id;}
		}
		/// <summary>
		/// 
		/// </summary>
       public string APP_ADS_ID
		{
			set{ _app_ads_id=value;}
			get{return _app_ads_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string APP_USER_ID
		{
			set{ _app_user_id=value;}
			get{return _app_user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime APP_DATE
		{
			set{ _app_date=value;}
			get{return _app_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string APP_FROM_TIME
		{
			set{ _app_from_time=value;}
			get{return _app_from_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string APP_TO_TIME
		{
			set{ _app_to_time=value;}
			get{return _app_to_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string APP_NUM_TIME
		{
			set{ _app_num_time=value;}
			get{return _app_num_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string APP_CREATIONUID
		{
			set{ _app_creationuid=value;}
			get{return _app_creationuid;}
		}

    }
}
