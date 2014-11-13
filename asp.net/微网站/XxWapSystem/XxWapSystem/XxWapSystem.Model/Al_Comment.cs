using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_Comment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_Comment
    {
        public Al_Comment()
        { }
        #region Model
        private int _iid;
        private int _iprojectid;
        private string _ctitle;
        private string _ccontent;
        private string _csort;
        private DateTime _daddtime = DateTime.Now;
        private int _iisgood;
        private int _iisbad;
        private bool _bisaudit = false;
        private string _ctype;
        private string _cname = "匿名";
        /// <summary>
        /// 标识 楼盘点评表 流水号
        /// </summary>
        public int iId
        {
            set { _iid = value; }
            get { return _iid; }
        }
        
        /// <summary>
        /// 外键 取自楼盘表
        /// </summary>
        public int iProjectId
        {
            set { _iprojectid = value; }
            get { return _iprojectid; }
        }

        /// <summary>
        /// 点评标题 
        /// </summary>
        public string cTitle
        {
            set { _ctitle = value; }
            get { return _ctitle; }
        }

        /// <summary>
        /// 点评内容 
        /// </summary>
        public string cContent
        {
            set { _ccontent = value; }
            get { return _ccontent; }
        }

        /// <summary>
        /// 点评评分 
        /// </summary>
        public string cSort
        {
            set { _csort = value; }
            get { return _csort; }
        }

        /// <summary>
        /// 点评时间
        /// </summary>
        public DateTime dAddTime
        {
            set { _daddtime = value; }
            get { return _daddtime; }
        }
        /// <summary>
        /// 说得好（数量统计）
        /// </summary>
        public int iIsGood
        {
            set { _iisgood = value; }
            get { return _iisgood; }
        }
        /// <summary>
        /// 反对 （数量统计）
        /// </summary>
        public int iIsBad
        {
            set { _iisbad = value; }
            get { return _iisbad; }
        }
        /// <summary>
        /// 是否通过审核  
        /// </summary>
        public bool bIsAudit
        {
            set { _bisaudit = value; }
            get { return _bisaudit; }
        }
        /// <summary>
        /// 评论类别（综合、价位、交通、规划、配套、开发商等等）
        /// </summary>
        public string cType
        {
            set { _ctype = value; }
            get { return _ctype; }
        }
        /// <summary>
        /// 评论人名称
        /// </summary>
        public string cName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        #endregion Model

    }
}

