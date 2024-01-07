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






    }
}
