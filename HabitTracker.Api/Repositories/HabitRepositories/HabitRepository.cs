using HabitTracker.Api.Repositories.HabitRepositories;
using HabitTracker.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HabitTracker.Api.Repositories.HabitRepsitories
{
    public class HabitRepository : RepositoryBase<Habit>, IHabitRepository
    {
        private readonly AppDbContext _dbcontext;
        public HabitRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public override IEnumerable<Habit> GetAll()
        {
            return _dbcontext.Set<Habit>()
                .Include(h => h.HabitList)
                .ThenInclude(hl => hl.UserHabitLists)
                .Include(h => h.DailyCompleteStatus)
                .ThenInclude(hcs => hcs.User);
        }
        public override Habit GetById(int id)
        {
            return _dbcontext.Set<Habit>()
                .Include(h => h.HabitList)
                .ThenInclude(hl => hl.UserHabitLists)
                .Include(h => h.DailyCompleteStatus)
                .ThenInclude(hcs => hcs.User)
                .FirstOrDefault(h => h.Id == id)!;
        }

        public ICollection<Habit> GetByUserId(int userId)
        {
            return _dbcontext.Set<Habit>()
                .Where(h => h.HabitList.UserHabitLists
                .Any(uhl => uhl.User.Id == userId))
                .Include(h => h.HabitList)
                .ThenInclude(hl => hl.UserHabitLists)
                .Include(h => h.DailyCompleteStatus)
                .ThenInclude(hcs => hcs.User)
                .ToList();
        }

        public ICollection<Habit> GetByListId(int listId)
        {
            return _dbcontext.Set<Habit>()
                .Where(h => h.HabitList.Id == listId)
                .Include(h => h.HabitList)
                .ThenInclude(hl => hl.UserHabitLists)
                .Include(h => h.DailyCompleteStatus)
                .ThenInclude(hcs => hcs.User)
                .ToList();
        }


    }
}
