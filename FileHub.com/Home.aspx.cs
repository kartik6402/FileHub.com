using Facebook;
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
    public partial class Home : System.Web.UI.Page
    {
        string UserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    var accessToken = Session["AccessToken"].ToString();
                    var client = new FacebookClient(accessToken);
                    dynamic result = client.Get("me", new { fields = "name" });
                    UserName = result.name;
                }
                else
                {
                    UserName = Session["UserName"].ToString();
                }

                lblGreet.Text = "Hello " + UserName;

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

        protected void btnSearchFile_Click(object sender, EventArgs e)
        {
            SearchFile ws = new SearchFile();
            GridView1.DataSource = ws.SearchByName(txtSearch.Text);
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                
                int index = Convert.ToInt32(e.CommandArgument);
                string TextToSearch = txtSearch.Text.Trim();
                SearchFile ws = new SearchFile();
                DataSet FetchedDS = ws.SearchByName(txtSearch.Text);
                byte[] File_Byte = (byte[])FetchedDS.Tables[0].Rows[index][3];
                string File_Name = FetchedDS.Tables[0].Rows[index][0].ToString();
                
                Context.Session["FileName"] = File_Name;
                Context.Session["FileBytes"] = File_Byte;
                Response.Redirect("Download.aspx");

            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Context.Session["UserName"] = UserName;
            Context.Response.Redirect("Upload.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnFiles_Click(object sender, EventArgs e)
        {
            Context.Session["UserName"] = UserName;
            Context.Response.Redirect("FileAccess.aspx");
        }
    }
}