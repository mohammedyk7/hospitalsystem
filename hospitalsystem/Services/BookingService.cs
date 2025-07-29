using hospitalsystem.models;

namespace hospitalsystem.services
{
    public class BookingService
    {
        public void DisplayBookingMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║       BOOKING MANAGEMENT MENU        ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1. View All Bookings                 ║");
                Console.WriteLine("║ 2. Exit                              ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write("Choose an option (1-2): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllBookings();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void ViewAllBookings()
        {
            if (!HospitalData.Bookings.Any())
            {
                Console.WriteLine("No bookings found.");
                return;
            }

            Console.WriteLine("\nList of All Bookings:");
            foreach (var booking in HospitalData.Bookings)
            {
                booking.Display();
            }
        }
    }
}
