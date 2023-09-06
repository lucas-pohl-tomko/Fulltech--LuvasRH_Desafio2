namespace LuvasRH.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FederalDocument { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string Supervisor { get; set; }
        public double Salary { get; set; }
        public DateTime Admission { get; set; }
        public DateTime? Dismissal { get; set; }
        public DateTime LastModified { get; set; }

        public Employee(
            Guid id,
            string name,
            string federalDocument,
            int age,
            string role,
            string department,
            string supervisor,
            double salary,
            DateTime admission,
            DateTime? dismissal,
            DateTime lastModified)
        {
            Id = id;
            Name = name;
            FederalDocument = federalDocument;
            Age = age;
            Role = role;
            Department = department;
            Supervisor = supervisor;
            Salary = salary;
            Admission = admission;
            Dismissal = dismissal;
            LastModified = lastModified;
        }

    }
}
