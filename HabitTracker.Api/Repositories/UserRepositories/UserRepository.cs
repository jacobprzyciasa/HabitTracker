using HabitTracker.Shared;

namespace HabitTracker.Api.Repositories.UserRepositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
