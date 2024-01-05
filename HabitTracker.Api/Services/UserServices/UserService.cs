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


        public UserDto GetByUserName(string username)
        {
            try
            {
                var entity = _repositoryManager.User.GetByUsername(username);
                var user = _mapper.Map<UserDto>(entity);
                return user;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(GetByUserName)} service:{nameof(UserService)} exeption: {ex}");
                throw;
            }
        }

        public UserDto GetById(int id)
        {
            try
            {
                var entity = _repositoryManager.User.GetById(id);
                var user = _mapper.Map<UserDto>(entity);
                return user;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(GetById)} service:{nameof(UserService)} exeption: {ex}");
                throw;
            }
        }
    }
}
