using Locator.Api.Core.Locator.Models;
using Locator.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Common.Interfaces
{
    public interface IRouteRepository
    {
        Task<IEnumerable<Route>> GetAllRoutesAsync();

        Task<IEnumerable<string>> GetRoutesAsync(Landmark startingLandMark, Landmark endingLandMark);

        Task<RoutePath> GetNoOfRoutesAsync(Landmark startingLandMark, Landmark endingLandMark, int? maxStops);
    }
}
