using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
