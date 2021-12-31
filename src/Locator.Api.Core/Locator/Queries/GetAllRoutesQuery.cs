using Locator.Api.Core.Locator.Models;
using MediatR;
using System.Collections.Generic;

namespace Locator.Api.Core.Locator.Queries
{
    public class GetAllRoutesQuery : IRequest<IEnumerable<RouteModel>>
    {
    }
}
