using HabitTracker.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Api
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("habit_tracker");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HabitList>().HasMany(hl => hl.UserHabitLists);
            builder.Entity<Habit>().HasMany(h => h.DailyCompleteStatus);
        }


        DbSet<User> Users {  get; set; }
        DbSet<HabitList> HabitLists { get; set; }
        DbSet<Habit> Habits { get; set; }



    }
}
