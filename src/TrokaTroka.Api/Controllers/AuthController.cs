using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Notifications;

namespace TrokaTroka.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService,
            IAuthenticatedUser user,
            INotifier notifier) : base(user, notifier)
        {
            _authService = authService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginInputModel loginInput)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AuthUser(loginInput);

            if (result == null)
                return BadRequest("");

            return Ok(result);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] CreateUserInputModel userInput)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.CreateUser(userInput);

            if (result == null)
                return BadRequest("");

            return Created(nameof(SignIn), result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshTokenId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var refreshToken = await _authService.ObterRefreshToken(Guid.Parse(refreshTokenId));

            if (refreshToken is null)
                return BadRequest("Refresh token expirado");

            var token = _authService.GerarJwtToken(refreshToken.Username);

            return Ok(token);
        }
    }
}
