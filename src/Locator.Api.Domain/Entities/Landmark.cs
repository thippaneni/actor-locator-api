using Locator.Api.Domain.Common;

namespace Locator.Api.Domain.Entities
{
    public class Landmark : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
