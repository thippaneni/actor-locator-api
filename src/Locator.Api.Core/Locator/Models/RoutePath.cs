using System.Collections.Generic;

namespace Locator.Api.Core.Locator.Models
{
    public class RoutePath
    {
        public int NoOfRoutes { get; set; }
        public IEnumerable<string> Routes { get; set; }
    }
}
