using Locator.Api.Core.Locator.Models;
using Locator.Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.Interfaces
{
    public interface ILocatorService
    {
        Task<IEnumerable<Landmark>> GetAllLandMarksAsync();
        Task<int?> GetDistanceAsync(Landmark startingLandMark, Landmark endingLandMark, IEnumerable<Landmark> viaLandMarks);
        Task<IEnumerable<RouteModel>> GetAllRoutesAsync();
        Task<RoutePath> GetNoOfRoutesAsync(Landmark startingLandMark, Landmark endingLandMark, int? maxStops);
    }
}
