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

public partial class PAGE_Application_DownApplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Res.BLL.ApplicationBLL bll = new Res.BLL.ApplicationBLL();
        string strWhere = "";
        if (Request["flag"] == "false")
        {
            strWhere = " APP_DISPOSED=0 ";
        }
        ExportToExcel(bll.DownApplication(strWhere), "考勤清单.xls");
    }
    protected void ExportToExcel(System.Data.DataSet ds, string fileName)
    {
        string templetFilePath;
        templetFilePath = Server.MapPath("../").ToString() + @"ExcelUpLoadFile";
        object missing = System.Reflection.Missing.Value;
        Excel.Application app;
        Excel.Workbook workBook;
        Excel.Worksheet workSheet;
        Excel.Range range;
        app = new Excel.ApplicationClass();
        app.Visible = false;
        workBook = app.Workbooks.Add(missing);
        workSheet = (Excel.Worksheet)workBook.Sheets.get_Item(1);

        int rowCount = ds.Tables[0].Rows.Count + 1; 
        int colCount = ds.Tables[0].Columns.Count;
        string[] header = new string[] { "请假", "加班", "漏刷卡", "部门", " 实际班别", "工号", "姓名", "日期", "请假、加班类型", "开始时间", "结束时间", "时数(扣除用餐时间）", "原因" };
        string[,] arr = new string[rowCount, colCount];
        for (int j = 0; j < rowCount; j++)
        {
            for (int k = 0; k < colCount; k++)
            {
                if (j == 0)
                {
                    arr[j, k] = header[k];// grid.Columns[k].HeaderText;

                }
                else
                {
                    arr[j, k] = ds.Tables[0].Rows[j-1][k].ToString();// grid.Items[j - 1].Cells[k].Text.ToString();
                }
            }
        }
        range = (Excel.Range)workSheet.Cells[1, 1];
        range = range.get_Resize(rowCount, colCount);

        range.Value2 = arr;

        workBook.SaveAs(templetFilePath + fileName, missing, missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);

        if (workBook.Saved)
        {
            workBook.Close(null, null, null);
            app.Workbooks.Close();
            app.Quit();
        }

        if (range != null)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
            range = null;
        }

        if (workSheet != null)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
            workSheet = null;
        }
        if (workBook != null)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
            workBook = null;
        }
        if (app != null)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
        }
        GC.Collect();
        DownLoadFile(templetFilePath, fileName);
    }
    //4.下载文件方法类
    /**/
    /// <summary>
    /// 下载服务器文件
    /// </summary>
    /// <param name="_FilePath">文件路径</param>
    /// <param name="_FileName">文件名</param>
    /// <returns>返回 bool型</returns>
    private bool DownLoadFile(string _FilePath, string _FileName)
    {
        try
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(_FilePath + _FileName);
            byte[] FileData = new byte[fs.Length];
            fs.Read(FileData, 0, (int)fs.Length);
            Response.Clear();
            Response.AddHeader("Content-Type", "application/ms-excel");
            string FileName = System.Web.HttpUtility.UrlEncode(System.Text.Encoding.UTF8.GetBytes(_FileName));
            Response.AddHeader("Content-Disposition", "inline;filename=" + System.Convert.ToChar(34) + FileName + System.Convert.ToChar(34));
            Response.AddHeader("Content-Length", fs.Length.ToString());
            Response.BinaryWrite(FileData);
            fs.Close();
            //删除服务器临时文件
            System.IO.File.Delete(_FilePath + _FileName);
            Response.Flush();
            Response.End();
            return true;
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
            return false;
        }
    }
}
