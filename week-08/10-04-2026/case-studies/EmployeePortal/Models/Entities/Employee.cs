using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models.Entities
{
    public class Employees
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Department { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string Phone { get; set; }

        public decimal Salary { get; set; }

        public AddressDto? Address { get; set; }
    }
}