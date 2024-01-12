using HabitTracker.Shared.DataTransferObjects;
using Refit;

namespace HabitTracker.Web.Services
{
    public interface IHabitListService
    {
        [Post("/habitList")]
        public Task<HabitListDto> AddHabitList(HabitListForCreationDto habitList);
        [Get("/habitList/{id}")]
        public Task<HabitDto> GetHabitListById(int id);
        [Get("/habitList/userId/{userId}")]
        public Task<ICollection<UserDto>> GetHabitByUserId(int userId);
        [Delete("/habitList")]
        public Task DeleteHabitlist(HabitListDto habitListToDelete);
    }
}
