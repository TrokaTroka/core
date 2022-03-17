using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrokaTroka.Api.Infra.Context;
using TrokaTroka.Api.Interfaces.Repositories;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Infra.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly TrokatrokaDbContext _context;
        public PhotoRepository(TrokatrokaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            return await _context.Photos.ToListAsync();
        }

        public async Task<Photo> GetPhotoById(Guid idPhoto)
        {
            return await _context.Photos.Where(b => b.Id == idPhoto).FirstOrDefaultAsync();
        }

        public async Task Create(List<Photo> photos)
        {
            await _context.Photos.AddRangeAsync(photos);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Photo photo)
        {
            _context.Photos.Update(photo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Photo photo)
        {
            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();
        }
    }
}