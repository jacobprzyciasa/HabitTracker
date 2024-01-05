using HabitTracker.Api.Repositories;
using HabitTracker.Api.Services.HabitCompleteStatusServices;
using HabitTracker.Api.Services.HabitListServices;
using HabitTracker.Api.Services.HabitServices;
using HabitTracker.Api.Services.UserServices;
using HabitTracker.Api.Services.AuthenticationServices;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using HabitTracker.Shared;
using HabitTracker.Api.Services.Logger;
using HabitTracker.Api.Services.sHabitCompleteStatusServices;

namespace HabitTracker.Api.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHabitCompleteStatusService> _habitCompleteStatusService;
        private readonly Lazy<IHabitListService> _habitListService;
        private readonly Lazy<IHabitService> _habitService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IAuthenticationService> _authService;

        public ServiceManager(IRepositoryManager repositoryManager,
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration, 
            ILoggerManager logger)
        {
            _habitCompleteStatusService = new Lazy<IHabitCompleteStatusService>(() => new HabitCompleteStatusService(repositoryManager, mapper, logger));
            _habitListService = new Lazy<IHabitListService>(() => new HabitListService(repositoryManager, mapper, logger));
            _habitService = new Lazy<IHabitService>(() => new HabitService(repositoryManager, mapper, logger));
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper, logger));
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper, logger));
            _authService = new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, userManager, configuration));
        }

        public IHabitCompleteStatusService HabitCompleteStatusService => _habitCompleteStatusService.Value;
        public IHabitListService HabitListService => _habitListService.Value;
        public IHabitService HabitService => _habitService.Value;
        public IUserService UserService => _userService.Value;
        public IAuthenticationService AuthenticationService => _authService.Value;
    }
}
