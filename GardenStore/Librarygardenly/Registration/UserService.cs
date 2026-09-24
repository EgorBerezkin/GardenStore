using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Librarygardenly.Registration
{
    public class UserService
    {
        private string connectionString = "Host=localhost;Database=GardenlyDB;Username=postgres;Encoding=UTF8";
        public List<User> userList_;

        public UserService()
        {
            userList_ = new List<User>();
            LoadUsersFromDB();
        }
        private void LoadUsersFromDB()
        {
            userList_.Clear();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT id, full_name, login, password, role FROM users";
                using (var command = new NpgsqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string fio = reader.GetString(1);
                        User user = new User(
                            reader.GetInt32(0),
                            fio,
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4)
                        );
                        userList_.Add(user);
                    }
                }
            }
            
        }
        public User AuthorizeUser(string login, string password)
        {
            return userList_.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}
