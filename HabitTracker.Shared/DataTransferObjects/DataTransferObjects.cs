using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Shared.DataTransferObjects
{
    public record HabitDto(int Id, string Name, string Description, HabitList HabitList,[AllowNull] ICollection<HabitCompleteStatus> DailyCompleteStatus);
    public record HabitForCreationDto(string Name, string Description, HabitList HabitList, [AllowNull] ICollection<HabitCompleteStatus> DailyCompleteStatus);
    
    public record HabitCompleteStatusDto(int Id, User user, DateOnly Date, bool Complete);
    public record HabitCompleteStatusForCreationDto( User user, DateOnly Date, bool Complete);

    public record HabitListDto(int Id, string Name, [AllowNull] ICollection<Habit> Habits, [AllowNull] ICollection<UserHabitList> UserHabitLists);
    public record HabitListForCreationDto(string Name, [AllowNull] ICollection<Habit> Habits, [AllowNull] ICollection<UserHabitList> UserHabitLists);
    
    public record TokenDto(string AccessToken, string RefreshToken);
    public record UserDto(int Id, string UserName, string Email, bool EmailConfirmed);


}
