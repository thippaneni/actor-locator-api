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
    public class GetAllLandMarksQueryHandler : IRequestHandler<GetAllLandMarksQuery, IEnumerable<Landmark>>
    {
        private readonly ILandmarkRepository _landmarkRepository;

        public GetAllLandMarksQueryHandler(ILandmarkRepository landmarkRepository)
        {
            _landmarkRepository = landmarkRepository;
        }
        public Task<IEnumerable<Landmark>> Handle(GetAllLandMarksQuery request, CancellationToken cancellationToken)
        {
            return _landmarkRepository.GetAllLandMarksAsync();
        }
    }
}
