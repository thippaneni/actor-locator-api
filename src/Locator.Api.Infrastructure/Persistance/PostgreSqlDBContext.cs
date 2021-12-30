using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Infrastructure.Persistance
{
    public class PostgreSqlDBContext : DbContext, IApplicationDbContext
    {
        public DbSet<Route> Routes { get; init; }
        public DbSet<Landmark> LandMarks { get; init; }

        public PostgreSqlDBContext(DbContextOptions<PostgreSqlDBContext> options) : base(options)
        {
        }
    }
}
