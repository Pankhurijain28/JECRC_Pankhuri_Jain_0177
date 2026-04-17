using System.ComponentModel.DataAnnotations;
using EmployeePortal.Models.Attributes;

namespace EmployeePortal.Models.Dto
{
    public class CreateEmployeeDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Department { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^\+?[1-9][0-9]{5,14}$", ErrorMessage = "Invalid phone number format.")]
        public required string Phone { get; set; }

        [Range(1000, 10000, ErrorMessage = "Salary must be between 1000 and 10000.")]
        public decimal Salary { get; set; }

        [StringLength(50)]
        [Required]
        public required AddressDto? Address { get; set; }

        [Required]
        [Range(18, 60)]
        public int Age { get; set; }
    }
}