using System;

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
