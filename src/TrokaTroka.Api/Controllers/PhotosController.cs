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
    public class PhotosController : MainController
    {
        private readonly IBlobStorageService _blobStorageService;
        private readonly IBookService _bookService;
        public PhotosController(IBookService bookService,
            IBlobStorageService blobStorageService,
            IAuthenticatedUser user,
            INotifier notifier) : base(user, notifier)
        {
            _bookService = bookService;
            _blobStorageService = blobStorageService;
        }
    }
}
