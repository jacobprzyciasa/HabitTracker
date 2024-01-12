using HabitTracker.Shared.DataTransferObjects;

namespace HabitTracker.Api.Services.HabitListServices
{
    public interface IHabitListService : IDbEntityServiceBase<HabitListDto, HabitListForCreationDto>
    {
        public ICollection<HabitListDto> GetByUserId(int id);
    }
}
