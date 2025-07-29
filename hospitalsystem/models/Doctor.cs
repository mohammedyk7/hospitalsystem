namespace hospitalsystem.models
{
    public class Doctor : User
    {

        public int ClinicId { get; set; } = 0;

        public Doctor(string fullName, string email)
            : base(fullName, email)
        {
            Role = "Doctor";
        }

        public Doctor(string fullName, string email, int clinicId)
    : base(fullName, email)
        {
            Role = "Doctor";
            ClinicId = clinicId;
        }

        public Doctor(string fullName, string email, string password, int clinicId)
    : base(fullName, email, password)
        {
            ClinicId = clinicId;
            Role = "Doctor";
        }





        public override void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\n----- Doctor Menu -----");
                Console.WriteLine("1. View My Appointments");
                Console.WriteLine("2. Write Patient Record");
                Console.WriteLine("3. View My Records");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        ViewMyAppointments();
                        break;
                    case "2":
                        WritePatientRecord();
                        break;
                    case "3":
                        foreach (var r in HospitalData.Records.Where(r => r.DoctorName == FullName))
                            r.Display();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }
            }
        }


        public void ViewMyAppointments()
        {
            Console.WriteLine($"\nAppointments for Dr. {FullName}:\n");

            var myBookings = HospitalData.Bookings
                .Where(b => b.DoctorName.Equals(FullName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (myBookings.Count == 0)
            {
                Console.WriteLine("No appointments found.\n");
                return;
            }

            foreach (var booking in myBookings)
                booking.Display();
        }

        public void WritePatientRecord()
        {
            Console.Write("Enter Record ID: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Patient Name: ");
            string patient = Console.ReadLine()!;

            Console.Write("Enter Diagnosis: ");
            string diagnosis = Console.ReadLine()!;

            Console.Write("Enter Prescription: ");
            string prescription = Console.ReadLine()!;

            var record = new PatientRecord(id, patient, FullName, diagnosis, prescription, DateTime.Now);
            HospitalData.Records.Add(record);
            FileStorage.SaveToFile("records.json", HospitalData.Records);

            Console.WriteLine("Patient record added successfully.\n");
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

        public void Display()
        {
            Console.WriteLine($"Doctor Name: {FullName}, Email: {Email}, Clinic ID: {ClinicId}");
        }




    }
}
