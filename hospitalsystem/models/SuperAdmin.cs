using hospitalsystem.models;
using hospitalsystem.services;
using hospitalsystem.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    case "1": branchService.RunBranchService(); break;
                    case "2": BranchDepartmentServces.AssignDepartmentToBranch(); break;
                    case "3": DepartmentService.DisplayDepartmentMenu(); break;
                    case "4": DoctorService.ManageDoctor(); break;
                    case "5": AdminService. ManageAdmin(); break;
                    case "6": return;
                    default:
                        Console.WriteLine("Invalid option.");
                        Console.ReadKey();
                        break;
                }
            }
        }

    

     




      


   



       





      

       

    }
}
