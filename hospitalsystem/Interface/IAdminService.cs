using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{
    // IAdminService.cs
    public interface IAdminService
    {
        void CreateAdmin(Admin admin);
        List<Admin> GetAllAdmins();
        Admin? GetAdminByEmail(string email);
    }
}
