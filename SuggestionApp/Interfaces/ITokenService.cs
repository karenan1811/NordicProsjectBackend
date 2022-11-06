using SuggestionApp.Models;

namespace SuggestionApp.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);   
    }
}
