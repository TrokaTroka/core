using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(Guid idCategory);
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(Category category);
    }
}