
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,POC")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Pavithra", Role = "Admin" },
            new Employee { Id = 2, Name = "John", Role = "User" }
        };
        return Ok(employees);
    }
}
