using System;
using hospitalsystem.models;

namespace hospitalsystem.services
{
    public class IDoctorService
    {
        public void ViewBookings(string doctorEmail)
        {
            Console.WriteLine("\n--- Your Bookings ---");
            var bookings = HospitalData.Bookings
                .Where(b => b.DoctorEmail == doctorEmail)
                .ToList();

            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found.");
                return;
            }

            foreach (var booking in bookings)
            {
                Console.WriteLine($"Patient: {booking.PatientName} | Date: {booking.BookingDate:dd-MM-yyyy HH:mm}");
            }
        }

        public void AddBooking(string patientName, string doctorEmail, string clinicId, DateTime bookingDate)
        {
            var booking = new Booking(patientName, doctorEmail, clinicId, bookingDate);
            HospitalData.Bookings.Add(booking);
            Console.WriteLine("Booking added successfully!");
        }

        public void CancelBooking(string patientName, string doctorEmail)
        {
            var booking = HospitalData.Bookings
                .FirstOrDefault(b => b.PatientName == patientName && b.DoctorEmail == doctorEmail);

            if (booking != null)
            {
                HospitalData.Bookings.Remove(booking);
                Console.WriteLine("Booking canceled.");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }
    }
}
