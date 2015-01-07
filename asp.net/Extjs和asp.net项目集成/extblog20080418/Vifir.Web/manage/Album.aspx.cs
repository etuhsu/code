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
    public partial class manage_Album : BaseAction
    {
        
        private IAlbumService service;
        private IAlbumCategoryService categoryService;      
      
        public IAlbumService Service
        {
            set { service = value; }
        }
        public IAlbumCategoryService CategoryService
        {
            set { categoryService = value; }
        }
        public void List()
        {
            try
            {
                QueryObject qo = new QueryObject();
                ToPo(qo);
                string categoryId = Request.Params["categoryId"];
                if (categoryId != null && !"".Equals(categoryId))
                {
                    qo.addQuery("obj.Category.id", long.Parse(categoryId), "=");
                }
                IPageList pageList = service.getAlbumBy(qo);
                jsonResult = pageList;
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                Response.Write(e.StackTrace);
            }
           
        }

        public void Remove()
        {
            long id = long.Parse(Request.Params["id"]);
            service.delAlbum(id);
            jsonResult = true;
        }

        public void Save()
        {
            Album obj = new Album();
            try
            {
                ToPo(obj);
                string CategoryId = Request.Params["CategoryId"];
                if (CategoryId != null && !"".Equals(CategoryId))
                {
                    AlbumCategory c = this.categoryService.getAlbumCategory(long.Parse(CategoryId));
                    obj.Category = c;
                }
                parseFile(obj);
                //if (!HasError())
                    service.addAlbum(obj);
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                Response.Write(e.StackTrace);
            }
            extFormResult = true;
        }

        public void Update()
        {
            long id = long.Parse(Request.Params["id"]);
            Album obj = service.getAlbum(id);
            ToPo(obj);
            string CategoryId = Request.Params["CategoryId"];
            if (CategoryId != null && !"".Equals(CategoryId))
            {
                AlbumCategory c = this.categoryService.getAlbumCategory(long.Parse(CategoryId));
                obj.Category = c;
            }
            parseFile(obj);
            if (!HasError())
                service.updateAlbum(id, obj);
            extFormResult = true;
        }
        private void parseFile(Album obj)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                string name = Request.Files[0].FileName;
                if (name.ToLower().EndsWith("jpg") || name.ToLower().EndsWith("bmp") || name.ToLower().EndsWith("jpeg") || name.ToLower().EndsWith("gif"))
                {
                    if (name.LastIndexOf('\\') > 0)
                        name = name.Substring(name.LastIndexOf('\\') + 1);
                    Request.Files[0].SaveAs(Server.MapPath("../upload/" + name));
                    obj.Path = name;
                }
                else AddError("PathFile", "文件格式不正确!");
            }
            else if (obj.Path == null) AddError("PathFile", "必须选择要上传的文件！");
        }
    }

