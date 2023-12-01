using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Shared
{
    public class UserHabitList
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public HabitRole Role { get; set; }
    }
}
