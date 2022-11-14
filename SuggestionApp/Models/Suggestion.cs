namespace SuggestionApp.Models
{
    public class Suggestion:IEntity

    {
        public int SuggestionId { get; set; }
        public string PriorityLevel { get; set; }
        public DateTime SuggestionDate { get; set; }
        public string SuggestionResult { get; set; }
        public string SuggestionDescription { get; set; }
        public string SuggestionStatus { get; set; }
        public string SuggestionGiver { get; set; }
        public string SuggestionTitle { get; set; }
        public string TeamName { get; set; }
        public DateTime SuggestionDeadline { get; set; }

    }
}
