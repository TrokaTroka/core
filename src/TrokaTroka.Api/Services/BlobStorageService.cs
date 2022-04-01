using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private string connectionString;
        public BlobStorageService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BlobStorage");
        }

        public string GenerateFileName(Guid id)
        {
            return Guid.NewGuid().ToString() + "id=" + id.ToString();
        }

        public async Task<byte[]> GetImage(string imageName)
        {
            var containerName = "images";
            var container = new BlobContainerClient(connectionString, containerName);

            var blobClient = container.GetBlobClient(imageName);

            var downloadContent = await blobClient.DownloadAsync();

            using var ms = new MemoryStream();
            await downloadContent.Value.Content.CopyToAsync(ms);
            return ms.ToArray();
        }

        public BlobResponse UploadFileToBlob(IFormFile image, Guid id, string containerName)
        {
            var container = new BlobContainerClient(connectionString, containerName);
            container.CreateIfNotExists();

            var name = GenerateFileName(id);

            using var ms = new MemoryStream();
            image.CopyTo(ms);
            ms.Position = 0;

            container.UploadBlob(name, ms);

            return new BlobResponse
            {
                Uri = container.Uri,
                Name = name
            };
        }

        public BlobResponse UploadFileToBlobWithName(IFormFile image, Guid id, string containerName, string name)
        {
            var container = new BlobContainerClient(connectionString, containerName);
            container.CreateIfNotExists();

            using var ms = new MemoryStream();
            image.CopyTo(ms);
            ms.Position = 0;

            container.UploadBlob(name, ms);

            return new BlobResponse
            {
                Uri = container.Uri,
                Name = name
            };
        }
    }
}
