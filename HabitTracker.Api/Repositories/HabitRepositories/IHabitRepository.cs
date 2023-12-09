using HabitTracker.Shared;

namespace HabitTracker.Api.Repositories.HabitRepositories
{
    public interface IHabitRepository : IRepository<Habit>
    {
        public ICollection<Habit> GetByUserId(int userId);
        public ICollection<Habit> GetByListId(int listId);
    }
}
