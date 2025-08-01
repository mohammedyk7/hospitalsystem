using hospitalsystem.models;
using System;
using System.Linq;

namespace hospitalsystem.models
{
    public class Doctor : User
    {
        public int ClinicId { get; set; } = 0;
        public bool IsAvailable { get; set; } = true;

        public Doctor() { }

        public Doctor(string fullName, string email)
            : base(fullName, email, "default123")
        {
            Role = "Doctor";
        }

        public Doctor(string fullName, string email, string password, int clinicId)
            : base(fullName, email, password)
        {
            Role = "Doctor";
            ClinicId = clinicId;
            IsAvailable = true;
        }



      

             public override void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║              DOCTOR MENU             ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1.    View My Appointments           ║");
                Console.WriteLine("║ 2.    Write Patient Record           ║");
                Console.WriteLine("║ 3.    View My Records                ║");
                Console.WriteLine("║ 4.    Set My Availability            ║");
                Console.WriteLine("║ 5.    Exit                           ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write(" Enter your choice (1-5): ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        ViewMyAppointments();
                        break;
                    case "2":
                        WritePatientRecord();
                        break;
                    case "3":
                        ViewMyRecords();
                        break;
                    case "4":
                        SetAvailability();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public void ViewMyAppointments()
        {
            Console.WriteLine($"\nAppointments for Dr. {FullName}:\n");

            var myBookings = HospitalData.Bookings
                .Where(b => b.DoctorEmail.Equals(Email, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (myBookings.Count == 0)
            {
                Console.WriteLine("No appointments found.\n");
                return;
            }

            foreach (var booking in myBookings)
                booking.Display();

            Console.WriteLine($"[DEBUG] Current Doctor Email: {Email}");
            Console.WriteLine($"[DEBUG] Total Bookings: {HospitalData.Bookings.Count}");

            foreach (var b in HospitalData.Bookings)
            {
                Console.WriteLine($"[DEBUG] Booking -> DoctorEmail: {b.DoctorEmail}");
            }

            Console.ReadKey();  

        }

        public void ViewMyRecords()
        {
            var myRecords = HospitalData.Records.Where(r => r.DoctorName == FullName);
            foreach (var record in myRecords)
                record.Display();

            Console.WriteLine($"[DEBUG] Current Doctor Name: {FullName}");
            Console.WriteLine($"[DEBUG] Total Records: {HospitalData.Records.Count}");

            foreach (var r in HospitalData.Records)
            {
                Console.WriteLine($"[DEBUG] Record -> DoctorName: {r.DoctorName}");
            }
            Console.ReadKey();
        }

        public void WritePatientRecord()
        {
            Console.Write("Enter Record ID: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Patient Name: ");
            string patient = Console.ReadLine()!;

            Console.Write("Enter Diagnosis: ");
            string diagnosis = Console.ReadLine()!;

            Console.Write("Enter Prescription: ");
            string prescription = Console.ReadLine()!;

            var record = new PatientRecord(id, patient, FullName, diagnosis, prescription, DateTime.Now);
            HospitalData.Records.Add(record);
            FileStorage.SaveToFile("records.json", HospitalData.Records);

            Console.WriteLine("Patient record added successfully.\n");
        }

        public void CreateDoctor()
        {
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Doctor Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine()!);

            var doctor = new Doctor(name, email, "123", clinicId);
            HospitalData.Doctors.Add(doctor);
            FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);

            Console.WriteLine("Doctor added successfully.\n");
        }

        public void Display()
        {
            Console.WriteLine($"Doctor Name: {FullName}, Email: {Email}, Clinic ID: {ClinicId}, Available: {(IsAvailable ? "✅ Yes" : "❌ No")}");
        }

        public static void ToggleDoctorAvailability()
        {
            Console.Write("Enter Doctor Email to toggle availability: ");
            string email = Console.ReadLine()!;

            var doctor = HospitalData.Doctors.FirstOrDefault(d => d.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (doctor == null)
            {
                Console.WriteLine("❌ Doctor not found.");
                return;
            }

            doctor.IsAvailable = !doctor.IsAvailable;
            FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);
            Console.WriteLine($"Doctor availability is now: {(doctor.IsAvailable ? "✅ Available" : "❌ Unavailable")}");
            Console.ReadKey();
        }

        public void SetAvailability()
        {
            Console.Write("Enter start time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime start))
            {
                Console.WriteLine("❌ Invalid start time.");
                return;
            }

            Console.Write("Enter end time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime end))
            {
                Console.WriteLine("❌ Invalid end time.");
                return;
            }

            if (end <= start)
            {
                Console.WriteLine("❌ End time must be after start time.");
                return;
            }

            var availability = new DoctorAvailability(Email, start, end);
            HospitalData.Availabilities.Add(availability);
            FileStorage.SaveToFile("availabilities.json", HospitalData.Availabilities);

            Console.WriteLine("✅ Availability set.");
            Console.ReadKey();
        }
    }





    }
