using AutoMapper;
using HabitTracker.Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HabitTracker.Shared
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

            CreateMap<HabitCompleteStatus, HabitCompleteStatusDto>();
            CreateMap<HabitCompleteStatusDto, HabitCompleteStatus>();
            CreateMap<HabitCompleteStatusForCreationDto, HabitCompleteStatus>();

            CreateMap<User, UserDto>();

            CreateMap<UserForRegistrationDto, User>();
            
        }
    }
}
