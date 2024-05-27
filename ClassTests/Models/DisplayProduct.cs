using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CLVD_POE.Models
{
    public class DisplayProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public bool ProductAvailability { get; set; }

        public DisplayProduct() { }

        
        public DisplayProduct(int id, string name, decimal price, string category, bool availability)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
            ProductCategory = category;
            ProductAvailability = availability;
        }

        // Method to retrieve all products from the database
        public static List<DisplayProduct> SelectProducts()
        {
            List<DisplayProduct> products = new List<DisplayProduct>();

            string con_string = "Server=tcp:serv-clvd-p1.database.windows.net,1433;Initial Catalog=DB-CLVD-P1;Persist Security Info=False;User ID=;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT productID, productName, productPrice, productCategory, productAvailability FROM ProductTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DisplayProduct product = new DisplayProduct();
                    product.ProductID = Convert.ToInt32(reader["productID"]);
                    product.ProductName = Convert.ToString(reader["productName"]);
                    product.ProductPrice = Convert.ToDecimal(reader["productPrice"]);
                    product.ProductCategory = Convert.ToString(reader["productCategory"]);
                    product.ProductAvailability = Convert.ToBoolean(reader["productAvailability"]);
                    products.Add(product);
                    }
                reader.Close();
            }
                return products;
        }
            
    }
}


