using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Notifications;

namespace TrokaTroka.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : MainController
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService,
            IAuthenticatedUser user,
            INotifier notifier) : base(user, notifier)
        {
            _ratingService = ratingService;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateRating([FromForm] CreateRatingInputModel inputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _ratingService.Create(inputModel);

            if (result.Equals(Guid.Empty))
                return BadRequest();
            
            return Created(nameof(CreateRating), result);
        }
    }
}
