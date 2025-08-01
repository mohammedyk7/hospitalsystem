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
        public static List<Admin> Admins { get; set; } = new List<Admin>();

        public static List<DoctorAvailability> Availabilities = new();


        // ✅ Make sure patient is included in login list
        public static List<Patient> Patients { get; set; } = new()
        {
            new Patient("Yusuf", "yusuf@patient.com", "123")
        };

        // Optional: keep Users list for polymorphic user types
        public static List<User> Users { get; set; } = new()
        {
            new SuperAdmin("Hamed", "hamed@hospital.com", "123"),
            new Admin("Fatma", "fatma@hospital.com", "123"),
            new Doctor("Dr. Ali", "ali@hospital.com", "123", 1),
            // You may keep this for reference, but login reads from `Patients` list now
            new Patient("Yusuf", "yusuf@patient.com", "123")
        };
    }
}
