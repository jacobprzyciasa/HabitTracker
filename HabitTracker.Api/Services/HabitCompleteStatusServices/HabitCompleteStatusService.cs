using AutoMapper;
using HabitTracker.Api.Repositories;
using HabitTracker.Api.Services.HabitCompleteStatusServices;

namespace HabitTracker.Api.Services.sHabitCompleteStatusServices
{
    public sealed class HabitCompleteStatusService : IHabitCompleteStatusService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public HabitCompleteStatusService(IRepositoryManager repository, IMapper mapper) 
        { 
            _repositoryManager = repository;
            _mapper = mapper;
        }
    }
}
