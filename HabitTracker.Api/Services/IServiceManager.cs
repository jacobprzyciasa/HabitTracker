using HabitTracker.Api.Services.AuthenticationServices;
using HabitTracker.Api.Services.HabitCompleteStatusServices;
using HabitTracker.Api.Services.HabitListServices;
using HabitTracker.Api.Services.HabitServices;
using HabitTracker.Api.Services.UserServices;

namespace HabitTracker.Api.Services
{
    public interface IServiceManager
    {
        IHabitCompleteStatusService HabitCompleteStatusService { get; }
        IHabitListService HabitListService { get; }
        IHabitService HabitService { get; }
        IUserService UserService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
