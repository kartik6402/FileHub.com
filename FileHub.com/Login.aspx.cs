using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileHub.com
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string Username;
        string Password;

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Username = txtUserName.Text;
            Password = txtPassword.Text;
            Register reg = new Register();
            int count = reg.ValidateUser(Username, Password);
            if(count==1)
            {
                lblLoginError.Visible = false;
                Context.Session["UserName"] = Username;
                Context.Session["AccessToken"] = null;
                Context.Response.Redirect("Home.aspx");
            }
            else
            {
                lblLoginError.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}