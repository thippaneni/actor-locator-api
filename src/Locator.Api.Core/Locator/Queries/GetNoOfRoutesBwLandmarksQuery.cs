using Locator.Api.Core.Locator.Models;
using Locator.Api.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.Queries
{
    public class GetNoOfRoutesBwLandmarksQuery : IRequest<RoutePath>
    {
        public Landmark startingLandMark { get; }
        public Landmark endingLandMark { get; }
        public int? maxStops { get; }
        public GetNoOfRoutesBwLandmarksQuery(Landmark startingLandMarkdto, Landmark endingLandMarkdto, int? stops)
        {
            startingLandMark = startingLandMarkdto;
            endingLandMark = endingLandMarkdto;
            maxStops = stops;
        }
    }
}
