using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Repositories
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotos();
        Task<Photo> GetPhotoById(Guid idPhoto);
        Task Create(List<Photo> photo);
        Task Update(Photo photo);
        Task Delete(Photo photo);
    }
}