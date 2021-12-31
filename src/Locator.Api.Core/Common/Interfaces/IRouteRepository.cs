using Locator.Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locator.Api.Core.Common.Interfaces
{
    public interface IRouteRepository
    {
        Task<IEnumerable<Route>> GetAllRoutesAsync();
    }
}
