using Microsoft.AspNetCore.Mvc;
using EmployeePortal.Models.DTO;
using EmployeePortal.Models.Entities;

namespace EmployeePortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();
        private static int idCounter = 1;

        [HttpPost]
        public IActionResult CreateEmployee(CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = createStudentDto.Name,
                Email = createStudentDto.Email,
                Salary = dto.Salary
            };

            employees.Add(employee);

            var response = new EmployeeResponseDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email
            };

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }
    }
}