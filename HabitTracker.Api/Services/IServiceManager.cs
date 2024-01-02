using HabitTracker.Api.Services.Authentication;
using HabitTracker.Api.Services.HabitCompleteStatus;
using HabitTracker.Api.Services.HabitList;
using HabitTracker.Api.Services.Habit;
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
