namespace hospitalsystem.models
{
    public abstract class User
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


        public User() { }
        public User(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }




        public User(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
        }



        public abstract void DisplayMenu();
    }
}
