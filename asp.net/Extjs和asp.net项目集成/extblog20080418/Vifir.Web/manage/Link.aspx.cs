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
public partial class manage_Link : BaseAction
{
    private ILinkService service;

  
    public ILinkService Service
    {
        set { service = value; }
    }

    public void List()
    {
        QueryObject qo = new QueryObject();
        ToPo(qo);
        IPageList pageList = service.getLinkBy(qo);
        jsonResult = pageList;
    }

    public void Remove()
    {
        long id = long.Parse(Request.Params["id"]);
        service.delLink(id);
        jsonResult = true;
    }

    public void Save()
    {
        Link obj = new Link();
        ToPo(obj);
        if (!HasError())
            service.addLink(obj);
        extFormResult = true;
    }

    public void Update()
    {
        long id = long.Parse(Request.Params["id"]);
        Link obj = service.getLink(id);
        ToPo(obj);
        if (!HasError())
            service.updateLink(id, obj);
        extFormResult = true;
    }
}
