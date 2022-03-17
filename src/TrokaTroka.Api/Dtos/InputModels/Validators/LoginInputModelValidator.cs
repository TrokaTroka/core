using System.Data;
using FluentValidation;

namespace TrokaTroka.Api.Dtos.InputModels.Validators
{
    public class LoginInputModelValidator : AbstractValidator<LoginInputModel>
    {
        public LoginInputModelValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty()
                .NotNull();
        }
    }
}