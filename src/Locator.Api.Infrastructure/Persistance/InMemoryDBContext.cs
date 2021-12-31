using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Locator.Api.Infrastructure.Persistance
{
    public class InMemoryDBContext : DbContext, IApplicationDbContext
    {        
        public DbSet<Route> Routes { get; init; }
        public DbSet<Landmark> LandMarks { get; init; }

        public InMemoryDBContext(DbContextOptions<InMemoryDBContext> options) : base(options)
        {
        }
    }
}
