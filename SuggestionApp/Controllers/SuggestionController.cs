using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuggestionApp.DatabaseConnection;
using SuggestionApp.Models;

namespace SuggestionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
      private readonly  EmployeeDbContext _employeeDbContext;
        public SuggestionController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext; 
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var suggestions = _employeeDbContext.Suggestions.ToList();
            if (suggestions != null)
            {
                return Ok(suggestions);
            }
            return BadRequest("No suggestions found");
        }

        [HttpGet("getsuggestionbyteamname")]
        public IActionResult GetSuggestionByTeamName(string teamName)
        {
            var suggestions = _employeeDbContext.Suggestions.Where(p => p.TeamName.ToLower() == teamName.ToLower()).ToList();
            if (suggestions != null)
            {
                return Ok(suggestions);
            }
            return BadRequest("No suggestion found for this team");
        }


        [HttpGet("getsuggestionbyusername")]
        public IActionResult GetEmployeeByUsername(string userName)
        {
            var suggestions = _employeeDbContext.Suggestions.Where(s => s.SuggestionGiver == userName).ToList();
            if (suggestions != null)
            {
                return Ok(suggestions);
            }
            return BadRequest(suggestions);
        }

        [HttpPost("add")]
        public IActionResult AddSuggestion(Suggestion suggestion)
        {
            if (suggestion == null)
            {
                return BadRequest("Suggestion can not be empty");
            }
            _employeeDbContext.Suggestions.Add(suggestion);
            _employeeDbContext.SaveChanges();
            return Ok(suggestion);
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("update")]
        public IActionResult Update(Suggestion updatedSuggestion)
        {
            var suggestion = _employeeDbContext.Suggestions.FirstOrDefault(x => x.SuggestionId == updatedSuggestion.SuggestionId);
            if (suggestion != null)
            {
                suggestion.SuggestionResult = updatedSuggestion.SuggestionResult.Length > 0 ? updatedSuggestion.SuggestionResult : suggestion.SuggestionResult;
                suggestion.SuggestionDescription = updatedSuggestion.SuggestionDescription.Length > 0 ? updatedSuggestion.SuggestionDescription : suggestion.SuggestionDescription;
                suggestion.SuggestionStatus = updatedSuggestion.SuggestionStatus.Length > 0 ? updatedSuggestion.SuggestionStatus : suggestion.SuggestionStatus;
                suggestion.SuggestionTitle = updatedSuggestion.SuggestionTitle.Length > 0 ? updatedSuggestion.SuggestionTitle : suggestion.SuggestionTitle;
                suggestion.PriorityLevel = updatedSuggestion.PriorityLevel.Length > 0 ? updatedSuggestion.PriorityLevel : suggestion.PriorityLevel;
                suggestion.TeamName = updatedSuggestion.TeamName.Length > 0 ? updatedSuggestion.TeamName : suggestion.TeamName;
                suggestion.SuggestionDeadline = updatedSuggestion.SuggestionDeadline != new DateTime(10 / 10 / 2000) ? updatedSuggestion.SuggestionDeadline : suggestion.SuggestionDeadline;
                _employeeDbContext.Suggestions.Update(suggestion);
                _employeeDbContext.SaveChanges();
                return Ok(suggestion);
            }
            return BadRequest("No suggestion found");
        }

    }
}
