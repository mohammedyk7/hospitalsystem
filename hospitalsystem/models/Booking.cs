using System;

namespace hospitalsystem.models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PatientEmail { get; set; }
        public string DoctorEmail { get; set; }
        public int ClinicId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Booking() { }

        public Booking(int id, string patientEmail, string doctorEmail, int clinicId, DateTime appointmentDate)
        {
            Id = id;
            PatientEmail = patientEmail;
            DoctorEmail = doctorEmail;
            ClinicId = clinicId;
            AppointmentDate = appointmentDate;
        }

        public void Display()
        {
            Console.WriteLine($"📋 Booking #{Id}: Patient {PatientEmail} with Dr. {DoctorEmail} at Clinic {ClinicId} on {AppointmentDate}");
        }
    }
}
