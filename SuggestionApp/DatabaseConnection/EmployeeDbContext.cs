using Microsoft.EntityFrameworkCore;
using SuggestionApp.Models;

namespace SuggestionApp.DatabaseConnection
{
    public class EmployeeDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EmployeesDatabase; Trusted_Connection=true");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }

    }

}
