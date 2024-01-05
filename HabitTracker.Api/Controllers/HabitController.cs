using HabitTracker.Api.Services;
using HabitTracker.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Api.Controllers
{

    [Route("habit")]
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IServiceManager _services;
        public HabitController(IServiceManager service) => _services = service;

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _services.HabitService.GetById(id);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(HabitDto entity)
        {

            if (entity == null)
                return BadRequest();
            
            _services.HabitService.Add(entity);

            var result = _services.HabitService.GetById(entity.Id);

            if(result == null)
                return NotFound();


            return Created(nameof(Get),result);
        }




    }
}
