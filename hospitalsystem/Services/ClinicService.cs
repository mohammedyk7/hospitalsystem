using hospitalsystem.models;
using hospitalsystem.Interface;
namespace hospitalsystem.services
{
    public class ClinicService : IClinicService
    {
        public void DisplayClinicMenu()// This method displays the clinic management menu and handles user input
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║        CLINIC MANAGEMENT MENU        ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1. Add Clinic                        ║");
                Console.WriteLine("║ 2. View All Clinics                  ║");
                Console.WriteLine("║ 3. Update Clinic                     ║");
                Console.WriteLine("║ 4. Delete Clinic                     ║");
                Console.WriteLine("║ 5. Search Clinic by ID               ║");
                Console.WriteLine("║ 6. Exit                              ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write("Choose an option (1-6): ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddClinic();// This method allows the user to add a new clinic
                        break;
                    case "2":
                        ViewClinics();// This method displays all clinics
                        break;
                    case "3":
                        UpdateClinic();// This method allows the user to update an existing clinic
                        break;
                    case "4":
                        DeleteClinic();// This method allows the user to delete a clinic
                        break;
                    case "5":
                        SearchClinicById();// This method allows the user to search for a clinic by its ID
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        private void AddClinic()// This method allows the user to add a new clinic
        {
            try// This try block is used to catch any exceptions that may occur during the clinic addition process
            {
                Console.Write("Enter Clinic ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Clinic Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Department ID: ");
                int departmentId = int.Parse(Console.ReadLine());

                Console.Write("Enter Branch ID: ");
                int branchId = int.Parse(Console.ReadLine());

                var clinic = new Clinic(id, name, departmentId, branchId);// This creates a new Clinic object with the provided details
                HospitalData.Clinics.Add(clinic);

                FileStorage.SaveToFile("clinics.json", HospitalData.Clinics);// This saves the updated list of clinics to a JSON file

                Console.WriteLine(" Clinic added and saved successfully.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Failed to add clinic: {ex.Message}");
                Console.ReadKey();
            }
        }

        public void ViewClinics()// This method displays all clinics in the system
        {
            if (!HospitalData.Clinics.Any())// This checks if there are any clinics in the system
            {
                Console.WriteLine("No clinics found.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nList of Clinics:");// This prints a header for the clinic list
            foreach (var clinic in HospitalData.Clinics)// This iterates through each clinic in the list
            {
                Console.WriteLine($"ID: {clinic.Id}, Name: {clinic.Name}, Dept ID: {clinic.DepartmentId}, Branch ID: {clinic.BranchId}");// This prints the details of each clinic
            }
            Console.ReadKey();
        }


        public void UpdateClinic()// This method allows the user to update an existing clinic
        {
            Console.Write("Enter Clinic ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var clinic = HospitalData.Clinics.FirstOrDefault(c => c.Id == id);// This searches for the clinic with the specified ID
                if (clinic == null)
                {
                    Console.WriteLine("❌ Clinic not found.");
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("Enter new name: ");
                    clinic.Name = Console.ReadLine();

                    Console.Write("Enter new Department ID: ");
                    clinic.DepartmentId = int.Parse(Console.ReadLine());

                    Console.Write("Enter new Branch ID: ");
                    clinic.BranchId = int.Parse(Console.ReadLine());

                    FileStorage.SaveToFile("clinics.json", HospitalData.Clinics);
                    Console.WriteLine("✅ Clinic updated successfully.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid Clinic ID.");
                Console.ReadKey();
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }




        public void DeleteClinic()
        {
            Console.Write("Enter Clinic ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var clinic = HospitalData.Clinics.FirstOrDefault(c => c.Id == id);
                if (clinic == null)
                {
                    Console.WriteLine("❌ Clinic not found.");
                    Console.ReadKey();
                }
                else
                {
                    HospitalData.Clinics.Remove(clinic);
                    FileStorage.SaveToFile("clinics.json", HospitalData.Clinics);
                    Console.WriteLine("✅ Clinic deleted.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid Clinic ID.");
                Console.ReadKey();
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        public void SearchClinicById()
        {
            Console.Write("Enter Clinic ID to search: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var clinic = HospitalData.Clinics.FirstOrDefault(c => c.Id == id);
                if (clinic == null)
                {
                    Console.WriteLine("❌ Clinic not found.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"🔍 Found Clinic:");
                    Console.WriteLine($"ID: {clinic.Id}, Name: {clinic.Name}, Dept ID: {clinic.DepartmentId}, Branch ID: {clinic.BranchId}");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid input.");
                Console.ReadKey();
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

    }
}
