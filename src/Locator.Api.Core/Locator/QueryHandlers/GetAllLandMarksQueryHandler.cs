using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Core.Locator.Interfaces;
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
        private readonly ILocatorService _locatorService;

        public GetAllLandMarksQueryHandler(ILocatorService locatorService)
        {
            _locatorService = locatorService;
        }
        public async Task<IEnumerable<Landmark>> Handle(GetAllLandMarksQuery request, CancellationToken cancellationToken)
        {
            return await _locatorService.GetAllLandMarksAsync();
        }
    }
}
