namespace Librarygardenly
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(int id, string fullName, string login, string password, string role)
        {
            Id = id;
            FullName = fullName;
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
