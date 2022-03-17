using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Notifications;

namespace TrokaTroka.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : MainController
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService,
            IBlobStorageService blobStorageService,
            IAuthenticatedUser user,
            INotifier notifier) : base(user, notifier)
        {
            _bookService = bookService;
            _blobStorageService = blobStorageService;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetBookshell(int page, int take, int skip)
        {
            var booksVM = await _bookService.GetBookshell(page =0, take = 0, skip = 0);

            if (booksVM == null)
                return NotFound("");

            return Ok(booksVM);
        }

        [HttpGet("{idBook}")]
        public async Task<IActionResult> GetBookById(Guid idBook)
        {
            var bookVM = await _bookService.GetBookById(idBook);

            if (bookVM == null)
                return BadRequest();

                return Ok(bookVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookInputModel inputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (inputModel.Images.Count == 0)
                return BadRequest();

            var result = await _bookService.CreateBook(inputModel);

            if (result.Equals(Guid.Empty))
                return BadRequest();
            
            return Created(nameof(GetBookById), result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookInputModel inputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _bookService.UpdateBook(inputModel);

            return NoContent();
        }

        [HttpDelete("{idBook}")]
        public async Task<IActionResult> DeleteBook(Guid idBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _bookService.DeleteBook(idBook);

            return NoContent();
        }
    }
}
