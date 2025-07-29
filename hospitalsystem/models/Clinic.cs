namespace hospitalsystem.models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }

        public Clinic(int id, string name, int branchId)
        {
            Id = id;
            Name = name;
            BranchId = branchId;
        }
        public Clinic(int id, string name, int departmentId, int branchId)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
            BranchId = branchId;
        }


        public void Display()
        {
            Console.WriteLine($"Clinic #{Id}: {Name} (Branch ID: {BranchId})");
        }
    }
}
