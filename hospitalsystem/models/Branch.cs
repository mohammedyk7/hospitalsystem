namespace hospitalsystem.models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Branch() { }

        public Branch(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        public void Display()
        {
            Console.WriteLine($"Branch #{Id}: {Name} - {Location}");
        }
    }
}