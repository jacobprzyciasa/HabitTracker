using HabitTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Api.Controllers
{

    [Route("habit")]
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IServiceManager _services;
        public HabitController(IServiceManager service) => _services = service;






    }
}
