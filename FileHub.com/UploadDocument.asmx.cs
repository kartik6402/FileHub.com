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
    /// Summary description for UploadDocument
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UploadDocument : System.Web.Services.WebService
    {

        [WebMethod]
        public void Upload(string Username, string FileName, string Access, byte[] FileBytes, string FileSize,string FileDesc)
        {
            string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(conStr))
            {
                string sql = "Insert into UserData(UserName,File_Access,File_Desc,File_Name,File_Bytes,File_Size) Values(@username,@access,@filedesc,@filename,@filebyte,@filesize)";
                connect.Open();

                SqlCommand cmd = new SqlCommand(sql, connect);

                cmd.Parameters.AddWithValue("@username",Username);
                cmd.Parameters.AddWithValue("@access",Access);
                cmd.Parameters.AddWithValue("@filedesc", FileDesc);
                cmd.Parameters.AddWithValue("@filename",FileName);
                cmd.Parameters.AddWithValue("@filebyte",FileBytes);
                cmd.Parameters.AddWithValue("@filesize", FileSize);

                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }


        [WebMethod]
        public void UpdateSpace(string Username,string FileSize)
        {
            string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string ActualSpace = string.Empty;
            using (SqlConnection connect = new SqlConnection(conStr))
            {
                string sql = "Select SpaceUsed from Login where username='"+Username+"'";
                connect.Open();
                SqlCommand cmd = new SqlCommand(sql, connect);
                ActualSpace= (string)cmd.ExecuteScalar();
                connect.Close();
            }
            string UpdatedSpace = Convert.ToString(Convert.ToInt64(ActualSpace) + Convert.ToInt64(FileSize));
            using (SqlConnection connect = new SqlConnection(conStr))
            {
                string sql = "Update Login set SpaceUsed='" + UpdatedSpace + "' where username='"+Username+"'";
                connect.Open();
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }


        [WebMethod]
        public DataTable RetrieveSpace(string Username)
        {
            string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("Select CAST(Round((CAST(SpaceAllocated as float)/CAST(1024000 as float)),2) as varchar)+' MB' as [SpaceAllocated],CAST(Round((CAST(SpaceUsed as float)/CAST(1024000 as float)),2) as varchar)+' MB' as [SpaceUsed] from Login where username='" + Username + "'", connect))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds.Tables[0];
                    }

                }
            }
        }
    }
}
