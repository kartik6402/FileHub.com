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
    public partial class FilesAccess : System.Web.UI.Page
    {
        String UserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] == null)
                    Response.Redirect("index.aspx");
                else
                    UserName = Session["UserName"].ToString();

                lblGreet.Text = "Hello " + UserName;
                SearchFile srch = new SearchFile();
                GridView1.DataSource = srch.SearchByUser(UserName);
                GridView1.DataBind();

                UploadDocument up = new UploadDocument();
                DataTable dt = up.RetrieveSpace(lblGreet.Text.Substring(6));
                lblSpaceAllocated.Text = "Space Allocated : " + dt.Rows[0]["SpaceAllocated"].ToString();
                lblSpaceUsed.Text = "Space Used : " + dt.Rows[0]["SpaceUsed"].ToString();

            }
            catch (Exception ex)
            {
                Response.Redirect("index.aspx");
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Context.Session["UserName"] = UserName;
            Context.Response.Redirect("Home.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Context.Session["UserName"] = UserName;
            Context.Response.Redirect("Upload.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                SearchFile ws = new SearchFile();
                DataSet FetchedDS = ws.SearchByUser(UserName);
                byte[] File_Byte = (byte[])FetchedDS.Tables[0].Rows[index][3];
                string File_Name = FetchedDS.Tables[0].Rows[index][0].ToString();
                File.WriteAllBytes("C:\\DataUsage\\" + File_Name, File_Byte.ToArray());
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + File_Name);
                Response.TransmitFile("C:\\DataUsage\\" + File_Name);
                Response.End();
            }
            else if(e.CommandName=="ToggleAccess")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                SearchFile ws = new SearchFile();
                DataSet FetchedDS = ws.SearchByUser(UserName);
                byte[] File_Byte = (byte[])FetchedDS.Tables[0].Rows[index][3];
                string File_Name = FetchedDS.Tables[0].Rows[index][0].ToString().Trim();
                string File_Access = FetchedDS.Tables[0].Rows[index][2].ToString().Trim();
                if (File_Access.Equals("Private"))
                    File_Access = "Public";
                else
                    File_Access = "Private";
                SearchFile srch = new SearchFile();
                int ret=srch.UpdateAccess(File_Name, UserName, File_Access);
                ws = new SearchFile();
                FetchedDS = new DataSet();
                FetchedDS= ws.SearchByUser(UserName);
                GridView1.DataSource = FetchedDS.Tables[0];
                GridView1.DataBind();
                }

        }
    }
}