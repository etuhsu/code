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
public partial class manage_User: BaseAction
{
    private IUserService service;



    public IUserService Service
    {  
        set { service = value; }
    }

    public void List()
    {
        QueryObject qo = new QueryObject();
        ToPo(qo);
        IPageList pageList = service.getUserBy(qo);
        jsonResult = pageList;
    }

    public void Remove()
    {
        long id = long.Parse(Request.Params["id"]);
        service.delUser(id);
        extFormResult = true;
    }

    public void Save()
    {
        User obj = new User();
        try
        {
            ToPo(obj);
            if (!HasError())
                service.addUser(obj);
        }
        catch (Exception e)
        {
            Response.Write(e.Message);
        }
        extFormResult = true;
    }

    public void Update()
    {
        long id = long.Parse(Request.Params["id"]);
        User obj = service.getUser(id);
        ToPo(obj);
        if (!HasError())
            service.updateUser(id, obj);
        extFormResult = true;
    }
}
