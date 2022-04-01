using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Dtos.InputModels.Querys;
using TrokaTroka.Api.Dtos.ViewModels;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Services
{
    public interface IBookService
    {
        Task<PaginatedVM<BookshellViewModel>> GetBookshell(PaginationQuery paginationQuery);
        Task<BookViewModel> GetBookById(Guid idBook);
        Task<List<MyBooksViewModel>> GetMyBooks();
        Task<Guid> CreateBook(CreateBookInputModel bookInput);
        Task UpdateBook(UpdateBookInputModel bookInput);
        Task DeleteBook(Guid idBook);
    }
}