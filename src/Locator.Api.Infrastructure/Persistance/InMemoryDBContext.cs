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
    public class InMemoryDBContext : IApplicationDbContext
    {        
        public IEnumerable<Route> Routes { get; init; } = GetRoutes();
        public IEnumerable<Landmark> LandMarks { get; init; } = GetLandMarks();
        
        private static IEnumerable<Route> GetRoutes()
        {
            var landmarks = GetLandMarks().ToList();
            var landMarkA = landmarks.Single(l => l.Code == "A");
            var landMarkB = landmarks.Single(l => l.Code == "B");
            var landMarkC = landmarks.Single(l => l.Code == "C");
            var landMarkD = landmarks.Single(l => l.Code == "D");
            var landMarkE = landmarks.Single(l => l.Code == "E");
            
            return new List<Route>()
            {
                new() { StartLandmark = landMarkA, EndLandmark = landMarkB, RouteCode = "AB", Distance =3 },
                new() { StartLandmark = landMarkB, EndLandmark = landMarkC, RouteCode = "BC", Distance =9 },
                new() { StartLandmark = landMarkC, EndLandmark = landMarkD, RouteCode = "CD", Distance =3 },
                new() { StartLandmark = landMarkD, EndLandmark = landMarkE, RouteCode = "DE", Distance =6 },
                new() { StartLandmark = landMarkA, EndLandmark = landMarkD, RouteCode = "AD", Distance =4 },
                new() { StartLandmark = landMarkD, EndLandmark = landMarkA, RouteCode = "DA", Distance =5 },
                new() { StartLandmark = landMarkC, EndLandmark = landMarkE, RouteCode = "CE", Distance =2 },
                new() { StartLandmark = landMarkA, EndLandmark = landMarkE, RouteCode = "AE", Distance =4 },
                new() { StartLandmark = landMarkE, EndLandmark = landMarkB, RouteCode = "EB", Distance =1 }

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
