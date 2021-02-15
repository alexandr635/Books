namespace Data.Entities
{
    public class User
    {
        public int Id { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }

        public int RoleId { get; protected set; }

        public Role Role { get; protected set; }

        public User()
        {

        }

        public User(int id, string login, string password, int role)
        {
            Id = id;
            Login = login;
            Password = password;
            RoleId = role;
        }

        public void SetLogin(string login)
        {
            Login = login;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetRole(int role)
        {
            RoleId = role;
        }
    }
}
