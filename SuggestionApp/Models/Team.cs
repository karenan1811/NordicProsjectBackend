namespace SuggestionApp.Models
{
    public class Team:IEntity
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamLeader { get; set; }
    }
}
