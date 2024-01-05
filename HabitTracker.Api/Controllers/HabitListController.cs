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




        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _services.HabitListService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(HabitListDto entity)
        {

            if (entity == null)
                return BadRequest();

            _services.HabitListService.Add(entity);
            

            var result = _services.HabitListService.GetById(entity.Id);

            if (result == null)
                return NotFound();


            return Created(nameof(Get), result);
        }
    }
}
