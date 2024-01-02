using AutoMapper;
using HabitTracker.Api.Repositories;
using HabitTracker.Api.Services.Logger;

namespace HabitTracker.Api.Services.HabitServices
{
    public class HabitService : IHabitService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public HabitService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repositoryManager = repository;
            _mapper = mapper;
            _logger = logger;
        }

        

    }
}
