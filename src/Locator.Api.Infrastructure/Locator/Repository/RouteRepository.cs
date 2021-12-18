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
        private readonly ILandmarkRepository _ILandmarkRepository;

        public RouteRepository(IApplicationDbContext context, ILandmarkRepository LandmarkRepository)
        {
            _context = context;
            _ILandmarkRepository = LandmarkRepository;
        }
        public async Task<IEnumerable<Route>> GetAllRoutesAsync()
        {           
            return await Task.Run(() => _context.Routes.ToList());
        }

        public async Task<RoutePath> GetNoOfRoutesAsync(Landmark startingLandMark, Landmark endingLandMark, int? maxStops)
        {
            var routePath = new RoutePath();
            var routes = await GetRoutesAsync(startingLandMark, endingLandMark);
            var paths = new List<string>();
            if (routes != null && routes.Any())
            {
                if (!maxStops.HasValue)
                {                    
                    return new RoutePath() { NoOfRoutes = routes.Count() , Routes = routes };
                }
                routes.ToList().ForEach(route =>
                {
                    if (route.Split("->").Length <= maxStops + 2) // +2 is for including starting and ending landmarks
                    {
                        paths.Add(route);                        
                    }
                });
            }
            return new RoutePath() { NoOfRoutes = paths.Count(), Routes = paths };
        }
        public async Task<IEnumerable<string>> GetRoutesAsync(Landmark startingLandMark, Landmark endingLandMark)
        {
            var isLandmarkVisited = new Dictionary<string, bool>();
            var landmarks = await _ILandmarkRepository.GetAllLandMarksAsync();
            
            landmarks.ToList().ForEach(lm => {
                isLandmarkVisited.Add(lm.Code, false);
            });

            var routes = new List<string>();
            routes.Add(startingLandMark.Code);

            var routesList = new List<string>();
            GetAllRoutes(startingLandMark, endingLandMark, isLandmarkVisited, routes, routesList);

            return routesList;
        }
        private void GetAllRoutes(Landmark startingLandMark, Landmark endingLandMark, Dictionary<string, bool> isLandmarkVisited, List<string> routes, List<string> result)
        {            
            if (startingLandMark.Code.Equals(endingLandMark.Code))
            {
                result.Add(string.Join("->", routes));
                return;
            }

            isLandmarkVisited[startingLandMark.Code] = true; //current route visited

            foreach (var landmark in _ILandmarkRepository.GetAdjecentLandMarksAsync(startingLandMark).Result)
            {
                if (!isLandmarkVisited[landmark.Code])
                {                    
                    routes.Add(landmark.Code); // store current route
                    GetAllRoutes(landmark, endingLandMark, isLandmarkVisited, routes, result);
                    
                    routes.Remove(landmark.Code); // remove current route
                }
            }

            isLandmarkVisited[startingLandMark.Code] = false;            
        }
    }
}
