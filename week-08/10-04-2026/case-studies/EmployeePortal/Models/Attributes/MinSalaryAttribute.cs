using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models.Attributes
{
    public class MinSalaryAttribute : ValidationAttribute
    {
        private readonly double _min;

        public MinSalaryAttribute(double min)
        {
            _min = min;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is decimal salary && salary < (decimal)_min)
            {
                return new ValidationResult($"Salary must be at least {_min}");
            }

            return ValidationResult.Success;
        }
    }
}