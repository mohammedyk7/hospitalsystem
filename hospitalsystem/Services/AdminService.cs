using hospitalsystem.models;

namespace hospitalsystem.services
{
    public class AdminService
    {
        private Admin _admin;

        public AdminService(Admin admin)
        {
            _admin = admin;
        }

        public void DisplayAdminMenu()//
        {
            while (true)
            {
                
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine($"║      Welcome, Admin {_admin.FullName,-25} ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1.   Add Clinic                            ║");
                Console.WriteLine("║ 2.    View All Clinics                     ║");
                Console.WriteLine("║ 3.    View All Branches                    ║");
                Console.WriteLine("║ 4.    View All Departments                 ║");
                Console.WriteLine("║ 5.    Exit                                 ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write(" Choose an option (1-5): ");

                string? choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        AddClinic();
                        break;
                    case "2":
                        ViewAllClinics();
                        break;
                    case "3":
                        ViewAllBranches();
                        break;
                    case "4":
                        ViewAllDepartments();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

       

        public void AddClinic()
        {
            Console.Write("Enter Clinic ID: ");
            int id = int.Parse(Console.ReadLine()!);
            if (HospitalData.Clinics.Any(c => c.Id == id))
            {
                Console.WriteLine("❌ Clinic ID already exists.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Clinic Name: ");
            string name = Console.ReadLine()!;
            if (HospitalData.Clinics.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("❌ Clinic name already exists.");
                Console.ReadKey();
                return;
            }

            //Console.Write("Enter Clinic Location: ");
            Console.Write("Enter Branch ID: ");
            int branchId;
            while (true)
            {
                Console.Write("Enter Branch ID: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out branchId))
                    break;

                Console.WriteLine("❌ Invalid input. Please enter a valid number.");
            }


            var clinic = new Clinic(id, name, branchId); // ✅ passes int

            HospitalData.Clinics.Add(clinic);
            FileStorage.SaveToFile("clinics.json", HospitalData.Clinics);

            Console.WriteLine("✅ Clinic created successfully.");
            Console.ReadKey();
        }


        private void ViewAllClinics()
        {
            if (!HospitalData.Clinics.Any())
            {
                Console.WriteLine("No clinics available.");
                return;
            }

            foreach (var clinic in HospitalData.Clinics)
                clinic.Display();
        }

        private void ViewAllBranches()
        {
            if (!HospitalData.Branches.Any())
            {
                Console.WriteLine("No branches available.");
                return;
            }

            foreach (var branch in HospitalData.Branches)
                branch.Display();
        }

        private void ViewAllDepartments()
        {
            if (!HospitalData.Departments.Any())
            {
                Console.WriteLine("No departments available.");
                return;
            }

            foreach (var dept in HospitalData.Departments)
                dept.Display();
        }
    }
}
