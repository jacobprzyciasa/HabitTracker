using AutoMapper;
using HabitTracker.Api.Repositories;
using HabitTracker.Api.Services.Logger;
using HabitTracker.Api.Services.sHabitCompleteStatusServices;
using HabitTracker.Shared.DataTransferObjects;
using HabitTracker.Shared;

namespace HabitTracker.Api.Services.HabitListServices
{
    public class HabitListService : IHabitListService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public HabitListService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repositoryManager = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public HabitListDto Add(HabitListForCreationDto entity)
        {
            try
            {
                HabitList habitList = _mapper.Map<HabitList>(entity);

                //inject entites of userhabitList from db
                List<UserHabitList> userHabitLists = new List<UserHabitList>();
                foreach (var i in habitList.UserHabitLists)
                {
                    var user = _repositoryManager.User.GetById(i.User.Id);
                    userHabitLists.Add(new() { User=user, Role=i.Role });
                }
                habitList.UserHabitLists = userHabitLists;

                _repositoryManager.HabitList.Add(habitList);
                _repositoryManager.Save();

                var habitListToReturn = _mapper.Map<HabitListDto>(habitList);
                return habitListToReturn;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(Add)} service:{nameof(HabitListService)} exeption: {ex}");
                throw;
            }
        }

        public void Delete(HabitListDto entity)
        {
            try
            {
                HabitList habitList = _mapper.Map<HabitList>(entity);
                _repositoryManager.HabitList.Delete(habitList);
                _repositoryManager.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(Delete)} service:{nameof(HabitListService)} exeption: {ex}");
            }
        }

        public IEnumerable<HabitListDto> GetAll()
        {
            try
            {
                var entities = _repositoryManager.HabitList.GetAll();
                var habitList = _mapper.Map<IEnumerable<HabitListDto>>(entities);
                return habitList;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(GetAll)} service:{nameof(HabitListService)} exeption: {ex}");
                throw;
            }
        }

        public HabitListDto GetById(int id)
        {
            try
            {
                var entity = _repositoryManager.HabitList.GetById(id);
                var habitList = _mapper.Map<HabitListDto>(entity);
                return habitList;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(GetById)} service:{nameof(HabitListService)} exeption: {ex}");
                throw;
            }
        }

        public HabitListDto Update(HabitListDto entity)
        {
            try
            {
                

                var habitList = _repositoryManager.HabitList.GetById(entity.Id);

                habitList.Name = entity.Name;
                habitList.Habits = entity.Habits;


                List<UserHabitList> userHabitLists = new List<UserHabitList>();
                foreach (var i in entity.UserHabitLists)
                {
                    var user = _repositoryManager.User.GetById(i.User.Id);
                    userHabitLists.Add(new() { User = user, Role = i.Role });
                }
                habitList.UserHabitLists = userHabitLists;

                _repositoryManager.HabitList.Update(habitList);
                _repositoryManager.Save();

                var habitListToReturn = _mapper.Map<HabitListDto>(habitList);
                return habitListToReturn;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(Update)} service:{nameof(HabitListService)} exeption: {ex}");
                throw;
            }
        }
    }
}
