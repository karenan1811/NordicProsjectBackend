using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuggestionApp.DatabaseConnection;
using SuggestionApp.Models;

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
            return BadRequest("No teams found");
        }

        [HttpGet("getteambyname")]
        public IActionResult GetTeamByName(string teamName)
        {
            var team = _employeeDbContext.Teams.FirstOrDefault(x => x.TeamName.ToLower() == teamName.ToLower());
            if (team != null)
            {
                return Ok(team);
            }
            return BadRequest(team);
        }
        [HttpPost("add")]
        public IActionResult Register(Team team)
        {
            if (team == null)
            {
                return BadRequest("Team can not be empty");
            }
            _employeeDbContext.Teams.Add(team);
            _employeeDbContext.SaveChanges();
            return Ok(team);
        }
    }
}
