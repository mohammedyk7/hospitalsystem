using hospitalsystem.models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== Welcome to the Hospital Management System =====");

        // Load existing data from files (optional, if implemented)
        // HospitalData.Doctors = FileStorage.LoadFromFile<Doctor>("doctors.json");
        // HospitalData.Patients = FileStorage.LoadFromFile<Patient>("patients.json");

        while (true)
        {
            Console.WriteLine("\n--- Login ---");
            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            // Try to find the matching user
            var user = HospitalData.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                Console.WriteLine($"\n✅ Welcome {user.FullName} ({user.Role})");

                // Call the corresponding menu based on role
                user.DisplayMenu();
            }
            else
            {
                Console.WriteLine("\n❌ Invalid email or password. Try again.\n");
            }
        }
    }
}
