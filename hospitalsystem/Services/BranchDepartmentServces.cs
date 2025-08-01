using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalsystem.Services
{
    public class BranchDepartmentServces
    {

        public static void AssignDepartmentToBranch()
        {
            Console.Write("Enter Branch ID: ");
            int branchId = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Department ID: ");
            int deptId = int.Parse(Console.ReadLine()!);

            var link = new BranchDepartment(branchId, deptId);
            HospitalData.BranchDepartments.Add(link);
            FileStorage.SaveToFile("branchDepartments.json", HospitalData.BranchDepartments);
            Console.WriteLine("Department assigned to branch.");
            Console.ReadKey();
        }

    }
}
