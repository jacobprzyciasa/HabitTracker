using AutoMapper;
using HabitTracker.Api.Repositories;
using HabitTracker.Api.Services.HabitCompleteStatusServices;
using HabitTracker.Api.Services.Logger;
using HabitTracker.Shared;
using HabitTracker.Shared.DataTransferObjects;
using Microsoft.IdentityModel.Protocols.WSFederation.Metadata;

namespace HabitTracker.Api.Services.sHabitCompleteStatusServices
{
    public sealed class HabitCompleteStatusService : IHabitCompleteStatusService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public HabitCompleteStatusService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger) 
        { 
            _repositoryManager = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public HabitCompleteStatusDto Add(HabitCompleteStatusForCreationDto entity)
        {
            try
            {
                HabitCompleteStatus habitCompleteStatus = _mapper.Map<HabitCompleteStatus>(entity);
                _repositoryManager.HabitCompleteStatus.Add(habitCompleteStatus);
                _repositoryManager.Save();


                var habitCompleteStatusToReturn = _mapper.Map<HabitCompleteStatusDto>(habitCompleteStatus);
                return habitCompleteStatusToReturn;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(Add)} service:{nameof(HabitCompleteStatusService)} exeption: {ex}");
                throw;
            }
        }

        public void Delete(HabitCompleteStatusDto entity)
        {
            try
            {
                HabitCompleteStatus habitCompleteStatus = _mapper.Map<HabitCompleteStatus>(entity);
                _repositoryManager.HabitCompleteStatus.Delete(habitCompleteStatus);
                _repositoryManager.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(Delete)} service:{nameof(HabitCompleteStatusService)} exeption: {ex}");
            }
        }

        public IEnumerable<HabitCompleteStatusDto> GetAll()
        {
            try
            {
                var entities = _repositoryManager.HabitCompleteStatus.GetAll();
                var habitCompleteStatus = _mapper.Map<IEnumerable<HabitCompleteStatusDto>>(entities);
                return habitCompleteStatus;
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(GetAll)} service:{nameof(HabitCompleteStatusService)} exeption: {ex}");
                throw;
            }
        }

        public HabitCompleteStatusDto GetById(int id)
        {
            try
            {
                var entity = _repositoryManager.HabitCompleteStatus.GetById(id);
                var habitCompleteStatus = _mapper.Map<HabitCompleteStatusDto>(entity);
                return habitCompleteStatus;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(GetById)} service:{nameof(HabitCompleteStatusService)} exeption: {ex}");
                throw;
            }
        }

        public HabitCompleteStatusDto Update(HabitCompleteStatusDto entity)
        {
            try
            {
                var habitCompleteStatus = _mapper.Map<HabitCompleteStatus>(entity);
                _repositoryManager.HabitCompleteStatus.Update(habitCompleteStatus);
                _repositoryManager.Save();

                var habitCompleteStatusToReturn = _mapper.Map<HabitCompleteStatusDto>(habitCompleteStatus);
                return habitCompleteStatusToReturn;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the method:{nameof(Update)} service:{nameof(HabitCompleteStatusService)} exeption: {ex}");
                throw;
            }
        }
    }
}
