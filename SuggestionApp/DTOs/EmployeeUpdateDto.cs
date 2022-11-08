namespace SuggestionApp.DTOs
{
    public class UpdateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public string JobTitle { get; set; }
        public string TeamName { get; set; }
    }
}
