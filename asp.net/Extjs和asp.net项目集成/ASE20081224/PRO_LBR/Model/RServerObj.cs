using System;
using System.Collections.Generic;
using System.Text;

namespace Res.Model
{
  public  class RServerObj
    {
       public  RServerObj()
       {}
      	private int _ser_svs_id;
		private DateTime _ser_come_dt;
		private string _ser_owner;
		private string _ser_po_no;
		private int _ser_tep_id;
		private int _ser_str_id;
		private string _ser_ap_list;
		private string _ser_operateuid;
		private DateTime _ser_operate_dt;

		public int SER_SVS_ID
		{
			set{ _ser_svs_id=value;}
			get{return _ser_svs_id;}
		}
      	public int SER_STR_ID
		{
			set{ _ser_str_id=value;}
			get{return _ser_str_id;}
		}
        public int SER_TEP_ID
		{
			set{ _ser_tep_id=value;}
			get{return _ser_tep_id;}
		}
      	public string SER_OWNER
		{
			set{ _ser_owner=value;}
			get{return _ser_owner;}
		}
      	public string SER_PO_NO
		{
			set{ _ser_po_no=value;}
			get{return _ser_po_no;}
		}
      	public string SER_AP_LIST
		{
			set{ _ser_ap_list=value;}
			get{return _ser_ap_list;}
		}
      public string SER_OPERATEUID  
		{
			set{ _ser_operateuid=value;}
			get{return _ser_operateuid;}
		}
      	public DateTime SER_COME_DT
		{
			set{ _ser_come_dt=value;}
			get{return _ser_come_dt;}
		}
        public DateTime SER_OPERATE_DT
		{
			set{ _ser_operate_dt=value;}
			get{return _ser_operate_dt;}
		}

    }
}
