using HabitTracker.Api.Services;
using HabitTracker.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Api.Controllers
{

    [Route("habitList")]
    [ApiController]
    public class HabitListController : ControllerBase
    {
        private readonly IServiceManager _services;
        public HabitListController(IServiceManager service) => _services = service;




        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = _services.HabitListService.GetById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(HabitListForCreationDto entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest();

                var result = _services.HabitListService.Add(entity);

                if (result == null)
                    return NotFound();


                return Created(nameof(Get), result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(HabitListDto entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest();

                var result = _services.HabitListService.Update(entity);

                if (result == null)
                    return NotFound();


                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(HabitListDto entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest();

                _services.HabitListService.Delete(entity);

                var result = _services.HabitListService.GetById(entity.Id);

                if (result != null)
                    return NotFound();


                return Ok();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
