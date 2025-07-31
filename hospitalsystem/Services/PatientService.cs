using hospitalsystem.models;
using hospitalsystem.Interface;

namespace hospitalsystem.services
{
    public class PatientService : IPatientService
    {
        private Patient _patient;

        public PatientService(Patient patient)
        {
            _patient = patient;
        }

        public void DisplayPatientMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine($"║    Welcome {_patient.FullName,-30} ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. View My Bookings                        ║");
                Console.WriteLine("║ 2. View My Records                         ║");
                Console.WriteLine("║ 3. Book Appointment                        ║");
                Console.WriteLine("║ 4. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Choose an option (1-4): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewMyBookings();
                        break;

                    case "2":
                        ViewMyRecords();
                        break;

                    case "3":
                        BookAppointment();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void BookAppointment()
        {
            Console.Clear();
            Console.WriteLine("=== Book Appointment ===");

            Console.Write("Enter Booking ID: ");
            int bookingId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Doctor Email: ");
            string doctorEmail = Console.ReadLine()!;

            Console.Write("Enter Appointment Date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine()!);

            var booking = new Booking(bookingId, _patient.Email, doctorEmail, clinicId, date);
            HospitalData.Bookings.Add(booking);
            FileStorage.SaveToFile("bookings.json", HospitalData.Bookings);

            Console.WriteLine("✅ Appointment booked successfully!");
            Console.ReadKey();
        }

        public void ViewMyBookings()
        {
            Console.Clear();
            Console.WriteLine("=== Your Bookings ===");

            var myBookings = HospitalData.Bookings
                .Where(b => b.PatientEmail.Equals(_patient.Email, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!myBookings.Any())
            {
                Console.WriteLine("No bookings found.");
            }
            else
            {
                foreach (var booking in myBookings)
                    booking.Display();
            }

            Console.ReadKey();
        }

        public void ViewMyRecords()
        {
            Console.Clear();
            Console.WriteLine("=== Your Medical Records ===");

            var myRecords = HospitalData.Records
                .Where(r => r.PatientName.Equals(_patient.FullName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!myRecords.Any())
            {
                Console.WriteLine("No records found.");
            }
            else
            {
                foreach (var record in myRecords)
                    record.Display();
            }

            Console.ReadKey();
        }
    }
}
