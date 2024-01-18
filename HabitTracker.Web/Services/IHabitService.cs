using HabitTracker.Shared;
using HabitTracker.Shared.DataTransferObjects;
using Refit;

namespace HabitTracker.Web.Services
{
    public interface IHabitService
    {
        [Post("/habit")]
        public Task<HabitDto> AddHabit(HabitForCreationDto habit);

        [Delete("/habit")]
        public Task DeleteHabit([Body] HabitDto habit);

        [Put("/habit")]
        public Task<HabitDto> UpdateHabit(HabitDto habit);
    }
}
