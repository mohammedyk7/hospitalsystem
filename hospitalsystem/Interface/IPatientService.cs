using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalsystem.Interface
{
    interface IPatientService
    {
        public interface IPatientService
        {
            void AddPatient(Patient patient);
            List<Patient> GetAllPatients();
            Patient? GetByEmail(string email);
            bool Authenticate(string email, string password);
        }
    }
}
