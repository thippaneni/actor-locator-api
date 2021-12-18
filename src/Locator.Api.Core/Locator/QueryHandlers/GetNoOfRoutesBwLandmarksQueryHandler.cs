using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Core.Locator.Models;
using Locator.Api.Core.Locator.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.QueryHandlers
{
    public class GetNoOfRoutesBwLandmarksQueryHandler : IRequestHandler<GetNoOfRoutesBwLandmarksQuery, RoutePath>
    {
        private readonly IRouteRepository _routeRepository;

        public GetNoOfRoutesBwLandmarksQueryHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public Task<RoutePath> Handle(GetNoOfRoutesBwLandmarksQuery request, CancellationToken cancellationToken)
        {
            return _routeRepository.GetNoOfRoutesAsync(request.StartingLandMark, request.EndingLandMark, request.MaxStops);
        }
        
    }
}
