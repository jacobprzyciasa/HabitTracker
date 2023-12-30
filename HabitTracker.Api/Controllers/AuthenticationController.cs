using HabitTracker.Api.Services.Authentication;
using HabitTracker.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.Api.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public AuthenticationController(IAuthenticationService authService) => _authService = authService;


        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _authService.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            { 
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authService.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _authService.CreateToken(populateExp: true);
            return Ok(tokenDto);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await
            _authService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }



    }
}
