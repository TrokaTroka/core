using FluentValidation;
using FluentValidation.Results;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Notifications;

namespace TrokaTroka.Api.Services
{
    public class BaseService
    {
        protected readonly IAuthenticatedUser _user;
        protected readonly INotifier _notifier;
        public BaseService(IAuthenticatedUser user, 
            INotifier notifier)
        {
            _user = user;
            _notifier = notifier;
        }
        
        public void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        public void Notify(ValidationResult result)
        {
            foreach (var error in result.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        public bool Validate<TR, TE>(TR validator, TE entity) where TR : AbstractValidator<TE>
        {
            var result = validator.Validate(entity);

            if (result.IsValid) return true;

            Notify(result);
            return false;
        }
    }
}