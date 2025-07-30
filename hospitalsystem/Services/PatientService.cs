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
                Console.WriteLine("║ 3. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Choose an option (1-3): ");

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
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ViewMyBookings()
        {
            var myBookings = HospitalData.Bookings
                .Where(b => b.PatientEmail == _patient.Email)
                .ToList();

            if (!myBookings.Any())
            {
                Console.WriteLine("No bookings found.");
                Console.ReadKey();
                return;
            }

            foreach (var booking in myBookings)
                booking.Display();

            Console.ReadKey();
        }

        private void ViewMyRecords()
        {
            var myRecords = HospitalData.Records
                .Where(r => r.PatientName.Equals(_patient.FullName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!myRecords.Any())
            {
                Console.WriteLine("No records found.");
                Console.ReadKey();
                return;
            }

            foreach (var record in myRecords)
                record.Display();

            Console.ReadKey();
        }
    }
}
