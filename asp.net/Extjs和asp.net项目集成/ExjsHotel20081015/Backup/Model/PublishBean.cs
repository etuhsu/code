using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PublishBean
    {
        public PublishBean()
        { }
        #region Model
        private int _pubid;
        private string _pubperson;
        private string _pubtitle;
        private DateTime _pubdate;
        private string _pubcontent;
        /// <summary>
        /// 
        /// </summary>
        public int pubID
        {
            set { _pubid = value; }
            get { return _pubid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pubperson
        {
            set { _pubperson = value; }
            get { return _pubperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pubTitle
        {
            set { _pubtitle = value; }
            get { return _pubtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime pubDate
        {
            set { _pubdate = value; }
            get { return _pubdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pubContent
        {
            set { _pubcontent = value; }
            get { return _pubcontent; }
        }
        #endregion Model

    }
}
