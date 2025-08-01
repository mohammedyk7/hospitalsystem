﻿using hospitalsystem.Interface;
using hospitalsystem.models;
using hospitalsystem.services;
using hospitalsystem.Services;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Load data from files
        HospitalData.Doctors = FileStorage.LoadFromFile<Doctor>("doctors.json");
        HospitalData.Patients = FileStorage.LoadFromFile<Patient>("patients.json");
        HospitalData.Bookings = FileStorage.LoadFromFile<Booking>("bookings.json");
        HospitalData.Records = FileStorage.LoadFromFile<PatientRecord>("records.json");
        HospitalData.Branches = FileStorage.LoadFromFile<Branch>("branches.json");
        HospitalData.Departments = FileStorage.LoadFromFile<Department>("departments.json");
        HospitalData.Clinics = FileStorage.LoadFromFile<Clinic>("clinics.json");
        HospitalData.Admins = FileStorage.LoadFromFile<Admin>("admins.json");
        HospitalData.Availabilities = FileStorage.LoadFromFile<DoctorAvailability>("availabilities.json");


        // Ensure at least one test patient exists
        if (!HospitalData.Patients.Any(p => p.Email == "yusuf@patient.com"))
        {
            HospitalData.Patients.Add(new Patient("Yusuf", "yusuf@patient.com", "123"));
            FileStorage.SaveToFile("patients.json", HospitalData.Patients);
        }

        Console.WriteLine($"Patients: {HospitalData.Patients.Count}");
        Console.WriteLine($"Bookings: {HospitalData.Bookings.Count}");
        Console.WriteLine($"Records: {HospitalData.Records.Count}");
        Console.WriteLine($"Branches: {HospitalData.Branches.Count}");
        Console.WriteLine($"Departments: {HospitalData.Departments.Count}");
        Console.WriteLine($"Clinics: {HospitalData.Clinics.Count}");
        Console.WriteLine($"Admins: {HospitalData.Admins.Count}"); // Optional: for debug

        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║      WELCOME TO SILAF HOSPITAL SYSTEM      ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Super Admin Login                       ║");
            Console.WriteLine("║ 2. Doctor Login                            ║");
            Console.WriteLine("║ 3. Patient Login                           ║");
            Console.WriteLine("║ 4. Admin Login                             ║");
            Console.WriteLine("║ 5. Patient Sign Up                         ║");
            Console.WriteLine("║ 6. Exit                                    ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.Write("Select an option (1-6): ");

            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    SuperAdmin superAdmin = new SuperAdmin("Main Admin", "admin@hospital.com", "admin123");
                    superAdmin.DisplayMenu();
                    break;

           case "2":
                    Console.Write("Enter your email: ");
                    string dEmail = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string dPassword = Console.ReadLine();

                    Doctor? doctor = HospitalData.Doctors.FirstOrDefault(d => d.Email == dEmail && d.Password == dPassword);

                    if (doctor != null)
                    {
                       doctor.DisplayMenu();
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid doctor credentials.");
                        Console.ReadKey();
                    }
                    break;

                case "3":
                    Console.Write("Enter your email: ");
                    string pEmail = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string pPassword = Console.ReadLine();

                    Patient? patient = HospitalData.Patients.FirstOrDefault(p => p.Email == pEmail );
                    if (patient != null)
                    {
                        IPatientService pService = new PatientService(patient);
                        pService.DisplayPatientMenu();
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid patient credentials.");
                        Console.ReadKey();
                    }
                    break;

                case "4":
                    Console.Write("Enter your email: ");
                    string aEmail = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string aPassword = Console.ReadLine();

                    // ✅ FIX: use HospitalData.Admins directly
                    Admin? admin = HospitalData.Admins
                        .FirstOrDefault(a => a.Email == aEmail && a.Password == aPassword);

                    if (admin != null)
                    {
                        AdminService aService = new AdminService(admin);
                        aService.DisplayAdminMenu();
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid admin credentials.");
                        Console.ReadKey();
                    }
                    break;

                case "5":
                    SignUpPatient();
                    break;

                case "6":
                    Console.WriteLine("Exiting system. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void SignUpPatient()
    {
        Console.Clear();
        Console.WriteLine("=== PATIENT SIGN UP ===");

        Console.Write("Full Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Password: ");
        string password = Console.ReadLine()!;

        var existing = HospitalData.Patients.FirstOrDefault(p => p.Email == email);
        if (existing != null)
        {
            Console.WriteLine("❌ This email is already registered.");
            Console.ReadKey();
            return;
        }

        var patient = new Patient(name, email, password);
        HospitalData.Patients.Add(patient);
        FileStorage.SaveToFile("patients.json", HospitalData.Patients);

        Console.WriteLine("✅ Patient account created successfully!");
        Console.ReadKey();
    }
}
