using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EmployeePortal.Models.Attributes
{
    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value is string password)
            {
                if (password.Length < 8 ||
                    !password.Any(char.IsUpper) ||
                    !password.Any(char.IsLower) ||
                    !password.Any(char.IsDigit))
                {
                    return new ValidationResult("Password must be at least 8 characters long and contain uppercase, lowercase, and a digit.");
                }
            }

            return ValidationResult.Success;
        }
    }
}