using HabitTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Api.Controllers
{

    [Route("habitList")]
    [ApiController]
    public class HabitListController : ControllerBase
    {
        private readonly IServiceManager _services;
        public HabitListController(IServiceManager service) => _services = service;



    }
}
