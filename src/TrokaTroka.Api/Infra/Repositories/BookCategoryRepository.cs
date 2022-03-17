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
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly TrokatrokaDbContext _context;
        public BookCategoryRepository(TrokatrokaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookCategory>> GetBookCategories()
        {
            return await _context.BookCategories.ToListAsync();
        }

        public async Task<BookCategory> GetBookCategoryById(Guid idBook)
        {
            return await _context.BookCategories.Where(b => b.IdBook == idBook).FirstOrDefaultAsync();
        }

        public async Task Create(BookCategory bookCategory)
        {
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
        }

        public async Task Update(BookCategory bookCategory)
        {
            _context.BookCategories.Update(bookCategory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(BookCategory bookCategory)
        {
            _context.BookCategories.Remove(bookCategory);
            await _context.SaveChangesAsync();
        }
    }
}