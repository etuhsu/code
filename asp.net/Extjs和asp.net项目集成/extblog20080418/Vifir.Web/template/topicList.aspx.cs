using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Vifir.Model.Service;
using Vifir.Core;
using Vifir.Model.Domain;
using Vifir.Web.Code;
namespace Vifir.Web.template
{

    
    
    public partial class topicList : System.Web.UI.Page
    {
        private ITopicService service;
        private ITopicCategoryService categoryService;
        public ITopicService Service
        {
            set { service = value; }
        }
        public ITopicCategoryService CategoryService
        {
            set { categoryService = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {


        }
    }
}
