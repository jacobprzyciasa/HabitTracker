using HabitTracker.Shared.DataTransferObjects;

namespace HabitTracker.Api.Services.HabitServices
{
    public interface IHabitService : IDbEntityServiceBase<HabitDto, HabitForCreationDto>
    {
        public ICollection<HabitDto> GetByListId(int listId);
    }
}
