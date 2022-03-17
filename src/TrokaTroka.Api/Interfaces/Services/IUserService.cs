using System;
using System.Threading.Tasks;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Dtos.ViewModels;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Services
{
    public interface IUserService
    {
        Task<TokenViewModel> CreateUser(CreateUserInputModel userInput);
        Task<TokenViewModel> AuthUser(LoginInputModel loginInput);
        Task<RefreshToken> ObterRefreshToken(Guid refreshToken);
        Task<TokenViewModel> GerarJwtToken(string refreshToken);
    }
}