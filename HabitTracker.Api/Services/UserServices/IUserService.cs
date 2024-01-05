using HabitTracker.Shared.DataTransferObjects;

namespace HabitTracker.Api.Services.UserServices
{
    public interface IUserService
    {
        public UserDto GetById(int id);
        public UserDto GetByUserName(string username);


    }
}
