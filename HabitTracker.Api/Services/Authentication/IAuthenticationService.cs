using HabitTracker.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace HabitTracker.Api.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);


    }
}
