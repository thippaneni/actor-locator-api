using Locator.Api.Core.Locator.Models;
using Locator.Api.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.Queries
{
    public class GetAllRoutesQuery : IRequest<IEnumerable<RouteModel>>
    {
    }
}
