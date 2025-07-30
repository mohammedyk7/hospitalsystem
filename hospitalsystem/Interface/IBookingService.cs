using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace hospitalsystem.Interface
{
    interface IBookingService
    {
        public interface IBookingService
        {
            void AddBooking(Booking booking);
            List<Booking> GetAllBookings();
            List<Booking> GetBookingsByPatient(string patientName);
        }

    }
}
