using HabitTracker.Shared;
using HabitTracker.Shared.DataTransferObjects;

namespace HabitTracker.Api.Services.HabitCompleteStatusServices
{
    public interface IHabitCompleteStatusService
    {
        IEnumerable<HabitCompleteStatusDto> GetAll();
        HabitCompleteStatusDto GetById(int id);
        void Add(HabitCompleteStatusDto entity);
        void Delete(HabitCompleteStatusDto entity);
        void Update(HabitCompleteStatusDto entity);
    }
}
