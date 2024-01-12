using HabitTracker.Shared.DataTransferObjects;
using HabitTracker.Shared;
using AutoMapper;

namespace HabitTracker.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Habit, HabitDto>();
            CreateMap<HabitDto, Habit>();
            CreateMap<HabitForCreationDto, Habit>();

            CreateMap<HabitList, HabitListDto>();
            CreateMap<HabitListDto, HabitList>();
            CreateMap<HabitListForCreationDto, HabitList>();
            CreateMap<HabitList, HabitListForCreationDto>();

            CreateMap<HabitCompleteStatus, HabitCompleteStatusDto>();
            CreateMap<HabitCompleteStatusDto, HabitCompleteStatus>();
            CreateMap<HabitCompleteStatusForCreationDto, HabitCompleteStatus>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<UserForRegistrationDto, User>();

        }
    }
}
