using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Canducci.Pagination;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<PaginatedRest<Book>> GetBooks(int pageSize, int pageNumber);
        Task<IEnumerable<Book>> BookByUserId(Guid idUser);
        Task<Book> GetBookById(Guid idBook);       
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(Book book);
    }
}