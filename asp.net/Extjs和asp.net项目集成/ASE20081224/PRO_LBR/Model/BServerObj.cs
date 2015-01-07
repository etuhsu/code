using System;
using System.Collections.Generic;
using System.Text;

namespace Res.Model
{
  public  class BServerObj
    {
        public BServerObj()
		{}
		#region Model
		private int _svs_id;
		private string _svs_shortdesc;
		private string _svs_ipaddress;
		private string _svs_creationuid;
		private DateTime _svs_create_dt;
		private string _svs_updateuid;
		private DateTime _svs_update_dt;
		private string _svs_name;
		private int _svs_smo_id;
		private int _svs_cpu_id;
		private int _svs_mey_id;
		private int _svs_had_id;
		private int _svs_aty_id;
		private int _svs_os_id;
		private string _svs_sn;
        private int _svs_str_id;//¥≈≈Ã’Û¡–¥Ê∑≈Œª÷√
		/// <summary>
		/// 
		/// </summary>
		public int SVS_ID
		{
			set{ _svs_id=value;}
			get{return _svs_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SVS_SHORTDESC
		{
			set{ _svs_shortdesc=value;}
			get{return _svs_shortdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SVS_IPADDRESS
		{
			set{ _svs_ipaddress=value;}
			get{return _svs_ipaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SVS_CREATIONUID
		{
			set{ _svs_creationuid=value;}
			get{return _svs_creationuid;}
		}
        /// <summary>
        /// ¥≈≈Ã’Û¡– ¥Ê∑≈Œª÷√
        /// </summary>
        public int SVS_STR_ID
        {
            set { _svs_str_id = value; }
            get { return _svs_str_id; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime SVS_CREATE_DT
		{
			set{ _svs_create_dt=value;}
			get{return _svs_create_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SVS_UPDATEUID
		{
			set{ _svs_updateuid=value;}
			get{return _svs_updateuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SVS_UPDATE_DT
		{
			set{ _svs_update_dt=value;}
			get{return _svs_update_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SVS_NAME
		{
			set{ _svs_name=value;}
			get{return _svs_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SVS_SMO_ID
		{
			set{ _svs_smo_id=value;}
			get{return _svs_smo_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SVS_CPU_ID
		{
			set{ _svs_cpu_id=value;}
			get{return _svs_cpu_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SVS_MEY_ID
		{
			set{ _svs_mey_id=value;}
			get{return _svs_mey_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SVS_HAD_ID
		{
			set{ _svs_had_id=value;}
			get{return _svs_had_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SVS_ATY_ID
		{
			set{ _svs_aty_id=value;}
			get{return _svs_aty_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SVS_OS_ID
		{
			set{ _svs_os_id=value;}
			get{return _svs_os_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SVS_SN
		{
			set{ _svs_sn=value;}
			get{return _svs_sn;}
		}
		#endregion Model
    }
}
