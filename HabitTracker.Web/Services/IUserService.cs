using HabitTracker.Shared.DataTransferObjects;
using Refit;

namespace HabitTracker.Web.Services
{
    public interface IUserService
    {
        [Post("/autentication")]
        Task UserRegister(UserForRegistrationDto user);
        [Post("/autentication/login")]
        Task LoginUser(UserForAuthenticationDto user);
    }
}
