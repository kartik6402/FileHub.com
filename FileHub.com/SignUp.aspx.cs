using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemcachedProviders.Cache;
using FileHub.com;

namespace FileHub.com
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void rdoListAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(rdoListAccType.Items[0].Selected))
            {
                pnlPayment.Visible = true;
               // DistCache.Add("Name", "Kartik");
                //string Name =(string)DistCache.Get("Name");
            }
            else
            {
                pnlPayment.Visible = false;
            }
        }

        string Username;
        string Password;
        string Email;

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Username = txtUserName.Text;
            Password = txtPassword.Text;
            Email = txtEmail.Text;
            string AccType = string.Empty;
            string SpaceAllocated = string.Empty;
            if (rdoListAccType.SelectedIndex == 0)
            {
                AccType = "Normal";
                SpaceAllocated = "102400000";
            }
            else if (rdoListAccType.SelectedIndex == 1)
            {
                AccType = "Elite";
                SpaceAllocated = "512000000";
            }
            else
            {
                AccType = "Super";
                SpaceAllocated = "1024000000";
            }
            Register reg = new Register();
            int ret = reg.RegisterUser(Username, Password, Email, AccType,SpaceAllocated);
            if(ret==-1)
            {
                lblUserNameError.Visible = true;
            }
            else
            {
                lblUserNameError.Visible = false;
                Context.Session["UserName"] = Username;
                Context.Session["AccessToken"] = null;
                Context.Response.Redirect("Home.Aspx");
            }
        }

       
    }
}