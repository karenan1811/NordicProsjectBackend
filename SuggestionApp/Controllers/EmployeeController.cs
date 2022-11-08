using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuggestionApp.DatabaseConnection;
using SuggestionApp.DTOs;

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

        [HttpPost("update")]
        public IActionResult Update(UpdateEmployeeDto employee)
        {
            var user = _employeeDbContext.Employees.FirstOrDefault(x => x.Username == employee.Username);
            if (user != null)
            {
                user.PhoneNumber = employee.PhoneNumber.Length > 0  ? employee.PhoneNumber: user.PhoneNumber;
                user.FirstName = employee.FirstName.Length > 0 ? employee.FirstName : user.FirstName ;
                user.LastName = employee.LastName.Length > 0 ? employee.LastName: user.LastName ;
                user.Email = employee.Email.Length > 0 ? employee.Email: user.Email;
                user.Address = employee.Address.Length > 0 ? employee.Address: user.Address;
                user.JobTitle = employee.JobTitle.Length > 0 ? employee.JobTitle: user.JobTitle;
                user.TeamName = employee.TeamName.Length > 0 ? employee.TeamName: user.TeamName;
                user.Birthday = employee.Birthday != new DateTime(01 / 10 / 1000) ? user.Birthday : employee.Birthday;
                user.EmploymentStartDate = employee.EmploymentStartDate != new DateTime(01 / 10 / 1000) ? user.EmploymentStartDate : employee.EmploymentStartDate;
                _employeeDbContext.Employees.Update(user);
                _employeeDbContext.SaveChanges();
                return Ok(user);
            }
            return BadRequest(user);
        }
    }
}
