using System.Threading.Tasks;
using TrokaTroka.Api.Models;

namespace TrokaTroka.Api.Interfaces.Repositories
{
    public interface IRatingRepository
    {
        Task Create(Rating rating);
    }
}