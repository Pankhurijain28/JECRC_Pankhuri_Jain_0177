using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models.Attributes
{
    public class RangeSalaryAttribute : ValidationAttribute
    {
        private readonly double _min;
        private readonly double _max;

        public RangeSalaryAttribute(double min, double max)
        {
            _min = min;
            _max = max;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is decimal salary &&
                (salary < (decimal)_min || salary > (decimal)_max))
            {
                return new ValidationResult($"Salary must be between {_min} and {_max}");
            }

            return ValidationResult.Success;
        }
    }
}