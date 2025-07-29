namespace hospitalsystem.models
{
    public class BranchDepartment
    {
        public int BranchId { get; set; }
        public int DepartmentId { get; set; }

        public BranchDepartment(int branchId, int departmentId)
        {
            BranchId = branchId;
            DepartmentId = departmentId;
        }

        public void Display()
        {
            Console.WriteLine($"Branch ID: {BranchId} is linked to Department ID: {DepartmentId}");
        }
    }
}
