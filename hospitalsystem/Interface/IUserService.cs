using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{
    public interface IUserService
    {
        void CreateUser(User user);
        User? GetUserByEmail(string email);
        List<User> GetAllUsers();
    }
}