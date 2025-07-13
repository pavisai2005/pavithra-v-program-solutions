
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[ServiceFilter(typeof(CustomAuthFilter))]
[ServiceFilter(typeof(CustomExceptionFilter))]
public class EmployeeController : ControllerBase
{
    private List<Employee> _employees;

    public EmployeeController()
    {
        _employees = GetStandardEmployeeList();
    }

    private List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Pavithra",
                Salary = 40000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "HR" },
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = "SQL" }
                },
                DateOfBirth = new DateTime(2000, 1, 1)
            }
        };
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<Employee>), 200)]
    [ProducesResponseType(500)]
    public ActionResult<List<Employee>> GetStandard()
    {
        throw new Exception("Simulated exception"); // For testing
        return _employees;
    }

    [HttpPost]
    public ActionResult<Employee> AddEmployee([FromBody] Employee employee)
    {
        _employees.Add(employee);
        return Ok(employee);
    }

    [HttpPut("{id}")]
    public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updated)
    {
        if (id <= 0)
            return BadRequest("Invalid employee id");

        var emp = _employees.FirstOrDefault(e => e.Id == id);
        if (emp == null)
            return BadRequest("Invalid employee id");

        emp.Name = updated.Name;
        emp.Salary = updated.Salary;
        emp.Permanent = updated.Permanent;
        emp.Department = updated.Department;
        emp.Skills = updated.Skills;
        emp.DateOfBirth = updated.DateOfBirth;

        return Ok(emp);
    }
}
