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
            CreateMap<HabitList, HabitListDto>();
            CreateMap<HabitCompleteStatus, HabitCompleteStatusDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserForRegistrationDto, User>();
            
        }
    }
}
