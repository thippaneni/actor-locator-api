using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Contracts.Responses
{
    public class RouteResponse
    {
        public LandmarkResponse StartLandmark { get; set; }
        public LandmarkResponse EndLandmark { get; set; }
        public int Distance { get; set; }
        public string RouteCode { get; set; }
        public Guid Id { get; init; }
    }
}
