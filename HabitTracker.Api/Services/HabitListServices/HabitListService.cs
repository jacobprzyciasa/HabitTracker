using AutoMapper;
using HabitTracker.Api.Repositories;

namespace HabitTracker.Api.Services.HabitListServices
{
    public class HabitListService : IHabitListService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public HabitListService(IRepositoryManager repository, IMapper mapper)
        {
            _repositoryManager = repository;
            _mapper = mapper;
        }
    }
}
