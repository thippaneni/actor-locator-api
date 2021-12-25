using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Contracts.Responses
{
    public class GetAllRoutesResponse
    {
        public IEnumerable<RouteResponse> Data { get; set; } = new List<RouteResponse>();
    }
}
