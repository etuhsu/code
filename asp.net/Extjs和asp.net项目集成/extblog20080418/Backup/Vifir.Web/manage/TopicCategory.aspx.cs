using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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
public partial class manage_TopicCategory : BaseAction
{
    private ITopicCategoryService service;
  
    public ITopicCategoryService Service
    {  
        set { service = value; }
    }
    public void Save()
    {
        TopicCategory t =new TopicCategory();
        ToPo(t);
        string parentId = Request.Params["parentId"];
        if (parentId != null) t.Parent = service.getTopicCategory(long.Parse(parentId));
		this.service.addTopicCategory(t);
        jsonResult =t.Id;
    }
    public void Update()
    {
        long id = long.Parse(Request.Params["id"]);
        TopicCategory obj = service.getTopicCategory(id);
        ToPo(obj);
        if (!HasError())
            service.updateTopicCategory(id, obj);
        jsonResult = true;
    }
    public void Remove()
    {
        long id = long.Parse(Request.Params["id"]);
        service.delTopicCategory(id);
        jsonResult = true;
    }
    public void GetCategory()
	{
        string id = Request.Params["id"];
        QueryObject query = new QueryObject();
        ToPo(query);
        query.PageSize = -1;
        if (id!=null && !"".Equals(id))
        {
		TopicCategory parent=this.service.getTopicCategory(long.Parse(id));
		query.addQuery("obj.Parent",parent,"=");		
		}
		else
		{
			query.addQuery("obj.Parent is NULL",null);
		}
        try
        {
            IPageList pageList = this.service.getTopicCategoryBy(query);
            String treeData = Request.Params["treeData"];
            if (treeData==null)
            {// 获得pageList的数组
                if (pageList.RowCount > 0)
                {
                    for (int i = 0; i < pageList.Result.Count; i++)
                    {
                        TopicCategory category = (TopicCategory)pageList.Result[i];
                        pageList.Result[i] = new TopicCategory(category.Id, category.Name, category.Intro);
                    }
                }
                jsonResult = pageList;
            }
            else
            {
                IList<Node> nodes = new List<Node>();
                if (pageList.RowCount > 0)
                {
                    for (int i = 0; i < pageList.Result.Count; i++)
                    {
                        TopicCategory category = (TopicCategory)pageList.Result[i];
                        nodes.Add(new Node(category));
                    }
                }
                else
                {
                    TopicCategory c = new TopicCategory();
                    c.Name = "无分类";
                    c.Id = 0;
                    nodes.Add(new Node(c));
                }
                jsonResult = (object)nodes;
            }
        }
        catch (Exception e)
        {
            Response.Write(e.Message);
            Trace.Write(e.StackTrace);
        }
		
	}

    internal class Node
    {
        private TopicCategory category;

        internal Node(TopicCategory category)
        {
            this.category = category;
        }
        public String id
        {
            get
            {
                return category.Id.ToString();
            }
        }
        public bool leaf
        {
            get
            {
                return category.Children.Count < 1;
            }
        }
        public string text
        {
            get
            {
                return category.Name;
            }
        }

        public string qtip
        {
            get
            {
                return category.Name;
            }
        }
    }

}
