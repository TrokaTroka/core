using System.Threading.Tasks;
using TrokaTroka.Api.Dtos;

namespace TrokaTroka.Api.Interfaces
{
    public interface IAuthenticatedUser
    {
        Task<ResponseUserLogged> GetUserDtoLogged();
    }
}