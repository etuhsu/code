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
public partial class manage_AlbumCategory : BaseAction
{
    private IAlbumCategoryService service;

 
    public IAlbumCategoryService Service
    {  
        set { service = value; }
    }
    public void Save()
    {
        AlbumCategory t = new AlbumCategory();
        ToPo(t);
        string parentId = Request.Params["parentId"];
        if (parentId != null) t.Parent = service.getAlbumCategory(long.Parse(parentId));
        this.service.addAlbumCategory(t);
        jsonResult = t.Id;
    }
    public void Update()
    {
        long id = long.Parse(Request.Params["id"]);
        AlbumCategory obj = service.getAlbumCategory(id);
        ToPo(obj);
        //Response.Write(obj.Intro);
        if (!HasError())
            service.updateAlbumCategory(id, obj);
        jsonResult = true;
    }
    public void Remove()
    {
        long id = long.Parse(Request.Params["id"]);
        service.delAlbumCategory(id);
        jsonResult = true;
    }
    public void GetCategory()
    {
        string id = Request.Params["id"];
        QueryObject query = new QueryObject();
        ToPo(query);
        query.PageSize=-1;
        if (id != null && !"".Equals(id))
        {
            AlbumCategory parent = this.service.getAlbumCategory(int.Parse(id));
            query.addQuery("obj.Parent", parent, "=");
        }
        else
        {
            query.addQuery("obj.Parent is NULL", null);
        }
        IPageList pageList = this.service.getAlbumCategoryBy(query);
        String treeData =  Request.Params["treeData"];
        if (treeData == null)
        {// 获得pageList的数组
            if (pageList.RowCount > 0)
            {
                for (int i = 0; i < pageList.Result.Count; i++)
                {
                    AlbumCategory category = (AlbumCategory)pageList.Result[i];
                    pageList.Result[i]= new AlbumCategory(category.Id, category.Name, category.Intro);
                }
            }
            jsonResult = pageList;
            //form.addResult("json", AjaxUtil.getJSON(pageList));
        }
        else
        {
            IList<Node> nodes = new List<Node>();
            if (pageList.RowCount > 0)
            {
                for (int i = 0; i < pageList.Result.Count; i++)
                {
                    AlbumCategory category = (AlbumCategory)pageList.Result[i];
                    nodes.Add(new Node(category));
                }
            }
            else
            {
                AlbumCategory c = new AlbumCategory();
                c.Name="无分类";
                c.Id = 0;
                nodes.Add(new Node(c));
            }
            //form.addResult("json", AjaxUtil.getJSON(nodes));
            jsonResult =(object) nodes;
        }
       
    }

    internal class Node
    {
        private AlbumCategory category;

        internal Node(AlbumCategory category)
        {
            this.category = category;
        }
        public String id{
            get { 
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
