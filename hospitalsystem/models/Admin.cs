namespace hospitalsystem.models
{
    public class Admin : User
    {
     

        public Admin(string fullName, string email, string password)
    : base(fullName, email, password)
        {
            Role = "Admin";
        }


        public override void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║                ADMIN MENU            ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║    1. Assign Doctor to Clinic        ║");
                Console.WriteLine("║   2. View All Doctors                ║");
                Console.WriteLine("║    3. Exit                           ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write(" Enter your choice (1-3): ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        AssignDoctorToClinic();
                        break;
                    case "2":
                        foreach (var doc in HospitalData.Doctors)
                            Console.WriteLine($"{doc.FullName} (Clinic ID: {doc.ClinicId})");
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }
            }
        }

        public void AssignDoctorToClinic()
        {
            Console.Write("Enter Doctor's Name: ");
            string doctorName = Console.ReadLine()!;

            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine()!);

            var doctor = new Doctor(doctorName, doctorName.ToLower() + "@hospital.com");
            doctor.ClinicId = clinicId;

            HospitalData.Doctors.Add(doctor);
            FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);

            Console.WriteLine($"Doctor {doctor.FullName} assigned to Clinic {clinicId} successfully.\n");
        }

    }
}
