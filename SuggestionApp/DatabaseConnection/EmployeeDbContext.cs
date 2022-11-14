using Microsoft.EntityFrameworkCore;
using SuggestionApp.Models;

namespace SuggestionApp.DatabaseConnection
{
    public class EmployeeDbContext:DbContext
    {
      public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options)
        {
           
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }

    }

}
