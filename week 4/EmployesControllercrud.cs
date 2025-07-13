using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        // Hardcoded in-memory list of employees
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 },
            new Employee { Id = 3, Name = "Charlie", Department = "Finance", Salary = 55000 }
        };

        // PUT: api/employees/2
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Update hardcoded data
            existingEmployee.Name = updatedEmp.Name;
            existingEmployee.Department = updatedEmp.Department;
            existingEmployee.Salary = updatedEmp.Salary;

            return Ok(existingEmployee);
        }
    }
}