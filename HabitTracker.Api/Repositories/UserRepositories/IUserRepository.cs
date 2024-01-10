using HabitTracker.Shared;

namespace HabitTracker.Api.Repositories.UserRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetByUsername(string username);
    }
}
