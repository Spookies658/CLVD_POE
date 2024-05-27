using CLVD_POE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLVD_POE.Controllers
{
    public class TransactionController : Controller
    {
        // Addes the userID and productID to the Transactions table
        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {
                
                using (SqlConnection con = new SqlConnection(ProductTable.con_string))
                {
                    
                    string sql = "INSERT INTO Transactions (userID, productID) VALUES (@UserID, @ProductID)";

                    
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        
                        con.Open();

                        
                        int rowsAffected = cmd.ExecuteNonQuery();

                        
                        con.Close();

                        
                        if (rowsAffected > 0)
                        {
                            
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            
                            return View("OrderFailed");
                        }
                    }
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}
