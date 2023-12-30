using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Shared
{
    public class Habit
    {
        [Key]
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HabitList HabitList { get; set; }
        public ICollection<HabitCompleteStatus> DailyCompleteStatus { get; set; }
    }
}
