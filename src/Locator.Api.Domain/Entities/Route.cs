using Locator.Api.Domain.Common;

namespace Locator.Api.Domain.Entities
{
    public class Route : BaseEntity
    {
        public string StartLandmarkCode { get; set; }
        public string EndLandmarkCode { get; set; }
        public int Distance { get; set; }
        public string RouteCode { get; set; }
    }
}
