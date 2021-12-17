using Locator.Api.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.Queries
{
    public class GetDistanceBwLandmarksQuery : IRequest<int?>
    {
        public Landmark startingLandMark { get; }
        public Landmark endingLandMark { get; }
        public IEnumerable<Landmark> viaLandMarks { get; }
        public GetDistanceBwLandmarksQuery(Landmark startingLandMarkdto, Landmark endingLandMarkdto, IEnumerable<Landmark> viaLandMarksdto)
        {
            startingLandMark = startingLandMarkdto;
            endingLandMark = endingLandMarkdto;
            viaLandMarks = viaLandMarksdto;
        }        
    }
}
