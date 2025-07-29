// ─────────────────────────────
// 📁 Services/PatientService.cs
// ─────────────────────────────
using hospitalsystem.models;

namespace hospitalsystem.Services
{
    public class PatientService
    {
        public void BookAppointment(string fullName, string email)
        {
            Console.Write("Enter Appointment Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine()!);

            int id = HospitalData.Bookings.Count + 1;

            var booking = new Booking(id, fullName, email, clinicId, date);
            HospitalData.Bookings.Add(booking);

            FileStorage.SaveToFile("bookings.json", HospitalData.Bookings);

            Console.WriteLine("Appointment booked successfully.");
        }



        public static void ViewMyBookings(Patient patient)
        {
            var myBookings = HospitalData.Bookings
                .Where(b => b.PatientEmail == patient.Email)
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
