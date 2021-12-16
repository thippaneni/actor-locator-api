using Locator.Api.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Domain.Entities
{
    public class Landmark : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
