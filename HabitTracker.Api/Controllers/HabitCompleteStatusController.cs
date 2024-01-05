using HabitTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Api.Controllers
{
    [Route("HabitCompleteStatus")]
    [ApiController]
    public class HabitCompleteStatusController : ControllerBase
    {
        private readonly IServiceManager _services;
        public HabitCompleteStatusController(IServiceManager service) => _services = service;




    }
}
