using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileHub
{
    /// <summary>
    /// Summary description for FacebookLoginashx
    /// </summary>
    public class FacebookLoginashx : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var accessToken = context.Request["accessToken"];
            context.Session["AccessToken"] = accessToken;
            context.Session["UserName"] = null;

            context.Response.Redirect("Home.aspx");
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}