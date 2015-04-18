using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FileHub.com
{
    /// <summary>
    /// Summary description for Register
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Register : System.Web.Services.WebService
    {
        [WebMethod]
        public int RegisterUser(string UserName,string Password,string Email,string AccType,string SpaceAllocated)
        {
            string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("Insert Into Login(UserName,Password,Email,AccType,SpaceAllocated,SpaceUsed)values('" + UserName + "','" + Password + "','" + Email + "','" + AccType + "','" + SpaceAllocated + "','0')", connect))
                {
                    int Ret =0;
                    try
                    {
                        connect.Open();
                        Ret= cmd.ExecuteNonQuery();
                        connect.Close();
                    }
                    catch(Exception e)
                    {
                        connect.Close();
                        if(e.Message.Contains("PRIMARY KEY"))
                        {
                            Ret = -1;
                        }
                    }
                    return Ret;
                }
            }
        }

        [WebMethod]
        public int ValidateUser(string UserName, string Password)
        {
            string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("Select Count(*) from Login where Username='"+UserName+"' AND Password='"+Password+"'", connect))
                {
                    connect.Open();
                    int Count = (Int32)cmd.ExecuteScalar();
                    connect.Close();
                    return Count;
                }
            }
        }

    }



}
