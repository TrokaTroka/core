using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Notifications;

namespace TrokaTroka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : MainController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService,
            IAuthenticatedUser user,
            INotifier notifier) : base(user, notifier)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserInputModel inputModel)
        {
            var result = await _userService.UpdateUser(inputModel);

            if (result == null)
                return BadRequest("");

            return Ok(result);
        }
    }
}
