using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locator.Api.Infrastructure.Locator.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly IApplicationDbContext _context;
        public RouteRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Route>> GetAllRoutesAsync()
        {           
            return await _context.Routes.ToListAsync();
        }
    }
}
