using hospitalsystem.models;
using hospitalsystem.Interface;

namespace hospitalsystem.services
{
    public class PatientService : IPatientService
    {
        private Patient _patient;

        public PatientService(Patient patient)
        {
            _patient = patient;// Initialize the patient service with the logged-in patient
        }

        public void DisplayPatientMenu()// This method displays the patient management menu and handles user input
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
                Console.WriteLine("║ 4. Cancel Booking                          ║");
                Console.WriteLine("║ 5. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Choose an option (1-5): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewMyBookings();// This method displays the patient's bookings
                        break;

                    case "2":
                        ViewMyRecords();// This method displays the patient's medical records
                        break;

                    case "3":
                        BookAppointment();// This method allows the patient to book a new appointment
                        break;
                    case "4":
                        CancelBooking();// This method allows the patient to cancel an existing booking
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void BookAppointment()// This method allows the patient to book a new appointment
        {
            Console.Clear();
            Console.WriteLine("=== Book Appointment ===");

           
            Console.Write("Enter Booking ID: ");
            if (!int.TryParse(Console.ReadLine(), out int bookingId))// Validate the booking ID input
            {
                Console.WriteLine("❌ Invalid Booking ID.");
                return;
            }


            
            Console.Write("Enter Clinic ID: ");
            if (!int.TryParse(Console.ReadLine(), out int clinicId))// Validate the clinic ID input
            {
                Console.WriteLine("❌ Invalid Clinic ID.");
                return;
            }
            {
                Console.WriteLine("❌ Invalid Clinic ID.");
                return;
            }


            Console.Write("Enter Doctor Email: ");
            string doctorEmail = Console.ReadLine()!;

            Console.Write("Enter Appointment Date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine()!);// Validate the date input

            var booking = new Booking(bookingId, _patient.Email, doctorEmail, clinicId, date);// Create a new booking object
            HospitalData.Bookings.Add(booking);// Add the booking to the hospital data
            FileStorage.SaveToFile("bookings.json", HospitalData.Bookings);

            Console.WriteLine(" Appointment booked successfully!");
            Console.ReadKey();
        }

        public void ViewMyBookings()// This method displays the patient's bookings
        {
            Console.Clear();
            Console.WriteLine("=== Your Bookings ===");

            var myBookings = HospitalData.Bookings// Retrieve all bookings from the hospital data
                .Where(b => b.PatientEmail.Equals(_patient.Email, StringComparison.OrdinalIgnoreCase))// Filter bookings by the patient's email
                .ToList();

            if (!myBookings.Any())// Check if there are any bookings for the patient
            {
                Console.WriteLine("No bookings found.");
            }
            else// If there are bookings, display them
            {
                foreach (var booking in myBookings)
                    booking.Display();
            }

            Console.ReadKey();
        }

        public void ViewMyRecords()// This method displays the patient's medical records
        {
            Console.Clear();
            Console.WriteLine("=== Your Medical Records ===");

            var myRecords = HospitalData.Records// Retrieve all records from the hospital data
                .Where(r => r.PatientName.Equals(_patient.FullName, StringComparison.OrdinalIgnoreCase))// Filter records by the patient's name
                .ToList();

            if (!myRecords.Any())// Check if there are any records for the patient
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

        public void CancelBooking()
        {
            Console.Write("Enter Booking ID to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int bookingId))
            {
                Console.WriteLine("❌ Invalid ID.");
                return;
            }

            var booking = HospitalData.Bookings.FirstOrDefault(b => b.Id == bookingId && b.PatientEmail == _patient.Email && !b.IsCancelled);
            if (booking == null)
            {
                Console.WriteLine("❌ Booking not found or already cancelled.");
                return;
            }

            Console.Write("Enter cancellation reason: ");
            booking.CancellationReason = Console.ReadLine();
            booking.IsCancelled = true;
            FileStorage.SaveToFile("bookings.json", HospitalData.Bookings);
            Console.WriteLine("✅ Booking cancelled successfully.");
            Console.ReadKey();
        }

    }
}
