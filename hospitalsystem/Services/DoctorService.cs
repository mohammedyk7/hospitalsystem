using hospitalsystem.models;
using hospitalsystem.Interface;

namespace hospitalsystem.services
{
    public class DoctorService: IDoctorService
    {
        private Doctor _doctor;

        public DoctorService(Doctor doctor)
        {
            _doctor = doctor;
        }

        public void DisplayDoctorMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine($"║       Welcome Dr. {_doctor.FullName,-25}  ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. View My Bookings                        ║");
                Console.WriteLine("║ 2. Add Booking                             ║");
                Console.WriteLine("║ 3. View My Patient Records                 ║");
                Console.WriteLine("║ 4. Write Patient Record                    ║");
                Console.WriteLine("║ 5. Exit                                    ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("Choose an option (1-5): ");


                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewMyBookings();
                        break;
                    case "2":
                        AddBooking();
                        break;
                    case "3":
                        ViewMyPatientRecords();
                        break;
                    case "4":
                        WritePatientRecord();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void ViewMyBookings()
        {
            var myBookings = HospitalData.Bookings
                .Where(b => b.DoctorEmail == _doctor.Email)
                .ToList();

            if (!myBookings.Any())
            {
                Console.WriteLine("No bookings found for you.");
                return;
            }

            foreach (var booking in myBookings)
                booking.Display();
        }

        private void AddBooking()
        {
            try
            {
                Console.Write("Enter Patient Email: ");
                string patientEmail = Console.ReadLine();

                Console.Write("Enter Clinic ID: ");
                int clinicId = int.Parse(Console.ReadLine());

                Console.Write("Enter Appointment Date (yyyy-MM-dd HH:mm): ");
                DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

                int newId = HospitalData.Bookings.Count + 1;

                var booking = new Booking(
                    newId,
                    patientEmail,
                    _doctor.Email,
                    clinicId,
                    appointmentDate
                );

                HospitalData.Bookings.Add(booking);

                FileStorage.SaveToFile("bookings.json", HospitalData.Bookings);

                Console.WriteLine("Booking added and saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add booking: {ex.Message}");
            }
        }

        private void ViewMyPatientRecords()
        {
            var records = HospitalData.Records
                .Where(r => r.DoctorName.Equals(_doctor.FullName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!records.Any())
            {
                Console.WriteLine("No records found for you.");
                return;
            }

            foreach (var record in records)
                record.Display();
        }

        private void WritePatientRecord()
        {
            try
            {
                Console.Write("Enter Record ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Patient Name: ");
                string patient = Console.ReadLine();

                Console.Write("Enter Diagnosis: ");
                string diagnosis = Console.ReadLine();

                Console.Write("Enter Prescription: ");
                string prescription = Console.ReadLine();

                var record = new PatientRecord(id, patient, _doctor.FullName, diagnosis, prescription, DateTime.Now);
                HospitalData.Records.Add(record);

                FileStorage.SaveToFile("records.json", HospitalData.Records);
                Console.WriteLine("Patient record saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write record: {ex.Message}");
            }
        }
    }
}
