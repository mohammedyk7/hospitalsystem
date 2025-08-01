using hospitalsystem.models;
using hospitalsystem.Interface;

namespace hospitalsystem.services
{
    public class DoctorService : IDoctorService
    {
        public Doctor _doctor;

        public DoctorService(Doctor doctor)
        {
            _doctor = doctor;
        }




        public void DisplayDoctorMenu()// This method displays the doctor's menu and handles their actions
        {
            // your doctor menu logic here
            Console.WriteLine($"👨‍⚕️ Welcome Dr. {_doctor.FullName}");
        }





        public static void ManageDoctor()// This method displays the doctor management menu and handles user input
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.WriteLine("║           DOCTOR MANAGEMENT MODULE           ║");
                Console.WriteLine("╠══════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Create Doctor                             ║");
                Console.WriteLine("║ 2. View All Doctors                          ║");
                Console.WriteLine("║ 3. Delete Doctor                             ║");
                Console.WriteLine("║ 4. Assign Doctor to Clinic                   ║");
                Console.WriteLine("║ 5. Search Doctor                             ║");
                Console.WriteLine("║ 6. Check Doctor Availability                 ║");
                Console.WriteLine("║ 7. Toggle Doctor Availability                ║");
                Console.WriteLine("║ 8. Back                                      ║");
                Console.WriteLine("╚══════════════════════════════════════════════╝");
                Console.Write("Enter your choice (1-8): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateDoctor();// This method allows the user to create a new doctor
                        break;
                    case "2":
                        ViewAllDoctors();// This method displays all doctors in the system
                        break;
                    case "3":
                        DeleteDoctor();// This method allows the user to delete a doctor by their email
                        break;
                    case "4":
                        AssignDoctorToClinic();// This method allows the user to assign a doctor to a clinic by their email
                        break;
                    case "5":
                        SearchDoctor();// This method allows the user to search for a doctor by name or email
                        break;
                    case "6":
                        CheckDoctorAvailability();// This method allows the user to check a doctor's availability by their email
                        break;
                    case "7":
                        ToggleDoctorAvailability();// This method allows the user to toggle a doctor's availability by their email
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine(" Invalid option. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }



        public static void CreateDoctor()// This method allows the user to create a new doctor
        {
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine()!.Trim();

            Console.Write("Enter Doctor Email: ");
            string email = Console.ReadLine()!.Trim();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine()!;

            // Validate clinic ID input
            int clinicId;// This variable will hold the clinic ID
            while (true)
            {
                Console.Write("Enter Clinic ID: ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out clinicId))// Try to parse the input as an integer
                    break;

                Console.WriteLine(" Invalid Clinic ID. Please enter a valid number.");
            }

            // Check for duplicate doctor
            if (HospitalData.Doctors.Any(d =>
                d.FullName.Equals(name, StringComparison.OrdinalIgnoreCase) ||
                d.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("❌ A doctor with this name or email already exists.");
                Console.ReadKey();
                return;
            }

            var doctor = new Doctor(name, email, password, clinicId);
            HospitalData.Doctors.Add(doctor);
            FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);
            Console.WriteLine("✅ Doctor added successfully.");
            Console.ReadKey();
        }





        public static void ViewAllDoctors()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                          LIST OF DOCTORS                         ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════╣");

            if (HospitalData.Doctors.Count == 0)
            {
                Console.WriteLine("║                     ❌ No doctors found.                        ║");
            }
            else
            {
                foreach (var doc in HospitalData.Doctors)
                {
                    Console.WriteLine($"║ Name     : {doc.FullName,-20} Email: {doc.Email,-25} ║");
                    Console.WriteLine($"║ ClinicID : {doc.ClinicId,-10} Available: {(doc.IsAvailable ? "✅ Yes" : "❌ No"),-10}               ║");
                    Console.WriteLine("╠──────────────────────────────────────────────────────────────────╣");
                }
            }

            Console.WriteLine("╚══════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }


        public static void ToggleDoctorAvailability()
        {
            Console.Write("Enter Doctor Email to change availability: ");
            string email = Console.ReadLine()!.Trim().ToLower();

            var doctor = HospitalData.Doctors.FirstOrDefault(d =>
                d.Email.ToLower() == email);

            if (doctor == null)
            {
                Console.WriteLine("❌ Doctor not found.");
            }
            else
            {
                doctor.IsAvailable = !doctor.IsAvailable;
                FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);
                Console.WriteLine($"✅ Availability updated to: {(doctor.IsAvailable ? "Available" : "Not Available")}");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }



        public static void DeleteDoctor()
        {
            Console.Write("Enter Doctor Email to delete: ");
            string email = Console.ReadLine()!;

            var doctor = HospitalData.Doctors.FirstOrDefault(d => d.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
            }
            else
            {
                HospitalData.Doctors.Remove(doctor);
                FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);
                Console.WriteLine("Doctor deleted successfully.");
            }
            Console.ReadKey();
        }

        public static void AssignDoctorToClinic()
        {
            Console.Write("Enter Doctor Email: ");
            string email = Console.ReadLine()!;

            var doctor = HospitalData.Doctors.FirstOrDefault(d => d.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
            }
            else
            {
                Console.Write("Enter new Clinic ID: ");
                int newClinicId = int.Parse(Console.ReadLine()!);
                doctor.ClinicId = newClinicId;
                FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);
                Console.WriteLine("Doctor assigned to new clinic.");
            }
            Console.ReadKey();
        }

        public static void SearchDoctor()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║           SEARCH FOR DOCTOR          ║");
            Console.WriteLine("╚══════════════════════════════════════╝");

            Console.Write("🔍 Enter Doctor Name or Email to search: ");
            string query = Console.ReadLine()!.Trim().ToLower();

            var matchedDoctors = HospitalData.Doctors
                .Where(d => d.FullName.ToLower().Contains(query) || d.Email.ToLower().Contains(query))
                .ToList();

            if (!matchedDoctors.Any())
            {
                Console.WriteLine("❌ No matching doctors found.");
            }
            else
            {
                Console.WriteLine("\n✅ Matching Doctors:");
                foreach (var doc in matchedDoctors)
                {
                    doc.Display();
                    Console.WriteLine("--------------------------------------------------");
                }
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        public static void CheckDoctorAvailability()
        {
            Console.Write("Enter Doctor Email: ");
            string email = Console.ReadLine()!.Trim().ToLower();

            var doctor = HospitalData.Doctors.FirstOrDefault(d =>
                d.Email.ToLower() == email);

            if (doctor == null)
            {
                Console.WriteLine("❌ Doctor not found.");
            }
            else
            {
                // For now, just a dummy availability check
                Console.WriteLine($"✅ Doctor {doctor.FullName} is currently AVAILABLE.");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }







    }
}
