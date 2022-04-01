using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrokaTroka.Api.Infra.Context;
using TrokaTroka.Api.Interfaces.Repositories;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TrokatrokaDbContext _context;
        public UserRepository(TrokatrokaDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> UserAuth(string email, string password)
        {
            return await _context.Users.Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task Update(User user)
        {
            var entry = _context.Entry(user);

            if (entry.State != EntityState.Modified)
                entry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}