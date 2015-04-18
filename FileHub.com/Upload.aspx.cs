using Facebook;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using MemcachedProviders.Cache;

namespace FileHub.com
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["UserName"] == null)
                        Response.Redirect("index.aspx");
                    else
                        UserName = Session["UserName"].ToString();

                    lblGreet.Text = "Hello " + UserName;

                   
                }
                catch (Exception ex)
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                //string Name =(string)DistCache.Get("Name");
            }

            UploadDocument up = new UploadDocument();
            DataTable dt = up.RetrieveSpace(lblGreet.Text.Substring(6));
            lblSpaceAllocated.Text = "Space Allocated : " + dt.Rows[0]["SpaceAllocated"].ToString();
            lblSpaceUsed.Text = "Space Used : " + dt.Rows[0]["SpaceUsed"].ToString();


        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Context.Session["UserName"] = lblGreet.Text.Substring(6);
            Context.Response.Redirect("Home.aspx");
        }

        protected void btnFiles_Click(object sender, EventArgs e)
        {
            Context.Session["UserName"] = lblGreet.Text.Substring(6);
            Context.Response.Redirect("FileAccess.aspx");
        }
        string UserName;
        string Filename;
        string FileDesc;
        string FileAccess;
        string FileSize;
        byte[] FileData;

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                //DistCache.Add("FileUp", FileUp.PostedFile.FileName);
                string ActualFileName = FileUp.PostedFile.FileName;
                string ext = ActualFileName.Substring(ActualFileName.LastIndexOf('.'));
                Filename = txtFileName.Text + ext;
                FileDesc = txtDesc.Text;
                if (rdoAccess.Items[0].Selected)
                    FileAccess = "Private";
                else
                    FileAccess = "Public";
                FileData = FileUp.FileBytes;
                FileSize = FileUp.PostedFile.ContentLength.ToString();
                UploadDocument ws = new UploadDocument();
                ws.Upload(lblGreet.Text.Substring(6), Filename, FileAccess, FileData, FileSize, FileDesc);
                ws.UpdateSpace(lblGreet.Text.Substring(6), FileSize);
                txtFileName.Text = string.Empty;
                txtDesc.Text = string.Empty;
                FileUp.Attributes.Clear();
                rdoAccess.Items[1].Selected = true;
                lblMessage.Text = "File Upload Successful !!!";
                lblMessage.Visible = true;

                UploadDocument up = new UploadDocument();
                DataTable dt = up.RetrieveSpace(lblGreet.Text.Substring(6));
                lblSpaceAllocated.Text = "Space Allocated : " + dt.Rows[0]["SpaceAllocated"].ToString();
                lblSpaceUsed.Text = "Space Used : " + dt.Rows[0]["SpaceUsed"].ToString();


            }
            catch(Exception ex)
            {
                lblMessage.Text = "FileName Already Exists !!!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtFileName.Text = string.Empty;
            txtDesc.Text = string.Empty;
            FileUp.Attributes.Clear();
            rdoAccess.Items[1].Selected = true;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        protected void txtFileName_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        protected void txtDesc_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        protected void FileUp_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

    }
}