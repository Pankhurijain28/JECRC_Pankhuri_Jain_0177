namespace EMS.MVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        // 🔥 Fix nullable warning
        public string Name { get; set; } = string.Empty;

        public decimal Salary { get; set; }
    }
}