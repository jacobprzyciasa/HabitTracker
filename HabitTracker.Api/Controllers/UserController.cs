using HabitTracker.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Api.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IServiceManager _services;
        public UserController(IServiceManager service) => _services = service;

        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var result = _services.UserService.GetByUserName(username);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
