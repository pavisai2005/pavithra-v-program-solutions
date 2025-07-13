using Microsoft.AspNetCore.Mvc;

namespace SwaggerDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var employees = new[] { "Alice", "Bob", "Charlie" };
            return Ok(employees);
        }
    }
}