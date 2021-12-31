using Locator.Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locator.Api.Core.Common.Interfaces
{
    public interface ILandmarkRepository
    {
        Task<IEnumerable<Landmark>> GetAllLandMarksAsync();

        IEnumerable<Landmark> GetAdjecentLandMarksAsync(Landmark landmark);

        Landmark GetLandMarkByCodeAsync(string code);
    }
}
