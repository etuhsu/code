using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_Score:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_Score
    {
        public Al_Score()
        { }
        #region Model
        private int _iid;
        private int _ij1;
        private int _ij2;
        private int _ij3;
        private int _ij4;
        private int _ij5;
        private int _ih1;
        private int _ih2;
        private int _ih3;
        private int _ih4;
        private int _ih5;
        private int _ig1;
        private int _ig2;
        private int _ig3;
        private int _ig4;
        private int _ig5;
        private int _ip1;
        private int _ip2;
        private int _ip3;
        private int _ip4;
        private int _ip5;
        private int _ik1;
        private int _ik2;
        private int _ik3;
        private int _ik4;
        private int _ik5;
        private int _iprojectid;
        /// <summary>
        /// 楼盘评分表 流水号 
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 交通（打分统计---1颗星）
        /// </summary>
        public int iJ1
        {
            set { _ij1 = value; }
            get { return _ij1; }
        }
        /// <summary>
        /// 交通（打分统计---2颗星）
        /// </summary>
        public int iJ2
        {
            set { _ij2 = value; }
            get { return _ij2; }
        }
        /// <summary>
        /// 交通（打分统计---3颗星）
        /// </summary>
        public int iJ3
        {
            set { _ij3 = value; }
            get { return _ij3; }
        }
        /// <summary>
        /// 交通（打分统计---4颗星）
        /// </summary>
        public int iJ4
        {
            set { _ij4 = value; }
            get { return _ij4; }
        }
        /// <summary>
        /// 交通（打分统计---5颗星）
        /// </summary>
        public int iJ5
        {
            set { _ij5 = value; }
            get { return _ij5; }
        }
        /// <summary>
        /// 环境（打分统计---1颗星）
        /// </summary>
        public int iH1
        {
            set { _ih1 = value; }
            get { return _ih1; }
        }
        /// <summary>
        /// 环境（打分统计---2颗星）
        /// </summary>
        public int iH2
        {
            set { _ih2 = value; }
            get { return _ih2; }
        }
        /// <summary>
        /// 环境（打分统计---3颗星）
        /// </summary>
        public int iH3
        {
            set { _ih3 = value; }
            get { return _ih3; }
        }
        /// <summary>
        /// 环境（打分统计---4颗星）
        /// </summary>
        public int iH4
        {
            set { _ih4 = value; }
            get { return _ih4; }
        }
        /// <summary>
        /// 环境（打分统计---5颗星）
        /// </summary>
        public int iH5
        {
            set { _ih5 = value; }
            get { return _ih5; }
        }
        /// <summary>
        /// 规划（打分统计---1颗星）
        /// </summary>
        public int iG1
        {
            set { _ig1 = value; }
            get { return _ig1; }
        }
        /// <summary>
        /// 规划（打分统计---2颗星）
        /// </summary>
        public int iG2
        {
            set { _ig2 = value; }
            get { return _ig2; }
        }
        /// <summary>
        /// 规划（打分统计---3颗星）
        /// </summary>
        public int iG3
        {
            set { _ig3 = value; }
            get { return _ig3; }
        }
        /// <summary>
        /// 规划（打分统计---4颗星）
        /// </summary>
        public int iG4
        {
            set { _ig4 = value; }
            get { return _ig4; }
        }
        /// <summary>
        /// 规划（打分统计---5颗星）
        /// </summary>
        public int iG5
        {
            set { _ig5 = value; }
            get { return _ig5; }
        }
        /// <summary>
        /// 配套（打分统计---1颗星）
        /// </summary>
        public int iP1
        {
            set { _ip1 = value; }
            get { return _ip1; }
        }
        /// <summary>
        /// 配套（打分统计---2颗星）
        /// </summary>
        public int iP2
        {
            set { _ip2 = value; }
            get { return _ip2; }
        }
        /// <summary>
        /// 配套（打分统计---3颗星）
        /// </summary>
        public int iP3
        {
            set { _ip3 = value; }
            get { return _ip3; }
        }
        /// <summary>
        /// 配套（打分统计---4颗星）
        /// </summary>
        public int iP4
        {
            set { _ip4 = value; }
            get { return _ip4; }
        }
        /// <summary>
        /// 配套（打分统计---5颗星）
        /// </summary>
        public int iP5
        {
            set { _ip5 = value; }
            get { return _ip5; }
        }
        /// <summary>
        /// 开发商（打分统计---1颗星）
        /// </summary>
        public int iK1
        {
            set { _ik1 = value; }
            get { return _ik1; }
        }
        /// <summary>
        /// 开发商（打分统计---2颗星）
        /// </summary>
        public int iK2
        {
            set { _ik2 = value; }
            get { return _ik2; }
        }
        /// <summary>
        /// 开发商（打分统计---3颗星）
        /// </summary>
        public int iK3
        {
            set { _ik3 = value; }
            get { return _ik3; }
        }
        /// <summary>
        /// 开发商（打分统计---4颗星）
        /// </summary>
        public int iK4
        {
            set { _ik4 = value; }
            get { return _ik4; }
        }
        /// <summary>
        /// 开发商（打分统计---5颗星）
        /// </summary>
        public int iK5
        {
            set { _ik5 = value; }
            get { return _ik5; }
        }
        /// <summary>
        /// 外键 取自楼盘表
        /// </summary>
        public int iProjectID
        {
            set { _iprojectid = value; }
            get { return _iprojectid; }
        }
        #endregion Model

    }
}

