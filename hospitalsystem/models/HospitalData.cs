namespace hospitalsystem.models
{
    public static class HospitalData
    {
        public static List<Branch> Branches = new();
        public static List<Department> Departments = new();
        public static List<BranchDepartment> BranchDepartments = new();
        public static List<Clinic> Clinics = new();
        public static List<Booking> Bookings = new();
        public static List<PatientRecord> Records = new();
        public static List<Doctor> Doctors { get; set; } = new();

        // ✅ Replace UserCredential with actual users (polymorphism)
        public static List<User> Users = new()
        {
            new SuperAdmin("Hamed", "hamed@hospital.com", "123"),
            new Admin("Fatma", "fatma@hospital.com", "123"),
            new Doctor("Dr. Ali", "ali@hospital.com", "123", 1),
            new Patient("Yusuf", "yusuf@patient.com", "123")
        };
    }
}
