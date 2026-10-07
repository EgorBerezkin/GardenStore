using System;
using System.Collections.Generic;
using Npgsql;

namespace Librarygardenly.Categories
{
    public class CategoryService
    {
        private string connectionString = "Host=localhost;Database=GardenlyDB;Username=postgres;Encoding=UTF8";

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id, name FROM categories ORDER BY name";

                using (var command = new NpgsqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }
            return categories;
        }
        // метод для добавления новой категории
        public void AddCategory(string name)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"INSERT INTO categories (name) VALUES (@name)";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool CategoryExists(string name)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT COUNT(*) FROM categories WHERE LOWER(name) = LOWER(@name)";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
