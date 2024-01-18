using HabitTracker.Api.Repositories.HabitCompleteStatusRepositories;
using HabitTracker.Api.Repositories.HabitListRepositories;
using HabitTracker.Api.Repositories.HabitRepositories;
using HabitTracker.Api.Repositories.HabitRepsitories;
using HabitTracker.Api.Repositories.UserRepositories;

namespace HabitTracker.Api.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _dbContext;
        private readonly Lazy<IHabitCompleteStatusRepository> _habitCompleteStatusRepository;
        private readonly Lazy<IHabitListRepository> _habitListRepository;
        private readonly Lazy<IHabitRepository> _habitRepository;
        private readonly Lazy<IUserRepository> _userRepository;

        public RepositoryManager(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;

            _habitCompleteStatusRepository = new Lazy<IHabitCompleteStatusRepository>(() => new HabitCompleteStatusRepository(_dbContext));
            _habitListRepository = new Lazy<IHabitListRepository>(() => new HabitListRepository(_dbContext));
            _habitRepository = new Lazy<IHabitRepository>(() => new HabitRepository(_dbContext));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_dbContext));
        }


        public IHabitCompleteStatusRepository HabitCompleteStatus => _habitCompleteStatusRepository.Value;
        public IHabitListRepository HabitList => _habitListRepository.Value;
        public IHabitRepository Habit => _habitRepository.Value;
        public IUserRepository User => _userRepository.Value;

        public void ClearTracks() => _dbContext.ChangeTracker.Clear();
        public void Save() => _dbContext.SaveChanges();
    }
}
