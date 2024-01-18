using HabitTracker.Api.Entities;
using HabitTracker.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Api
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("habit_tracker");
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<HabitList>().HasMany(hl => hl.UserHabitLists);
            builder.Entity<HabitCompleteStatus>().Property(hcs => hcs.Date).HasConversion<DateOnlyConverter, DateOnlyComparer>();

        }


        public DbSet<User> Users {  get; set; }
        public DbSet<HabitList> HabitLists { get; set; }
        public DbSet<Habit> Habits { get; set; }



    }
}
