using AutoMapper;
using HabitTracker.Api.Repositories;

namespace HabitTracker.Api.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager repository, IMapper mapper)
        {
            _repositoryManager = repository;
            _mapper = mapper;
        }
    }
}
