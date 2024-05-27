using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLVD_POE.Models
{
    public class LoginModel 
    {
        public static string con_string = "Server=tcp:serv-clvd-p1.database.windows.net,1433;Initial Catalog=DB-CLVD-P1;Persist Security Info=False;User ID=Spookies96;Password=Farcenutlet97;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        //Method to check if the user exists in the database and grant them access if so
        public int SelectUser(string email, string name)
        {
            int userId = -1; 
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return userId;
        }
    }
}
