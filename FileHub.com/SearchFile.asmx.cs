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
    /// Summary description for SearchFile
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SearchFile : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet SearchByName(string keyword)
        {
            string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection connect= new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("Select File_Name as [File Name],File_Desc as Description,UserName as [Uploaded By],File_Bytes as[File],CAST(Round((CAST(File_Size as float)/CAST(1024000 as float)),2) as varchar)+' MB' as [Size] from UserData where File_Name like '%"+keyword+"%' AND FILE_ACCESS='Public'",connect)) 
                {
                    using (SqlDataAdapter da= new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }

                }
            }
        }



        [WebMethod]
        public DataSet SearchByUser(string UserName)
        {
            string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("Select File_Name as [File Name],File_Desc as Description,File_Access, File_Bytes as[File],CAST(Round((CAST(File_Size as float)/CAST(1024000 as float)),2) as varchar)+' MB' as [Size] from UserData where UserName = '"+UserName+"'", connect))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }

                }
            }
        }

        [WebMethod]
        public int UpdateAccess(string Filename,string UserName,string Access)
        {
            string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            int ret;
            using (SqlConnection connect = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("Update UserData Set FilE_Access='"+Access+"' where UserName ='"+UserName+"' AND File_Name = '"+Filename+"' ", connect))
                {
                    connect.Open();
                    ret=cmd.ExecuteNonQuery();
                    connect.Close();
                }
            }
            return ret;
        }

                
    }
}
