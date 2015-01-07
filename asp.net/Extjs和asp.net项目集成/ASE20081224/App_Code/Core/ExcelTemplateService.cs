using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Collections.Generic;
namespace Res.Service.ExcelTemplate
{
    /// <summary>
    /// ExcelTemplateService 的摘要说明
    /// </summary>
    public class ExcelTemplateService
    {
        private string Html;
        private int column;
        public ExcelTemplateService(string filename)
        {
            Html="";
            column=0;
            this.LoadTemplate(filename);
        }
        private void LoadTemplate(string filename)
        {
            StringBuilder result = new StringBuilder();
            FileStream myfs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            using (StreamReader sr = new StreamReader(myfs, Encoding.UTF8))
            {
                while (sr.Peek() >= 0)
                {
                    result.Append(sr.ReadLine());
                }
            }
            myfs.Close();
            Html = result.ToString();
        }
        public void SetTitle(string title)
        {
            Html=Html.Replace("$TITLE", title);
        }
        public void SetHeader(string[] headers)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<tr>");
            foreach (string name in headers)
            {
                result.Append("<td width=\"100\" align=\"center\" class=\"title\"><B>");
                result.Append(name);
                result.Append("</B></td>");
            }
            result.Append("</tr>");
            column=headers.Length;
            Html=Html.Replace("$HEADER$", result.ToString());
        }
        public void SetData(SqlDataReader reader, string[] styles)
        {
            StringBuilder result = new StringBuilder();
            while (reader.Read())
            {
                StringBuilder lines = new StringBuilder();
                lines.Append("<tr>");
                for (int i = 0; i < column; i++)
                {
                    lines.Append("<td class=\"");
                    lines.Append(styles[i]);
                    lines.Append("\">");
                    lines.Append(reader.GetValue(i).ToString());
                    lines.Append("</td>");
                }
                lines.Append("</tr>");
                result.Append(lines);
            }
            Html=Html.Replace("$DATA$", result.ToString());
        }
        public string GetHtml()
        {
            return Html;
        }
    }
}
