using System;
namespace Res.Model
{
    [Serializable]
    public class NodeObj
    {
        #region Model
        private int _id;
        private string _name;
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        #endregion
    }
    [Serializable]
    public class ChildObj
    {
        #region Model
        private int _id;
        private string _name;
        private int _level;
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        public int Level
        {
            set { _level = value; }
            get { return _level; }
        }
        #endregion
    }
    [Serializable]
    public class NodeStrObj
    {
        #region Model
        private string _code;
        private string _name;
        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        #endregion
    }
    [Serializable]
    public class NodeIntObj
    {
        #region Model
        private int _id;
        private int _name;
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public int NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        #endregion
    }
    [Serializable]
    public class ChildExtObj
    {
        #region Model
        private int _id;
        private string _name;
        private int _childid;
        private string _childname;
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        public int ChildID
        {
            set { _childid = value; }
            get { return _childid; }
        }
        public string ChildName
        {
            set { _childname = value; }
            get { return _childname; }
        }
        #endregion
    }
    [Serializable]
    public class ImageObj
    {
        private int _img_id;
        private string _img_href;
        private string _img_title;
        private string _img_url;
        public int IMG_ID
        {
            set { _img_id = value; }
            get { return _img_id; }
        }
        public string IMG_HREF
        {
            set { _img_href = value; }
            get { return _img_href; }
        }
        public string IMG_TITLE
        {
            set { _img_title = value; }
            get { return _img_title; }
        }
        public string IMG_URL
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
    }
    [Serializable]
    public class PointRuleTypeObj
    {
        private int _PRT_ID;
        private bool _PRT_POINTADD_FLAG;
        private bool _PRT_POINTRATE_FLAG;
        private string _PRT_DESC;
        public int PRT_ID
        {
            set { _PRT_ID = value; }
            get { return _PRT_ID; }
        }
        public bool PRT_POINTADD_FLAG
        {
            set { _PRT_POINTADD_FLAG = value; }
            get { return _PRT_POINTADD_FLAG; }
        }
        public bool PRT_POINTRATE_FLAG
        {
            set { _PRT_POINTRATE_FLAG = value; }
            get { return _PRT_POINTRATE_FLAG; }
        }
        public string PRT_DESC
        {
            set { _PRT_DESC = value; }
            get { return _PRT_DESC; }
        }
    }
    [Serializable]
    public class AppObj
    {
        private int _app_id;
        private string _app_code1;
        private string _app_code2;
        private string _app_name;
        public int APP_ID
        {
            set { _app_id = value; }
            get { return _app_id; }
        }
        public string APP_CODE1
        {
            set { _app_code1 = value; }
            get { return _app_code1; }
        }
        public string APP_CODE2
        {
            set { _app_code2 = value; }
            get { return _app_code2; }
        }
        public string APP_NAME
        {
            set { _app_name = value; }
            get { return _app_name; }
        }
    }
}
