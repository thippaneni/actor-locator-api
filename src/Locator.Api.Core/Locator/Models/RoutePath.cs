using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.Models
{
    public class RoutePath
    {
        public int NoOfRoutes { get; set; }
        public IEnumerable<string> Routes { get; set; } = new List<string>();
    }
}
