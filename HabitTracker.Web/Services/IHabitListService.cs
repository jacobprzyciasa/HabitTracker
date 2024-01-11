using HabitTracker.Shared.DataTransferObjects;
using Refit;

namespace HabitTracker.Web.Services
{
    public interface IHabitListService
    {
        [Post("/habitList")]
        public Task<HabitListDto> AddHabitList(HabitListForCreationDto habitList);
    }
}
