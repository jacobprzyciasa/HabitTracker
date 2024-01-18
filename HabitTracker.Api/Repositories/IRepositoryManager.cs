using HabitTracker.Api.Repositories.HabitCompleteStatusRepositories;
using HabitTracker.Api.Repositories.HabitListRepositories;
using HabitTracker.Api.Repositories.HabitRepositories;
using HabitTracker.Api.Repositories.UserRepositories;

namespace HabitTracker.Api.Repositories
{
    public interface IRepositoryManager
    {
        IHabitCompleteStatusRepository HabitCompleteStatus { get; }
        IHabitListRepository HabitList { get; }
        IHabitRepository Habit { get; }
        IUserRepository User { get; }

        void ClearTracks();

        void Save();
    }
}
