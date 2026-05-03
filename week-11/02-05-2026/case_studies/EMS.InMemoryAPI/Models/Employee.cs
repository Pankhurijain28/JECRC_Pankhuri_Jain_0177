namespace EMS.InMemoryAPI.Models
{
    public class Employee
    {
        public int Id { get; set;  }
        public String Name { get; set; } = string.Empty;
        public String Department { get; set; } = string.Empty;
        public String Email { get; set; } = string.Empty;
        public decimal Salary { get; set; }

    }
}
