using System.Threading.Tasks;
using TrokaTroka.Api.Infra.Context;
using TrokaTroka.Api.Interfaces.Repositories;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Infra.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly TrokatrokaDbContext _context;
        public RatingRepository(TrokatrokaDbContext context)
        {
            _context = context;
        }

        public async Task Create(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
        }
    }
}