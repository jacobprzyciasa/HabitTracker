using HabitTracker.Shared;

namespace HabitTracker.Api.Repositories.UserRepositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public User GetByUsername(string username)
        {
            return _dbContext.Users.First(u => u.UserName == username);
        }
    }
}
