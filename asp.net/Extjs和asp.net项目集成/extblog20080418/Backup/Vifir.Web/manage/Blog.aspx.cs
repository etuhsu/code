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
using Spring.Context.Support;
using Spring.Context;
public partial class manage_Blog : BaseAction
{
    private IBlogService service;

   
    public IBlogService Service
    { 
        set { service = value; }
    }
    public void Read()
    {
        Blog blog = service.getBlog();
        extFormResult = blog;
    }

    public void Update() {
		Blog obj = service.getBlog();
		ToPo(obj);
		service.updateBlog(obj);
        extFormResult = obj;
	}  
}
