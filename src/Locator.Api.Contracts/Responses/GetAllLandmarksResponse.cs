using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Contracts.Responses
{
    public class GetAllLandmarksResponse
    {
        public IEnumerable<LandmarkResponse> Data { get; set; }
    }
}
