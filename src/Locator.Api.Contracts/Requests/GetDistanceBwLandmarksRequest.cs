using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Contracts.Requests
{
    public class GetDistanceBwLandmarksRequest
    {
        public string StatingLanmarkCode { get; set; }
        public string EndingLanmarkCode { get; set; }
        public IEnumerable<string> ViaLandmarkCodes { get; set; } = new List<string>();
    }
}
