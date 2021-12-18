using Locator.Api.Contracts.Requests;
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
        public Landmark StartingLandMark { get; }
        public Landmark EndingLandMark { get; }
        public IEnumerable<Landmark> ViaLandMarks { get; }
        //public GetDistanceBwLandmarksQuery(Landmark startingLandMarkdto, Landmark endingLandMarkdto, IEnumerable<Landmark> viaLandMarksdto)
        //{
        //    StartingLandMark = startingLandMarkdto;
        //    EndingLandMark = endingLandMarkdto;
        //    ViaLandMarks = viaLandMarksdto;
        //}
        public GetDistanceBwLandmarksQuery(GetDistanceBwLandmarksRequest request)
        {
            StartingLandMark = new Landmark() { Code = request.StatingLanmarkCode, Name = request.StatingLanmarkCode };
            EndingLandMark = new Landmark() { Code = request.EndingLanmarkCode, Name = request.EndingLanmarkCode };
            var viaLandMarks = new List<Landmark>();
            if (request.ViaLandmarkCodes != null && request.ViaLandmarkCodes.Any())
            {
                request.ViaLandmarkCodes.ToList().ForEach(lm => {
                    viaLandMarks.Add(new Landmark() { Code = lm, Name = lm });
                });
            }
            
            ViaLandMarks = viaLandMarks;
        }
    }
}
