using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.Models
{
    public class RouteModel
    {
        public Guid RouteId { get; set; }
        public LandmarkModel StartLandmark { get; set; }
        public LandmarkModel EndLandmark { get; set; }
        public int Distance { get; set; }
        public string RouteCode { get; set; }
    }
}
