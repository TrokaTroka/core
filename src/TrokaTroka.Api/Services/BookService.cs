using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Dtos.ViewModels;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Repositories;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Models;
using TrokaTroka.Api.Notifications;

namespace TrokaTroka.Api.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IBookRepository _bookRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookCategoryRepository _bookCategoryRepository;

        public BookService(IBookRepository bookRepository,
            IBookCategoryRepository bookCategoryRepository,
            IPhotoRepository photoRepository,
            IUserRepository userRepository,
            IBlobStorageService blobStorageService,
            IAuthenticatedUser user,
            INotifier notifier) : base(user, notifier)
        {
            _bookRepository = bookRepository;
            _bookCategoryRepository = bookCategoryRepository;
            _photoRepository = photoRepository;
            _userRepository = userRepository;
            _blobStorageService = blobStorageService;
        }



        public async Task<IEnumerable<BookshellViewModel>> GetBookshell(int page, int take, int skip)
        {
            var books = await _bookRepository.GetBooks(page =0, take=0, skip =0);

            var bookshellVM = new List<BookshellViewModel>();

            foreach (var book in books)
            {
                var photo = book.Photos.Select(c => c.Path).FirstOrDefault();

                var ratings = book.Owner.Ratings;

                var grade = ratings.Count == 0
                    ? 0
                    : ratings.Sum(r => r.Grade) / ratings.ToArray().Length;

                bookshellVM.Add(new BookshellViewModel(
                    book.Id,
                    book.Title,
                    book.Owner.Name,
                    grade,
                    photo
                    )
                );
            }

            return bookshellVM;
        }

        public async Task<BookViewModel> GetBookById(Guid idBook)
        {
            var book = await _bookRepository.GetBookById(idBook);

            if (book == null)
                return null;

            return new BookViewModel(
                book.Id,
                book.Title,
                book.Author,
                book.Isbn,
                book.Publisher,
                book.Model,
                book.Language,
                book.Reason,
                book.BuyPrice,
                book.BuyDate,
                book.IdUser
            );
        }

        public async Task<List<MyBooksViewModel>> GetMyBooks()
        {
            var user = await _user.GetUserDtoLogged();

            var books = await _bookRepository.BookByUserId(user.Id);

            if (!books.Any())
            {
                Notify("Usuário não possui livros cadastrados.");
                return null;
            }

            var bookVM = new List<MyBooksViewModel>();

            books.ToList().ForEach(b =>
                bookVM.Add(new MyBooksViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Model = b.Model,
                    BuyPrice = b.BuyPrice,
                    Language = b.Language
                }));

            return bookVM;
        }

        public async Task<Guid> CreateBook(CreateBookInputModel bookInput)
        {
            var user = await _user.GetUserDtoLogged();

            var book = new Book(
                bookInput.Title,
                bookInput.Author,
                bookInput.Isbn,
                bookInput.Publisher,
                bookInput.Model,
                bookInput.Language,
                bookInput.Reason,
                bookInput.BuyPrice,
                bookInput.BuyDate,
                user.Id
                );

            var photos = new List<Photo>();

            var response = new List<BlobResponse>();

            if (bookInput.Images.Any())
            {
                bookInput.Images.ForEach(i =>
                    response.Add(_blobStorageService.UploadFileToBlob(i, book.Id)));

                if (response is null)
                    return Guid.Empty;

                response.ForEach(r => photos.Add(new Photo(r.Uri.AbsoluteUri + "/" + r.Name, r.Name, book.Id)));
            }            

            var bookCategory = new BookCategory(book.Id, bookInput.IdCategory);

            await _bookRepository.Create(book);

            await _photoRepository.Create(photos);

            await _bookCategoryRepository.Create(bookCategory);

            return book.Id;
        }

        public async Task UpdateBook(UpdateBookInputModel bookInput)
        {
            var book = new Book(
                bookInput.Title,
                bookInput.Author,
                bookInput.Isbn,
                bookInput.Publisher,
                bookInput.Model,
                bookInput.Language,
                bookInput.Reason,
                bookInput.BuyPrice,
                bookInput.BuyDate,
                bookInput.IdUser);

            await _bookRepository.Update(book);
        }

        public async Task DeleteBook(Guid idBook)
        {
            var book = await _bookRepository.GetBookById(idBook);

            if (book == null)
            {
                Notify("Livro não encontrado");
                return;
            }

            await _bookRepository.Delete(book);
        }
    }
}