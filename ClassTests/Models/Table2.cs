using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ClassTests.Models
{
    public class Table2 : Controller
    { 

        public static string con_string = "Server=tcp:serv-clvd-p1.database.windows.net,1433;Initial Catalog=DB-CLVD-P1;Persist Security Info=False;User ID=Spookies96;Password=Farcenutlet97;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
