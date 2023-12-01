using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Shared
{
    public class HabitList
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Habit> Habits {  get; set; }
        public ICollection<UserHabitList> UserHabitLists { get; set; }
    }
}
