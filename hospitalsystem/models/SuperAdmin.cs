using hospitalsystem.models;

namespace hospitalsystem.models
{
    public class SuperAdmin : User
    {
        public SuperAdmin(string fullName, string email, string password)
            : base(fullName, email, password)
        {
            Role = "SuperAdmin";
        }

        public override void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║              SUPER ADMIN MENU              ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1.  Managing Branch                        ║");
                Console.WriteLine("║ 2.  Assign Department to Branch            ║");
                Console.WriteLine("║ 3.  Managing Department                    ║");
                Console.WriteLine("║ 4.  Managing Doctor                        ║");
                Console.WriteLine("║ 5.  Managing Admin                         ║");
                Console.WriteLine("║ 6.  Exit                                   ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Enter your choice (1-6): ");

                string choice = Console.ReadLine()!;
                Console.Clear();

                switch (choice)
                {
                    case "1": ManageBranch(); break;
                    case "2": AssignDepartmentToBranch(); break;
                    case "3": ManageDepartment(); break;
                    case "4": ManageDoctor(); break;
                    case "5": ManageAdmin(); break;
                    case "6": return;
                    default:
                        Console.WriteLine("Invalid option.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ManageBranch()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║            BRANCH SERVICE MENU            ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Create Branch                          ║");
                Console.WriteLine("║ 2. View ALL Branches                      ║");
                Console.WriteLine("║ 3. Update Branch                          ║");
                Console.WriteLine("║ 4. Delete Branch                          ║");
                Console.WriteLine("║ 5. Exit                                   ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Select an option (1–5): ");

                string choice = Console.ReadLine()!;
                Console.Clear();

                switch (choice)
                {
                    case "1": CreateBranch(); break;
                    case "2": ViewAllBranches(); break;
                    case "3": UpdateBranch(); break;
                    case "4": DeleteBranch(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        public void ManageDepartment()
        {
            // Add logic for create, view, delete departments
            Console.WriteLine("Department management module (create/view/delete)");
            Console.ReadKey();
        }

        

        public void ManageDoctor()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║        DOCTOR MANAGEMENT MODULE           ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Create Doctor                          ║");
                Console.WriteLine("║ 2. View All Doctors                       ║");
                Console.WriteLine("║ 3. Delete Doctor                          ║");
                Console.WriteLine("║ 4. Assign Doctor to Clinic                ║");
                Console.WriteLine("║ 5. Back                                   ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        CreateDoctor();
                        break;
                    case "2":
                        ViewAllDoctors();
                        break;
                    case "3":
                        DeleteDoctor();
                        break;
                    case "4":
                        AssignDoctorToClinic();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        public void ManageAdmin()
        {
            // Add logic for create, view admins
            Console.WriteLine("Admin management module (create/view)");
            Console.ReadKey();
        }

        public void AssignDepartmentToBranch()
        {
            Console.Write("Enter Branch ID: ");
            int branchId = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Department ID: ");
            int deptId = int.Parse(Console.ReadLine()!);

            var link = new BranchDepartment(branchId, deptId);
            HospitalData.BranchDepartments.Add(link);
            FileStorage.SaveToFile("branchDepartments.json", HospitalData.BranchDepartments);
            Console.WriteLine("Department assigned to branch.");
            Console.ReadKey();
        }

        public void CreateBranch()
        {
            Console.Write("Enter Branch ID: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Branch Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Branch Location: ");
            string location = Console.ReadLine()!;

            var branch = new Branch(id, name, location);
            HospitalData.Branches.Add(branch);
            FileStorage.SaveToFile("branches.json", HospitalData.Branches);

            Console.WriteLine("✅ Branch created successfully.\n");
        }


        public void ViewAllBranches()
        {
            if (HospitalData.Branches.Count == 0)
            {
                Console.WriteLine("No branches found.");
                return;
            }

            foreach (var b in HospitalData.Branches)
                b.Display();
        }

        public void UpdateBranch()
        {
            Console.Write("Enter Branch ID to update: ");
            int id = int.Parse(Console.ReadLine()!);

            var branch = HospitalData.Branches.FirstOrDefault(b => b.Id == id);
            if (branch == null)
            {
                Console.WriteLine("Branch not found.");
                return;
            }

            Console.Write("Enter new name: ");
            branch.Name = Console.ReadLine()!;
            Console.Write("Enter new location: ");
            branch.Location = Console.ReadLine()!;

            FileStorage.SaveToFile("branches.json", HospitalData.Branches);
            Console.WriteLine("Branch updated successfully.");
        }

        public void DeleteBranch()
        {
            Console.Write("Enter Branch ID to delete: ");
            int id = int.Parse(Console.ReadLine()!);

            var branch = HospitalData.Branches.FirstOrDefault(b => b.Id == id);
            if (branch == null)
            {
                Console.WriteLine("Branch not found.");
                return;
            }

            HospitalData.Branches.Remove(branch);
            FileStorage.SaveToFile("branches.json", HospitalData.Branches);
            Console.WriteLine("Branch deleted successfully.");
        }

        public void CreateDoctor()
        {
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Doctor Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Enter Password: ");
            string password = Console.ReadLine()!;

            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine()!);

            var doctor = new Doctor(name, email, password, clinicId);
            HospitalData.Doctors.Add(doctor);
            FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);
            Console.WriteLine("Doctor added successfully.");
            Console.ReadKey();
        }

        public void ViewAllDoctors()
        {
            if (HospitalData.Doctors.Count == 0)
            {
                Console.WriteLine("No doctors found.");
            }
            else
            {
                foreach (var doc in HospitalData.Doctors)
                    doc.Display();
            }
            Console.ReadKey();
        }

        public void DeleteDoctor()
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

        public void AssignDoctorToClinic()
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


    }
}
