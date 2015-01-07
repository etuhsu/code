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
public partial class manage_Comment : BaseAction
{
    private ICommentService service;

 
    public ICommentService Service
    {  
        set { service = value; }
    }

    public void List() {
        QueryObject qo = new QueryObject();
        ToPo(qo);
		IPageList pageList = service.getCommentBy(qo);
        jsonResult=pageList;
	}

	public void Remove() {
		long id = long.Parse(Request.Params["id"]);
		service.delComment(id);
		jsonResult=true;
	}

	public void Save() {
        Comment obj = new Comment();
        ToPo(obj);
        obj.Ip=Request.Headers["Remote_Addr"];
		if (!HasError())
			service.addComment(obj);
        extFormResult = true;
	}
	
	public void Update() {
		long id = long.Parse(Request.Params["id"]);
		Comment obj = service.getComment(id);
		ToPo(obj);
		if (!HasError())
			service.updateComment(id, obj);
        extFormResult = true;
	}
}
