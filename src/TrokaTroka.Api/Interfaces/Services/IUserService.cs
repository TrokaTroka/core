using System.Threading.Tasks;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Dtos.ViewModels;

namespace TrokaTroka.Api.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserViewModel> UpdateUser(UpdateUserInputModel inputModel);
    }
}