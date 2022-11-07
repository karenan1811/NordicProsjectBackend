using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet("getsingleemployee")]
        public IActionResult GetEmployeeByUsername(string username)
        {
            var user = _employeeDbContext.Employees.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest("This user can not be found");
        }
    }
}
