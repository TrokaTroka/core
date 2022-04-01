using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Services
{
    public interface IBlobStorageService
    {
        BlobResponse UploadFileToBlob(IFormFile image, Guid idBook, string containerName);
        BlobResponse UploadFileToBlobWithName(IFormFile image, Guid idBook, string containerName, string name);
        Task<byte[]> GetImage(string imageName);
        string GenerateFileName(Guid id);
    }
}
