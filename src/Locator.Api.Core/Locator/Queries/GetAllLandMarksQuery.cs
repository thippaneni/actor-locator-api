using Locator.Api.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.Queries
{
    public class GetAllLandMarksQuery : IRequest<IEnumerable<Landmark>>
    {
    }
}
