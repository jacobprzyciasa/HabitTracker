using HabitTracker.Shared;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Api.Repositories.HabitListRepositories
{
    public class HabitListRepository : RepositoryBase<HabitList>, IHabitListRepository
    {
        private readonly AppDbContext _dbcontext;
        public HabitListRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public override IEnumerable<HabitList> GetAll()
        {
            return _dbcontext.Set<HabitList>()
                .Include(hl => hl.Habits)
                .ThenInclude(h => h.DailyCompleteStatus)
                .ToList();
        }
        public override HabitList GetById(int id)
        {
            return _dbcontext.Set<HabitList>()
                .Include(hl => hl.UserHabitLists)
                .ThenInclude(uhl => uhl.User)
                .Include(hl => hl.Habits)
                .ThenInclude(h => h.DailyCompleteStatus)
                .FirstOrDefault(hl => hl.Id == id);
        }

        public ICollection<HabitList> GetByUserId(int userId)
        {
            return _dbcontext.Set<HabitList>()
                .Include(hl => hl.UserHabitLists)
                .ThenInclude(uhl=>uhl.User)
                .Include(hl => hl.Habits)
                .ThenInclude(h => h.DailyCompleteStatus)
                .Where(hl => hl.UserHabitLists.Any(uhl => uhl.User.Id == userId))
                .ToList();
        }
    }
}
