using Locator.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locator.Api.Core.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Route> Routes { get; init; }
        DbSet<Landmark> LandMarks { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellToken = default);
    }
}
