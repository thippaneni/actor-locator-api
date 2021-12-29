using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Core.Locator.Interfaces;
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
    public class GetDistanceBwLandmarksQueryHandler : IRequestHandler<GetDistanceBwLandmarksQuery, int?>
    {

        private readonly ILocatorService _locatorService;

        public GetDistanceBwLandmarksQueryHandler(ILocatorService locatorService)
        {
            _locatorService = locatorService;
        }
        public async Task<int?> Handle(GetDistanceBwLandmarksQuery request, CancellationToken cancellationToken)
        {
            return await _locatorService.GetDistanceAsync(request.StartingLandMark, request.EndingLandMark, request.ViaLandMarks);
        }
    }
}
