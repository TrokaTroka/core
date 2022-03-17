using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Repositories
{
    public interface IBookCategoryRepository
    {
        Task<IEnumerable<BookCategory>> GetBookCategories();
        Task<BookCategory> GetBookCategoryById(Guid idBook);
        Task Create(BookCategory bookCategory);
        Task Update(BookCategory bookCategory);
        Task Delete(BookCategory bookCategory);
    }
}