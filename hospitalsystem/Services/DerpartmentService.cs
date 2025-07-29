using hospitalsystem.models;

namespace hospitalsystem.services
{
    public class DepartmentService
    {
        public void DisplayDepartmentMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║     DEPARTMENT MANAGEMENT MENU       ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1. Add Department                    ║");
                Console.WriteLine("║ 2. View All Departments              ║");
                Console.WriteLine("║ 3. Exit                              ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write("Choose an option (1-3): ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDepartment();
                        break;
                    case "2":
                        ViewDepartments();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void AddDepartment()
        {
            try
            {
                Console.Write("Enter Department ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Department Name: ");
                string name = Console.ReadLine();

                var department = new Department(id, name);
                HospitalData.Departments.Add(department);

                FileStorage.SaveToFile("departments.json", HospitalData.Departments);

                Console.WriteLine("✅ Department added and saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to add department: {ex.Message}");
            }
        }

        private void ViewDepartments()
        {
            if (!HospitalData.Departments.Any())
            {
                Console.WriteLine("No departments found.");
                return;
            }

            Console.WriteLine("\nList of Departments:");
            foreach (var dept in HospitalData.Departments)
            {
                Console.WriteLine($"ID: {dept.Id}, Name: {dept.Name}");
            }
        }
    }
}
