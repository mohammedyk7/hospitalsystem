namespace hospitalsystem.models
{
    public class PatientRecord
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public DateTime VisitDate { get; set; }

        public PatientRecord() { } // ✅ Needed for deserialization

        public PatientRecord(int id, string patientName, string doctorName, string diagnosis, string prescription, DateTime visitDate)
        {
            Id = id;
            PatientName = patientName;
            DoctorName = doctorName;
            Diagnosis = diagnosis;
            Prescription = prescription;
            VisitDate = visitDate;
        }

        public void Display()
        {
            Console.WriteLine($"\nRecord #{Id}: {PatientName} | Dr. {DoctorName} | {VisitDate.ToShortDateString()}");
            Console.WriteLine($"Diagnosis: {Diagnosis}");
            Console.WriteLine($"Prescription: {Prescription}\n");
        }
    }
}
