using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Dtos.ViewModels;

namespace TrokaTroka.Api.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookshellViewModel>> GetBookshell(int page, int take, int skip);
        Task<BookViewModel> GetBookById(Guid idBook);
        Task<List<MyBooksViewModel>> GetMyBooks();
        Task<Guid> CreateBook(CreateBookInputModel bookInput);
        Task UpdateBook(UpdateBookInputModel bookInput);
        Task DeleteBook(Guid idBook);
    }
}