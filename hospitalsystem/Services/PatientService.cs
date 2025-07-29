using hospitalsystem.models;

namespace hospitalsystem.Services
{
    public class PatientService
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
                Console.WriteLine($"║         Welcome {_patient.FullName,-26}   ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Book Appointment                        ║");
                Console.WriteLine("║ 2. View My Bookings                        ║");
                Console.WriteLine("║ 3. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Choose an option (1-3): ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        BookAppointment();
                        break;
                    case "2":
                        ViewMyBookings();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void BookAppointment()
        {
            Console.Write("Enter Appointment Date (yyyy-MM-dd HH:mm): ");
            DateTime date = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine()!);

            int id = HospitalData.Bookings.Count + 1;

            var booking = new Booking(id, _patient.FullName, _patient.Email, clinicId, date);
            HospitalData.Bookings.Add(booking);
            FileStorage.SaveToFile("bookings.json", HospitalData.Bookings);

            Console.WriteLine("Appointment booked successfully.");
        }

        private void ViewMyBookings()
        {
            var myBookings = HospitalData.Bookings
                .Where(b => b.PatientEmail == _patient.Email)
                .ToList();

            if (!myBookings.Any())
            {
                Console.WriteLine("No bookings found.\n");
                return;
            }

            foreach (var booking in myBookings)
                booking.Display();
        }
    }
}
