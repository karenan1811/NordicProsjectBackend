﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuggestionApp.DatabaseConnection;

namespace SuggestionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        EmployeeDbContext _employeeDbContext = new EmployeeDbContext();

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
    }
}