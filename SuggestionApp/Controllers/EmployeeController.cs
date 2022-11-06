using Microsoft.AspNetCore.Mvc;
using SuggestionApp.DatabaseConnection;

namespace SuggestionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
    
        [HttpGet]
        public IActionResult GetAll()
        {
         var employees = _employeeDbContext.Employees.ToList();
            if (employees != null)
            {
                return Ok(employees);
            }
            return BadRequest("No employees found");    
        }
    }
}
