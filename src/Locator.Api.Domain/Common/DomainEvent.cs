using System;

namespace Locator.Api.Domain.Common
{
    public abstract class DomainEvent
    {
        public bool IsPublished { get; set; }
        public DateTimeOffset DomainEventPublishedOn { get; init; } = DateTimeOffset.UtcNow;
    }
}
