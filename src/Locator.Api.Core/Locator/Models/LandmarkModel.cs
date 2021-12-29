using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.Models
{
    public class LandmarkModel
    {
        public Guid LandmarkId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
