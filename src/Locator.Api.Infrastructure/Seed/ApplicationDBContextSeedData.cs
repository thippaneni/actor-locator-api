using Locator.Api.Domain.Entities;
using Locator.Api.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Infrastructure.Seed
{
    public static class ApplicationDBContextSeedData
    {
        private static readonly IEnumerable<Landmark> _landmarks;
        private static readonly IEnumerable<Route> _routes;
        static ApplicationDBContextSeedData()
        {
            _landmarks = GetLandMarks();
            _routes = GetRoutes();
        }
        public static async Task SeedSampleDataAsync(InMemoryDBContext context)
        {
            if (!context.LandMarks.Any())
            {
                context.LandMarks.AddRange(_landmarks);
            }
            if (!context.Routes.Any())
            {
                context.Routes.AddRange(_routes);
            }
            await context.SaveChangesAsync();
        }
        private static IEnumerable<Route> GetRoutes()
        {
            return new List<Route>()
            {
                new() { StartLandmarkCode = "A", EndLandmarkCode = "B", RouteCode = "AB", Distance = 3 },
                new() { StartLandmarkCode = "B", EndLandmarkCode = "C", RouteCode = "BC", Distance = 9 },
                new() { StartLandmarkCode = "C", EndLandmarkCode = "D", RouteCode = "CD", Distance = 3 },
                new() { StartLandmarkCode = "D", EndLandmarkCode = "E", RouteCode = "DE", Distance = 6 },
                new() { StartLandmarkCode = "A", EndLandmarkCode = "D", RouteCode = "AD", Distance = 4 },
                new() { StartLandmarkCode = "D", EndLandmarkCode = "A", RouteCode = "DA", Distance = 5 },
                new() { StartLandmarkCode = "C", EndLandmarkCode = "E", RouteCode = "CE", Distance = 2 },
                new() { StartLandmarkCode = "A", EndLandmarkCode = "E", RouteCode = "AE", Distance = 4 },
                new() { StartLandmarkCode = "E", EndLandmarkCode = "B", RouteCode = "EB", Distance = 1 }

            };
        }

        private static IEnumerable<Landmark> GetLandMarks()
        {            
            return new List<Landmark>()
            {
                new() { Code = "A", Name = "A" },
                new() { Code = "B", Name = "B" },
                new() { Code = "C", Name = "C" },
                new() { Code = "D", Name = "D" },
                new() { Code = "E", Name = "E" }
            };
        }       
    }
}
