using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalsystem.models
{
    public class DoctorAvailability
    {
        public string DoctorEmail { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public DoctorAvailability() { }

        public DoctorAvailability(string email, DateTime start, DateTime end)
        {
            DoctorEmail = email;
            StartTime = start;
            EndTime = end;
        }

        public void Display()
        {
            Console.WriteLine($"🕒 {StartTime} to {EndTime}");
        }
    }
}
