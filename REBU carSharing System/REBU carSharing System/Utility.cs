using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace REBU_carSharing_System
{
    class Utility
    {
        public static void AddUser(string username, string password, string firstname, string lastname, string emailaddress)
        {

            using (SqlConnection openCon = new SqlConnection(ConfigurationManager.ConnectionStrings["@Data Source=DELPHI\\SQLEXPRESS;Initial Catalog=BRMCHospital;Integrated Security=True"].ConnectionString))
            {


                SqlCommand querySaveStaff = new SqlCommand("INSERT into users (Username,Password,FirstName,LastName,EmailAddress) VALUES (@Username,HASHBYTES('SHA1', CONVERT(nvarchar(4000),@Password)),@FirstName,@LastName,@EmailAddress)", openCon);
                querySaveStaff.Parameters.Add("@Username", SqlDbType.VarChar);
                querySaveStaff.Parameters["@Username"].Value = username;
                querySaveStaff.Parameters.Add("@Password", SqlDbType.VarChar);
                querySaveStaff.Parameters["@Password"].Value = password;
                querySaveStaff.Parameters.Add("@FirstName", SqlDbType.VarChar);
                querySaveStaff.Parameters["@FirstName"].Value = firstname;
                querySaveStaff.Parameters.Add("@LastName", SqlDbType.VarChar);
                querySaveStaff.Parameters["@LastName"].Value = lastname;
                querySaveStaff.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                querySaveStaff.Parameters["@EmailAddress"].Value = emailaddress;


                //   querySaveStaff.Connection = openCon;
                //   querySaveStaff.Parameters.Add("@staffName", SqlDbType.VarChar, 30).Value = name;

                openCon.Open();
                querySaveStaff.ExecuteNonQuery();
                openCon.Close();
                querySaveStaff.Dispose();

            }

        }

        public static SqlDataReader GetAListOfUsers()
        {

            using (SqlConnection openCon = new SqlConnection())
            {


                using (SqlCommand querySaveStaff = new SqlCommand("select * from users"))
                {
                    querySaveStaff.Connection = openCon;

                    openCon.Open();
                    SqlDataReader results = querySaveStaff.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    return results;
                }
            }

        }
    }
}
