using Locator.Api.Core.Locator.Interfaces;
using Locator.Api.Core.Locator.Models;
using Locator.Api.Core.Locator.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.QueryHandlers
{
    public class GetAllRoutesQueryHandler : IRequestHandler<GetAllRoutesQuery, IEnumerable<RouteModel>>
    {
        private readonly ILocatorService _locatorService;

        public GetAllRoutesQueryHandler(ILocatorService locatorService)
        {
            _locatorService = locatorService;
        }
        public async Task<IEnumerable<RouteModel>> Handle(GetAllRoutesQuery request, CancellationToken cancellationToken)
        {
            return await _locatorService.GetAllRoutesAsync();
        }
    }
}
