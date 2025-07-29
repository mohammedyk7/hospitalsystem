namespace hospitalsystem.models
{
    public class UserCredential
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }

        public UserCredential(string email, string password, string role, string name)
        {
            Email = email;
            Password = password;
            Role = role;
            Name = name;
        }
    }
}
