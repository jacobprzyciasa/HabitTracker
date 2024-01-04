using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Shared.DataTransferObjects
{
    public record HabitDto(int Id, string Name, string Description, HabitList HabitList, ICollection<HabitCompleteStatus> DailyCompleteStatus);
    public record HabitCompleteStatusDto(int Id, User user, DateOnly Date, bool Complete);
    public record HabitListDto(int Id, string Name, ICollection<Habit> Habits, ICollection<UserHabitList> UserHabitLists);
    public record TokenDto(string AccessToken, string RefreshToken);






}
