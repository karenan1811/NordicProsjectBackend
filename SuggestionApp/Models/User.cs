namespace SuggestionApp.Models
{
    public class User:IEntity
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }


    }
}
