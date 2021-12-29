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
        public IEnumerable<Route> GetAllRoutesAsync()
        {           
            return _context.Routes.ToList();
        }
       
        public IEnumerable<string> GetRoutesAsync(Landmark startingLandMark, Landmark endingLandMark)
        {            
            var landmarks = _ILandmarkRepository.GetAllLandMarksAsync();
            var isLandmarkVisited = new Dictionary<string, bool>();

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

            foreach (var landmark in _ILandmarkRepository.GetAdjecentLandMarksAsync(startingLandMark))
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
