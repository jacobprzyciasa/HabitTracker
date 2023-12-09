using HabitTracker.Shared;

namespace HabitTracker.Api.Repositories.HabitListRepositories
{
    public interface IHabitListRepository : IRepository<HabitList>
    {
        public ICollection<HabitList> GetByUserId(int userId);
    }
}
