using Locator.Api.Core.Locator.Interfaces;
using Locator.Api.Core.Locator.Models;
using Locator.Api.Core.Locator.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.QueryHandlers
{
    public class GetNoOfRoutesBwLandmarksQueryHandler : IRequestHandler<GetNoOfRoutesBwLandmarksQuery, RoutePath>
    {
        private readonly ILocatorService _locatorService;
        public GetNoOfRoutesBwLandmarksQueryHandler(ILocatorService locatorService)
        {
            _locatorService = locatorService;
        }

        public async Task<RoutePath> Handle(GetNoOfRoutesBwLandmarksQuery request, CancellationToken cancellationToken)
        {
            return await _locatorService.GetNoOfRoutesAsync(request.StartingLandMark, request.EndingLandMark, request.MaxStops);
        }
        
    }
}
