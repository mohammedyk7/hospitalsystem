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

        public void DisplayAdminMenu()
        {
            while (true)
            {
                Console.Clear();
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

        private void AddClinic()
        {
            try
            {
                Console.Write("Enter Clinic ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Clinic Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Department ID: ");
                int departmentId = int.Parse(Console.ReadLine());

                Console.Write("Enter Branch ID: ");
                int branchId = int.Parse(Console.ReadLine());

                var clinic = new Clinic(id, name, departmentId, branchId);
                HospitalData.Clinics.Add(clinic);

                FileStorage.SaveToFile("clinics.json", HospitalData.Clinics);
                Console.WriteLine("Clinic added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding clinic: {ex.Message}");
            }
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
