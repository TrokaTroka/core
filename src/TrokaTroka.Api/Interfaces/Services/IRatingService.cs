using System;
using System.Threading.Tasks;
using TrokaTroka.Api.Dtos.InputModels;

namespace TrokaTroka.Api.Interfaces.Services
{
    public interface IRatingService
    {
        Task<Guid> Create(CreateRatingInputModel bookInput);
    }
}