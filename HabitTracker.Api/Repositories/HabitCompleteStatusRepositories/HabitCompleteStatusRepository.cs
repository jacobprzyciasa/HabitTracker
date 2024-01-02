using HabitTracker.Shared;

namespace HabitTracker.Api.Repositories.HabitCompleteStatusRepositories
{
    public class HabitCompleteStatusRepository : RepositoryBase<HabitCompleteStatus>, IHabitCompleteStatusRepository
    {
        public HabitCompleteStatusRepository(AppDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
