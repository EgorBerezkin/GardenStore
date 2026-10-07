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

        // метод на добавление товара в бд
        public void AddProduct(Product product)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO products (name, category_id, price, quantity, description)
                    VALUES (@name, @category_id, @price, @quantity, @description)";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@category_id", product.CategoryId);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@description", product.Description);

                    command.ExecuteNonQuery();
                }
            }
        }
        // метод редактирования данных
        public void UpdateProduct(Product product)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"UPDATE products
                       SET name = @name, category_id = @category_id, price = @price, quantity = @quantity, description = @description
                       WHERE id = @id";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", product.Id);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@category_id", product.CategoryId);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@description", product.Description);

                    command.ExecuteNonQuery();
                }
            }
        }
        // метод удаления товара
        public void DeleteProduct(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"DELETE FROM products
                       WHERE id = @id";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
