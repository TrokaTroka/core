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
    public class BookRepository : IBookRepository
    {
        private readonly TrokatrokaDbContext _context;
        public BookRepository(TrokatrokaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooks(int page, int take, int skip)
        {
            var books = await _context.Books
                .Include(c => c.Owner)
                .Include(b => b.Photos)
                .Include(u => u.Owner.Ratings)
                .ToListAsync();

            return books;
        }

        public async Task<Book> GetBookById(Guid idBook)
        {
            return await _context.Books
                .Where(b => b.Id == idBook)
                .FirstOrDefaultAsync();
        }

        public async Task Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}