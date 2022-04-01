using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Repositories
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<PhotosBook>> GetPhotos();
        Task<PhotosBook> GetPhotoById(Guid idPhoto);
        Task Create(List<PhotosBook> photo);
        Task Update(PhotosBook photo);
        Task Delete(PhotosBook photo);
    }
}