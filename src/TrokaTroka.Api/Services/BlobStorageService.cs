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
    public class    BlobStorageService : IBlobStorageService
    {
        private string connectionString;
        public BlobStorageService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BlobStorage");
        }

        public string GenerateFileName(Guid idBook)
        {
            return Guid.NewGuid().ToString() + "idBook=" + idBook.ToString();
        }

        private string UploadFileToBlob(string strFileName, IFormFile fileData, string fileMimeType)
        {
            var containerName = "images";
            var container = new BlobContainerClient(connectionString, containerName);
            container.CreateIfNotExists();

            //var imageName = GenerateFileName(strFileName);

            
            using var ms = new MemoryStream();
            fileData.CopyTo(ms);
            ms.Position = 0;
            

            //container.UploadBlob(imageName, ms);

            return "";
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

        public BlobResponse UploadFileToBlob(IFormFile image, Guid idBook)
        {
            var containerName = "images";
            var container = new BlobContainerClient(connectionString, containerName);
            container.CreateIfNotExists();

            var name = GenerateFileName(idBook);

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
