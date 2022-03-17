using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks(int page, int take, int skip);
        Task<Book> GetBookById(Guid idBook);
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(Book book);
    }
}