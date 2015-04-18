using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileHub.com
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string File_Name=(string)Session["FileName"];
            byte[] File_Byte=(byte[])Session["FileBytes"];

            File.WriteAllBytes("C:\\DataUsage\\" + File_Name,File_Byte);
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + File_Name);
            Response.TransmitFile("C:\\DataUsage\\" + File_Name);
            Response.End();
            //Response.Redirect("Home.aspx");

        }
    }
}