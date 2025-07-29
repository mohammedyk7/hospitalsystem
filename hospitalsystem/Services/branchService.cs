using System;
using System.Collections.Generic;
using hospitalsystem.models;

namespace hospitalsystem.services
{
    public static class branchService
    {
        public static void SeedData()
        {
            // Branches
            HospitalData.Branches.AddRange(new List<Branch>
            {
                new Branch(1, "Main Branch", "Muscat"),
                new Branch(2, "North Branch", "Sohar")
            });

            // Departments
            HospitalData.Departments.AddRange(new List<Department>
            {
                new Department(1, "Cardiology"),
                new Department(2, "Neurology")
            });

            // BranchDepartments
            HospitalData.BranchDepartments.AddRange(new List<BranchDepartment>
            {
                new BranchDepartment(1, 1),
                new BranchDepartment(2, 2)
            });

            // Clinics
            HospitalData.Clinics.AddRange(new List<Clinic>
            {
                new Clinic(1, "Heart Clinic", 1),
                new Clinic(2, "Brain Clinic", 2)
            });

            // Bookings
            HospitalData.Bookings.AddRange(new List<Booking>
            {
                new Booking(1, "yusuf@patient.com", "ali@hospital.com", 1, DateTime.Now.AddDays(2)),
                new Booking(2, "yusuf@patient.com", "ali@hospital.com", 2, DateTime.Now.AddDays(3))
            });
        }
    }
}
