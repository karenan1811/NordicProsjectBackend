using System.ComponentModel.DataAnnotations;

namespace SuggestionApp.Models
{
    public class Team:IEntity
    {
        [Key]
        public string TeamName { get; set; }
        public string TeamLeader { get; set; }
    }
}
