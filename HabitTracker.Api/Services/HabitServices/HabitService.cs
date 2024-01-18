using AutoMapper;
using HabitTracker.Api.Repositories;
using HabitTracker.Api.Services.HabitListServices;
using HabitTracker.Api.Services.Logger;
using HabitTracker.Shared.DataTransferObjects;
using HabitTracker.Shared;
using Microsoft.EntityFrameworkCore;

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

                habit.HabitList = _repositoryManager.HabitList.GetById(habit.HabitList.Id);

                List<HabitCompleteStatus> habitCompleteStatus = new List<HabitCompleteStatus>();
                foreach (var i in habit.DailyCompleteStatus)
                {
                    var user = _repositoryManager.User.GetById(i.User.Id);
                    habitCompleteStatus.Add(new() { User = user, Date = i.Date, Complete=i.Complete });
                }
                habit.DailyCompleteStatus = habitCompleteStatus;

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

        public ICollection<HabitDto> GetByListId(int listId)
        {
            try
            {
                var entity = _repositoryManager.Habit.GetByListId(listId);
                var habits = _mapper.Map<ICollection<HabitDto>>(entity);
                return habits;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(GetByListId)} service:{nameof(HabitService)} exeption: {ex}");
                throw;
            }
        }

        public ICollection<HabitDto> GetByUserId(int userId)
        {
            try
            {
                var entity = _repositoryManager.Habit.GetByUserId(userId);
                var habits = _mapper.Map<ICollection<HabitDto>>(entity);
                return habits;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(GetByUserId)} service:{nameof(HabitService)} exeption: {ex}");
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
                _repositoryManager.ClearTracks();

                var oldHabit = _repositoryManager.Habit.GetById(entity.Id);
                
                foreach (var dcs in entity.DailyCompleteStatus) 
                {
                    var i = oldHabit.DailyCompleteStatus.Where(i => i.Id == dcs.Id).FirstOrDefault();
                    if (i is not null)
                    {
                        i.Complete = dcs.Complete;
                    }
                    else
                    {
                        var idCopy = oldHabit.DailyCompleteStatus.Where(i => i.User.Id == dcs.User.Id).FirstOrDefault();
                        if (idCopy is not null)
                            dcs.User = idCopy.User;
                        oldHabit.DailyCompleteStatus.Add(dcs);
                    }
                }

                _repositoryManager.Habit.Update(oldHabit);
                _repositoryManager.Save();

                var habitToReturn = _mapper.Map<HabitDto>(oldHabit);
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
