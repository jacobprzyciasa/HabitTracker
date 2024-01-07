using AutoMapper;
using HabitTracker.Api.Repositories;
using HabitTracker.Api.Services.HabitListServices;
using HabitTracker.Api.Services.Logger;
using HabitTracker.Shared.DataTransferObjects;
using HabitTracker.Shared;

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

        public HabitDto Add(HabitForCreationDto entity)
        {
            try
            {
                Habit habit = _mapper.Map<Habit>(entity);
                _repositoryManager.Habit.Add(habit);
                _repositoryManager.Save();

                var habitToReturn = _mapper.Map<HabitDto>(habit);
                return habitToReturn;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(Add)} service:{nameof(HabitService)} exeption: {ex}");
                throw;
            }
        }


        public void Delete(HabitDto entity)
        {
            try
            {
                Habit habit = _mapper.Map<Habit>(entity);
                _repositoryManager.Habit.Delete(habit);
                _repositoryManager.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(Delete)} service:{nameof(HabitService)} exeption: {ex}");
            }
        }

        public IEnumerable<HabitDto> GetAll()
        {
            try
            {
                var entities = _repositoryManager.Habit.GetAll();
                var habit = _mapper.Map<IEnumerable<HabitDto>>(entities);
                return habit;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(GetAll)} service:{nameof(HabitService)} exeption: {ex}");
                throw;
            }
        }

        public HabitDto GetById(int id)
        {
            try
            {
                var entity = _repositoryManager.Habit.GetById(id);
                var habit = _mapper.Map<HabitDto>(entity);
                return habit;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(GetById)} service:{nameof(HabitService)} exeption: {ex}");
                throw;
            }
        }

        public HabitDto Update(HabitDto entity)
        {
            try
            {
                var habit = _mapper.Map<Habit>(entity);
                _repositoryManager.Habit.Update(habit);
                _repositoryManager.Save();

                var habitToReturn = _mapper.Map<HabitDto>(habit);
                return habitToReturn;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(Update)} service:{nameof(HabitService)} exeption: {ex}");
                throw;
            }
        }

    }
}
