using AutoMapper;
using HabitTracker.Api.Repositories;
using HabitTracker.Api.Services.HabitServices;
using HabitTracker.Api.Services.Logger;
using HabitTracker.Shared.DataTransferObjects;
using HabitTracker.Shared;

namespace HabitTracker.Api.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public UserService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repositoryManager = repository;
            _mapper = mapper;
            _logger = logger;
        }

    }
}
