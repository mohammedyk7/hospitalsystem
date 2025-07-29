using hospitalsystem.models;

namespace hospitalsystem.services
{
    public class PatientRecordService
    {
        public void DisplayRecordMenu()
        {
            while (true)
            {
                Console.WriteLine("\nPatient Records Menu:");
                Console.WriteLine("1. View All Patient Records");
                Console.WriteLine("2. Exit");

                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllRecords();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void ViewAllRecords()
        {
            if (!HospitalData.Records.Any())
            {
                Console.WriteLine("No records found.");
                return;
            }

            Console.WriteLine("\nAll Patient Records:\n");
            foreach (var record in HospitalData.Records)
            {
                record.Display();
            }
        }
    }
}
