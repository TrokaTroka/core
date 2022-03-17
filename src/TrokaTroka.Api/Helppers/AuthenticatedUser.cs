using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TrokaTroka.Api.Dtos;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Repositories;

namespace TrokaTroka.Api.Helppers
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserRepository _userRepository;
        public AuthenticatedUser(IHttpContextAccessor accessor,
            IUserRepository userRepository)
        {
            _accessor = accessor;
            _userRepository = userRepository;
        }

        public async Task<ResponseUserLogged> GetUserDtoLogged()
        {
            var email = _accessor.HttpContext.User.Identity.Name;

            var user = await _userRepository.GetUserByEmail(email);

            return new ResponseUserLogged(user.Id, user.Email);
        }
    }
}