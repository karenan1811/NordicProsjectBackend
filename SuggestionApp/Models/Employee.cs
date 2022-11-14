namespace SuggestionApp.Models
{
    public class Employee:IEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public string JobTitle { get; set; }
        public string TeamName { get; set; }
    }
}
