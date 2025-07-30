using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{
    // ISuperAdminService.cs
    public interface ISuperAdminService
    {
        void CreateSuperAdmin(SuperAdmin superAdmin);
        List<SuperAdmin> GetAllSuperAdmins();
        SuperAdmin? GetSuperAdminByEmail(string email);

        // Additional methods based on your diagram:
        void CreateBranch(Branch branch);
        void AssignDepartmentToBranch(int departmentId, int branchId);
        void AssignBranchToDepartment(int branchId, int departmentId);
        void AssignDoctorToClinic(int doctorId, int clinicId);

        List<Branch> GetAllBranches();
        List<Department> GetAllDepartments();
        List<Doctor> GetAllDoctors();
    }
}
