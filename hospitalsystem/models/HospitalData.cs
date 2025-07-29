namespace hospitalsystem.models
{
    public static class HospitalData
    {
        public static List<Branch> Branches { get; set; } = new();
        public static List<Department> Departments { get; set; } = new();
        public static List<BranchDepartment> BranchDepartments { get; set; } = new();
        public static List<Clinic> Clinics { get; set; } = new();
        public static List<Booking> Bookings { get; set; } = new();
        public static List<PatientRecord> Records { get; set; } = new();
        public static List<Doctor> Doctors { get; set; } = new();
        public static List<Patient> Patients { get; set; } = new();  // ✅ Added

        // ✅ Replace UserCredential with actual users (polymorphism)
        public static List<User> Users { get; set; } = new()
        {
            new SuperAdmin("Hamed", "hamed@hospital.com", "123"),
            new Admin("Fatma", "fatma@hospital.com", "123"),
            new Doctor("Dr. Ali", "ali@hospital.com", "123", 1),
            new Patient("Yusuf", "yusuf@patient.com", "123")
        };
    }
}
