using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Core.Locator.Models;
using Locator.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
