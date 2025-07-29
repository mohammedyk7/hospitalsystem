
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
                Console.WriteLine("\n----- Super Admin Menu -----");
                Console.WriteLine("1. Create Branch");
                Console.WriteLine("2. Assign Department to Branch");
                Console.WriteLine("3. View All Branches");
                Console.WriteLine("4. Create Doctor");
                Console.WriteLine("5. View All Doctors");

                Console.WriteLine("6. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        CreateBranch();
                        break;
                    case "2":
                        AssignDepartmentToBranch();
                        break;
                    case "3":
                        foreach (var b in HospitalData.Branches)
                            b.Display();
                        break;

                    case "4":
                        CreateDoctor();
                        break;
                    case "5":
                        ViewAllDoctors();
                        break;

                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }
            }
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
            Console.WriteLine("Branch created successfully.\n");
        }

        public void AssignDepartmentToBranch()
        {
            Console.Write("Enter Branch ID: ");
            int branchId = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Department ID: ");
            int deptId = int.Parse(Console.ReadLine()!);

            var link = new BranchDepartment(branchId, deptId);
            HospitalData.BranchDepartments.Add(link);
            FileStorage.SaveToFile("branchDepartments.json", HospitalData.BranchDepartments); // 👈 ADD THIS
            Console.WriteLine("Department assigned to branch.\n");
        }

        public void CreateDoctor()
        {
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Doctor Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine()!);

            var doctor = new Doctor(name, email, clinicId);
            HospitalData.Doctors.Add(doctor);
            FileStorage.SaveToFile("doctors.json", HospitalData.Doctors);

            Console.WriteLine("Doctor added successfully.\n");
        }
        public void ViewAllDoctors()
        {
            if (HospitalData.Doctors.Count == 0)
            {
                Console.WriteLine("No doctors found.\n");
                return;
            }

            foreach (var doc in HospitalData.Doctors)
                doc.Display();
        }




    }
}
