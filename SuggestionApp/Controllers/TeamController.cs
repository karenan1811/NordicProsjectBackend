using Microsoft.AspNetCore.Mvc;
using SuggestionApp.DatabaseConnection;

namespace SuggestionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public TeamController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teams = _employeeDbContext.Teams.ToList();
            if (teams != null)
            {
                return Ok(teams);
            }
            return BadRequest("No employees found");
        }
    }
}
