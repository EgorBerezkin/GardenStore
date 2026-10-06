using System.Collections.Generic;
using Npgsql;

namespace Librarygardenly.Products
{
    public class ProductService
    {
        private string connectionString = "Host=localhost;Database=GardenlyDB;Username=postgres;Encoding=UTF8";

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT p.id, p.name, p.category_id, c.name AS category_name, p.price, p.quantity, p.description
                    FROM products p
                    INNER JOIN categories c ON p.category_id = c.id
                    ORDER BY p.id";
                using (var command = new NpgsqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            reader.GetString(3),
                            reader.GetDouble(4),
                            reader.GetInt32(5),
                            reader.IsDBNull(6) ? "" : reader.GetString(6)
                        );
                        products.Add(product);
                    }
                }
            }
            return products;
        }
    }
}
