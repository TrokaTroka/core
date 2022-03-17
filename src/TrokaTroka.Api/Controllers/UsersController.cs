using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrokaTroka.Api.Interfaces.Services;

namespace TrokaTroka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBlobStorageService _blobStorageService;
        public UsersController(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        [HttpPost]
        public IActionResult AddAvatar(IFormFile file)
        {
            //_blobStorageService.UploadFileToBlob(file.FileName, file, file.ContentType);
            return Ok();
        }
    }
}
