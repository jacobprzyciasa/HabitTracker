using HabitTracker.Shared.DataTransferObjects;
using Refit;

namespace HabitTracker.Web.Services
{
    public interface IUserService
    {
        [Post("/authentication")]
        public Task RegisterUser(UserForRegistrationDto user);
        [Post("/authentication/login")]
        public Task<TokenDto> LoginUser(UserForAuthenticationDto user);
        [Get("/users/{username}")]
        public Task<UserDto> GetUserFromUsername(string username);
        [Get("/users/id/{id}")]
        public Task<UserDto> GetUserById(int id);
    }
}
