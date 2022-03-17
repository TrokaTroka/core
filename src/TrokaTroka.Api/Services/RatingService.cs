using System;
using System.Threading.Tasks;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Repositories;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Models;
using TrokaTroka.Api.Notifications;

namespace TrokaTroka.Api.Services
{
    public class RatingService : BaseService, IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository,
            IAuthenticatedUser user,
            INotifier notifier) : base(user, notifier)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<Guid> Create(CreateRatingInputModel ratingInput)
        {
            var user = await _user.GetUserDtoLogged();

            if(user is null)
            {
                Notify("User não encontrado");
                return Guid.Empty;
            }

            var rating = new Rating(ratingInput.Grade,
                ratingInput.Comment, user.Id, ratingInput.IdRated);

            await _ratingRepository.Create(rating);
            
            return rating.Id;
        }
    }
}