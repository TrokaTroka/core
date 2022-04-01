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

        public async Task<IEnumerable<PhotosBook>> GetPhotos()
        {
            return await _context.PhotosBooks.ToListAsync();
        }

        public async Task<PhotosBook> GetPhotoById(Guid idPhoto)
        {
            return await _context.PhotosBooks.Where(b => b.Id == idPhoto).FirstOrDefaultAsync();
        }

        public async Task Create(List<PhotosBook> photos)
        {
            await _context.PhotosBooks.AddRangeAsync(photos);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PhotosBook photo)
        {
            _context.PhotosBooks.Update(photo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(PhotosBook photo)
        {
            _context.PhotosBooks.Remove(photo);
            await _context.SaveChangesAsync();
        }
    }
}