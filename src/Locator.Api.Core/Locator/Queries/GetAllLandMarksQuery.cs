using Locator.Api.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Locator.Api.Core.Locator.Queries
{
    public class GetAllLandMarksQuery : IRequest<IEnumerable<Landmark>>
    {
    }
}
