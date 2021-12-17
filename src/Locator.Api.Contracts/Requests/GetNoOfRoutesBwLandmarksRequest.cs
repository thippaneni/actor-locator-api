using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Contracts.Requests
{
    public class GetNoOfRoutesBwLandmarksRequest
    {
        public string StatingLanmarkCode { get; set; }
        public string EndingLanmarkCode { get; set; }
        public int? MaxStops  { get; set; }
    }
}
