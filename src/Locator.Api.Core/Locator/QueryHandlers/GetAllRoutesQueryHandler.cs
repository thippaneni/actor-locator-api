using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Core.Locator.Queries;
using Locator.Api.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.QueryHandlers
{
    public class GetAllRoutesQueryHandler : IRequestHandler<GetAllRoutesQuery, IEnumerable<Route>>
    {
        private readonly IRouteRepository _routeRepository;

        public GetAllRoutesQueryHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }
        public Task<IEnumerable<Route>> Handle(GetAllRoutesQuery request, CancellationToken cancellationToken)
        {
            return _routeRepository.GetAllRoutesAsync();
        }
    }
}
