using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Notifications;
using TrokaTroka.Api.Interfaces.Repositories;
using TrokaTroka.Api.Models;
using System.Linq;

namespace TrokaTroka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : MainController
    {
        private readonly ICategoryRepository _categoryService;
        public CategoriesController(ICategoryRepository categoryService,
            IAuthenticatedUser user,
            INotifier notifier) : base(user, notifier)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categoriesVM = await _categoryService.GetCategories();

            if (categoriesVM == null)
                return NotFound("");
            

            return Ok(categoriesVM.OrderBy(c => c.Name));
        }

        [HttpGet("{idCategory}")]
        public async Task<IActionResult> GetBookById(Guid idCategory)
        {
            var categoryVM = await _categoryService.GetCategoryById(idCategory);

            if (categoryVM == null)
                return BadRequest();

            return Ok(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateCategory inputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

            await _categoryService.Create(new Category(inputModel.Name));
            
            return Created(nameof(GetBookById), inputModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookInputModel inputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _categoryService.Update(new Category(inputModel.IdUser.ToString()));

            return NoContent();
        }

        [HttpDelete("{idBook}")]
        public async Task<IActionResult> DeleteBook(Guid idBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _categoryService.Delete(new Category(idBook.ToString()));

            return NoContent();
        }
    }
}
