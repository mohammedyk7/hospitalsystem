using hospitalsystem.models;

namespace hospitalsystem.services
{
    public class AdminService
    {
        private Admin _admin;

        // Constructor to initialize AdminService with a specific Admin instance
        public AdminService(Admin admin)
        {
            _admin = admin;
        }


        public static void ManageAdmin() // This method is for managing admin operations
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║         ADMIN MANAGEMENT MENU        ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║ 1. Create Admin                      ║");
                Console.WriteLine("║ 2. View All Admins                   ║");
                Console.WriteLine("║ 3. Update Admin                      ║");
                Console.WriteLine("║ 4. Delete Admin                      ║");
                Console.WriteLine("║ 5. Search Admin by ID                ║");
                Console.WriteLine("║ 6. Exit                              ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write("Choose an option (1-6): ");

                string choice = Console.ReadLine()!;
                Console.Clear();

                switch (choice)
                {
                    case "1": CreateAdmin(); break;
                    case "2": ViewAllAdmins(); break;
                    case "3": UpdateAdmin(); break;
                    case "4": DeleteAdmin(); break;
                    case "5": SearchAdminById(); break;
                    case "6": return;
                    default:
                        Console.WriteLine("❌ Invalid choice. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void CreateAdmin()// This method allows the creation of a new admin
        {
            Console.Write("Enter Admin Full Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Admin Email: ");
            string email = Console.ReadLine()!;

            if (HospitalData.Admins.Any(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))// Check if an admin with the same email already exists
            {
                Console.WriteLine("⚠️ Admin with this email already exists.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Password: ");
            string password = Console.ReadLine()!;

            var admin = new Admin(name, email, password);
            HospitalData.Admins.Add(admin);
            FileStorage.SaveToFile("admins.json", HospitalData.Admins);

            Console.WriteLine("✅ Admin created successfully.");
            Console.ReadKey();
        }

        public static void ViewAllAdmins()
        {
            if (!HospitalData.Admins.Any())
            {
                Console.WriteLine("❌ No admins found.");
            }
            else
            {
                Console.WriteLine("📋 List of Admins:");
                foreach (var admin in HospitalData.Admins)
                {
                    Console.WriteLine($"🆔 ID: {admin.Id}, Name: {admin.FullName}, Email: {admin.Email}");
                }
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        public static void UpdateAdmin()
        {
            Console.Write("Enter Admin ID to update: ");
            string id = Console.ReadLine()!;
            var admin = HospitalData.Admins.FirstOrDefault(a => a.Id == id);

            if (admin == null)
            {
                Console.WriteLine("❌ Admin not found.");
            }
            else
            {
                Console.Write("Enter New Full Name: ");
                admin.FullName = Console.ReadLine()!;
                Console.Write("Enter New Email: ");
                admin.Email = Console.ReadLine()!;
                Console.Write("Enter New Password: ");
                admin.Password = Console.ReadLine()!;

                FileStorage.SaveToFile("admins.json", HospitalData.Admins);
                Console.WriteLine("✅ Admin updated successfully.");
            }

            Console.ReadKey();
        }

        public static void DeleteAdmin()
        {
            Console.Write("Enter Admin ID to delete: ");
            string id = Console.ReadLine()!;
            var admin = HospitalData.Admins.FirstOrDefault(a => a.Id == id);

            if (admin == null)
            {
                Console.WriteLine("❌ Admin not found.");
            }
            else
            {
                HospitalData.Admins.Remove(admin);
                FileStorage.SaveToFile("admins.json", HospitalData.Admins);
                Console.WriteLine("✅ Admin deleted.");
            }

            Console.ReadKey();
        }

        public static void SearchAdminById()
        {
            Console.Write("Enter Admin ID to search: ");
            string id = Console.ReadLine()!;
            var admin = HospitalData.Admins.FirstOrDefault(a => a.Id == id);

            if (admin == null)
            {
                Console.WriteLine("❌ Admin not found.");
            }
            else
            {
                Console.WriteLine($"🧾 Admin Info:\nID: {admin.Id}\nName: {admin.FullName}\nEmail: {admin.Email}");
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }






        public  void DisplayAdminMenu()
        {
            while (true)
            {
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine($"║      Welcome, Admin {_admin.FullName,-25} ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1.   implementation  Clinic                ║");
                Console.WriteLine("║ 2.   View All Clinics                      ║");
                Console.WriteLine("║ 3.   View All Branches                     ║");
                Console.WriteLine("║ 4.   View All Departments                  ║");
                Console.WriteLine("║ 5.   Cancel Booking                        ║");
                Console.WriteLine("║ 6.   Exit                                  ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write(" Choose an option (1-6): ");

                string? choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ClinicService clinicService = new ClinicService();

                        clinicService.DisplayClinicMenu();
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
                        CancelBookingByAdmin(); // Make sure this method exists in your AdminService
                        break;
                    case "6":
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

            int branchId;
            while (true)
            {
                Console.Write("Enter Branch ID: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out branchId))
                    break;

                Console.WriteLine("❌ Invalid input. Please enter a valid number.");
            }

            var clinic = new Clinic(id, name, branchId);

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

        public void ViewAllBranches()//
        {
            if (!HospitalData.Branches.Any())
            {
                Console.WriteLine("No branches available.");
                return;
            }

            foreach (var branch in HospitalData.Branches)//foreach branch admin can display 
                branch.Display();
        }

        public void ViewAllDepartments() //this method allows admin too view all the departments 
        {
            if (!HospitalData.Departments.Any())
            {
                Console.WriteLine("No departments available.");
                return;
            }

            foreach (var dept in HospitalData.Departments)
                dept.Display();
        }

        public void CancelBookingByAdmin()// This method allows an admin to cancel a booking
        {
            Console.Write("Enter Booking ID to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int bookingId))
            {
                Console.WriteLine(" Invalid ID.");
                return;
            }

            var booking = HospitalData.Bookings.FirstOrDefault(b => b.Id == bookingId && !b.IsCancelled);// Check if booking exists and is not already cancelled
            if (booking == null)
            {
                Console.WriteLine(" Booking not found or already cancelled.");
                return;
            }

            Console.Write("Enter cancellation reason: ");
            booking.CancellationReason = Console.ReadLine();
            booking.IsCancelled = true;
            FileStorage.SaveToFile("bookings.json", HospitalData.Bookings);
            Console.WriteLine("✅ Booking cancelled successfully by admin.");
            Console.ReadKey();
        }

    }
}
