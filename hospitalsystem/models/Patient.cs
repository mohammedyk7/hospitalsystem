using System.Reflection;

namespace hospitalsystem.models
{
    public class Patient : User
    {
        public Patient() : base("", "") { }
        public Patient(string fullName, string email)
            : base(fullName, email)
        {
            Role = "Patient";
        }

        public Patient(string fullName, string email, string password)
    : base(fullName, email, password)
        {
            Role = "Patient";
        }


     

        // Optional constructor for manual use
        //public Patient(string fullName, string email, string password, string nationalId, int age, string gender, string phoneNumber)
        //{
        //    Id = Guid.NewGuid().ToString();
        //    FullName = fullName;
        //    Email = email;
        //    Password = password;
        //    NationalId = nationalId;
        //    Age = age;
        //    Gender = gender;
        //    PhoneNumber = phoneNumber;
        //}


        public void BookAppointment()
        {
            Console.Write("Enter Booking ID: ");
            int bookingId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Doctor Name: ");
            string doctorName = Console.ReadLine()!;

            Console.Write("Enter Appointment Date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine()!);

            var booking = new Booking(bookingId, FullName, doctorName, clinicId, date);
            HospitalData.Bookings.Add(booking);
            FileStorage.SaveToFile("bookings.json", HospitalData.Bookings);

            Console.WriteLine("Appointment booked successfully.\n");
        }
        public void ViewMyBookings()
        {
            Console.WriteLine($"\nYour Bookings, {FullName}:");

            var myBookings = HospitalData.Bookings
                .Where(b => b.PatientEmail.Equals(FullName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (myBookings.Count == 0)
            {
                Console.WriteLine("No bookings found.\n");
                return;
            }

            foreach (var booking in myBookings)
                booking.Display();
        }


        public override void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine($"\n----- Welcome {FullName} (Patient) -----");
                Console.WriteLine("1. View My Bookings");
                Console.WriteLine("2. Book Appointment");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        ViewMyBookings();
                        break;
                    case "2":
                        BookAppointment();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }
            }
        }


    }
}
