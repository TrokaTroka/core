using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Services
{
    public interface IBlobStorageService
    {
        BlobResponse UploadFileToBlob(IFormFile image, Guid idBook);
        Task<byte[]> GetImage(string imageName);
        string GenerateFileName(Guid idBook);
    }
}
