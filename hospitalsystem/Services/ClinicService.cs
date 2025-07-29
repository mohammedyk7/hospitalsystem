using hospitalsystem.models;

namespace hospitalsystem.services
{
    public class ClinicService
    {
        public void DisplayClinicMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║        CLINIC MANAGEMENT MENU        ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1. Add Clinic                        ║");
                Console.WriteLine("║ 2. View All Clinics                  ║");
                Console.WriteLine("║ 3. Exit                              ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write("Choose an option (1-3): ");


                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddClinic();
                        break;
                    case "2":
                        ViewClinics();
                        break;
                    case "3":
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

                Console.WriteLine("✅ Clinic added and saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to add clinic: {ex.Message}");
            }
        }

        private void ViewClinics()
        {
            if (!HospitalData.Clinics.Any())
            {
                Console.WriteLine("No clinics found.");
                return;
            }

            Console.WriteLine("\nList of Clinics:");
            foreach (var clinic in HospitalData.Clinics)
            {
                Console.WriteLine($"ID: {clinic.Id}, Name: {clinic.Name}, Dept ID: {clinic.DepartmentId}, Branch ID: {clinic.BranchId}");
            }
        }
    }
}
