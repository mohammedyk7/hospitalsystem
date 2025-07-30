using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace hospitalsystem.Interface
{
    public interface IDoctorService
    {
        void AddDoctor(Doctor doctor);
        List<Doctor> GetAllDoctors();
        Doctor? GetDoctorByEmail(string email);
        bool Authenticate(string email, string password);
        void DisplayDoctorMenu();
    }
}
