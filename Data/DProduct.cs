using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;
using System.Data;

namespace Data
{
    public class DProduct
    {
        public static string connectionString = "Data Source=LAB1504-32\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=123456";
        public List<Product> Get()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                using (SqlCommand command = new SqlCommand("listarProductos", connection)) 
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = reader.GetInt32(reader.GetOrdinal("product_id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Price = reader.GetDecimal(reader.GetOrdinal("price")),
                                Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                                Active = reader.GetBoolean(reader.GetOrdinal("active"))
                            };
                            products.Add(product);
                        }
                    }

                }
                connection.Close();
            }
            return products;
        }
    }
}
