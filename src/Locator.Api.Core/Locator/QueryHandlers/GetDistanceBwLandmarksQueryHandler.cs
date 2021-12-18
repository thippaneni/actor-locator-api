using Locator.Api.Core.Common.Interfaces;
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

        private readonly ILandmarkRepository _landmarkRepository;

        public GetDistanceBwLandmarksQueryHandler(ILandmarkRepository landmarkRepository)
        {
            _landmarkRepository = landmarkRepository;
        }
        public Task<int?> Handle(GetDistanceBwLandmarksQuery request, CancellationToken cancellationToken)
        {
            return _landmarkRepository.GetDistanceAsync(request.StartingLandMark, request.EndingLandMark, request.ViaLandMarks);
        }
    }
}
