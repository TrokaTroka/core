using System;
using System.Threading.Tasks;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
        Task<User> UserAuth(string email, string password);
        Task Create(User user);
        Task Update(User user);
    }
}