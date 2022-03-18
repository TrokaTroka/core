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
        private readonly IUserService _userService;
        public AuthController(IUserService userService,
            IAuthenticatedUser user,
            INotifier notifier) : base(user, notifier)
        {
            _userService = userService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginInputModel loginInput)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.AuthUser(loginInput);

            if (result == null)
                return BadRequest("");

            return Ok(result);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] CreateUserInputModel userInput)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.CreateUser(userInput);

            return Created(nameof(SignIn), user);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshTokenId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var refreshToken = await _userService.ObterRefreshToken(Guid.Parse(refreshTokenId));

            if (refreshToken is null)
                return BadRequest("Refresh token expirado");

            var token = _userService.GerarJwtToken(refreshToken.Username);

            return Ok(token);
        }
    }
}
