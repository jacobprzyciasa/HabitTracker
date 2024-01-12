using HabitTracker.Shared.DataTransferObjects;

namespace HabitTracker.Web.Services
{
    public interface ITokenService
    {
        Task<TokenDto> GetToken();
        Task RemoveToken();
        Task SetToken(TokenDto tokenDto);
    }
}
