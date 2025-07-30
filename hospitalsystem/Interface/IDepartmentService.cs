using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{
    // IDepartmentService.cs
    public interface IDepartmentService
    {
        void CreateDepartment(Department department);
        List<Department> GetAllDepartments();
        Department? GetDepartmentById(int id);
        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
    }
}