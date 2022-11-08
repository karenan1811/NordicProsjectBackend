using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuggestionApp.DatabaseConnection;
using SuggestionApp.DTOs;
using SuggestionApp.Interfaces;
using SuggestionApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace SuggestionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly ITokenService _tokenService;
        public AuthController(EmployeeDbContext employeeDbContext,ITokenService tokenService)
        {
            _employeeDbContext = employeeDbContext;
            _tokenService = tokenService;   
        }

        [HttpPost("register")]
        public IActionResult Register(EmployeeDto employeeDto)
        {
            
            if (employeeDto == null)
            {
                return BadRequest("Employee object is empty") ;
            }
            if(_employeeDbContext.Employees.Any(employee=> employee.Username== employeeDto.Username ||
            employee.Email== employeeDto.Email))
            {
                return BadRequest("Employee allready exists");
            }
            Employee employee = new Employee();
            using var hmac = new HMACSHA512();
            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.Email = employeeDto.Email; 
            employee.Address = employeeDto.Address; 
            employee.PhoneNumber = employeeDto.PhoneNumber; 
            employee.Birthday = employeeDto.Birthday;
            employee.EmployeeId = employeeDto.EmployeeId;   
            employee.EmploymentStartDate = employeeDto.EmploymentStartDate;
            employee.JobTitle = employeeDto.JobTitle;   
            employee.Username = employeeDto.Username;
            employee.TeamName = employeeDto.TeamName;
            employee.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(employeeDto.Password));
            employee.PasswordSalt =hmac.Key;
            _employeeDbContext.Employees.Add(employee);
            _employeeDbContext.SaveChanges();
            var user = new User
            {
                Username = employeeDto.Username,
                PasswordHash = employee.PasswordHash,
                PasswordSalt = employee.PasswordSalt,
            };
            return Ok(user);

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] UserShortDto userLoginDto)

        {
            if (userLoginDto == null)
            {
                return BadRequest("User information can not be empty");
            }
            var employee = await _employeeDbContext.Employees.SingleOrDefaultAsync(u => u.Username == userLoginDto.Username);
            if (employee == null) return Unauthorized("Invalid username!");
            using var hmac = new HMACSHA512(employee.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != employee.PasswordHash[i]) return Unauthorized("Invalid password!");
            }
            var user = new User
            {
                Username = employee.Username,
                PasswordHash = employee.PasswordHash,//This mehtod takes a byte array and returns a byte array
                PasswordSalt = employee.PasswordSalt
            };
            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}
