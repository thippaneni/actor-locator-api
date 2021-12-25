using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Contracts.Responses
{
    public class LandmarkResponse
    {        
        public string Name { get; init; }
        public string Code { get; init; }
        public Guid Id { get; init; }
    }
}
