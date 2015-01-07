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
public partial class manage_Topic : BaseAction
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

    public void List()
    {
        QueryObject qo = new QueryObject();
        ToPo(qo);
        string categoryId = Request.Params["categoryId"];
        if (categoryId != null && !"".Equals(categoryId))
        {
            qo.addQuery("obj.Category.id", long.Parse(categoryId), "=");
        }
        IPageList pageList = service.getTopicBy(qo);
        jsonResult = pageList;
    }

    public void Remove()
    {
        long id = long.Parse(Request.Params["id"]);
        service.delTopic(id);
        jsonResult = true;
    }

    public void Save()
    {
       Topic obj = new Topic();
       ToPo(obj);
       string CategoryId = Request.Params["CategoryId"];
       if (CategoryId != null && !"".Equals(CategoryId))
       {
         TopicCategory c = this.categoryService.getTopicCategory(long.Parse(CategoryId));
         obj.Category = c;
       }
       if (!HasError())
       service.addTopic(obj);
       extFormResult = true;
    }

    public void Update()
    {
        long id = long.Parse(Request.Params["id"]);
        Topic obj = service.getTopic(id);
        ToPo(obj);
        string CategoryId = Request.Params["CategoryId"];
        if (CategoryId != null && !"".Equals(CategoryId))
        {
            TopicCategory c = this.categoryService.getTopicCategory(long.Parse(CategoryId));
            obj.Category = c;
        }
        if (!HasError())
            service.updateTopic(id, obj);
        extFormResult = true;
    }
}
