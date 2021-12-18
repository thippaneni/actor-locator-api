using Locator.Api.Contracts.Requests;
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
        public Landmark StartingLandMark { get; }
        public Landmark EndingLandMark { get; }
        public int? MaxStops { get; }
        public GetNoOfRoutesBwLandmarksQuery(GetNoOfRoutesBwLandmarksRequest request)
        {
            StartingLandMark = new Landmark() { Code = request.StatingLanmarkCode, Name = request.StatingLanmarkCode };
            EndingLandMark = new Landmark() { Code = request.EndingLanmarkCode, Name = request.EndingLanmarkCode };
            MaxStops = request.MaxStops;
        }
    }
}
