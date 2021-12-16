using Locator.Api.Core.Common.Interfaces;
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

        public async Task<IEnumerable<string>> GetRoutesAsync(Landmark startingLandMark, Landmark endingLandMark)
        {
            var routes = new List<string>();

            var isLandmarkVisited = new Dictionary<string, bool>();
            var landmarks = await _ILandmarkRepository.GetAllLandMarksAsync();
            
            landmarks.ToList().ForEach(lm => {
                isLandmarkVisited.Add(lm.Code, false);
            });
            routes.Add(startingLandMark.Code);

            GetAllRoutes(startingLandMark, endingLandMark, isLandmarkVisited, routes);

            return routes;
        }
        private void GetAllRoutes(Landmark startingLandMark, Landmark endingLandMark, Dictionary<string, bool> isLandmarkVisited, List<string> routes)
        {
            if (startingLandMark.Code.Equals(endingLandMark.Code))
            {
                return;
            }

            isLandmarkVisited[startingLandMark.Code] = true; //current route visited

            foreach (var landmark in _ILandmarkRepository.GetAdjecentLandMarksAsync(startingLandMark).Result)
            {
                if (!isLandmarkVisited[landmark.Code])
                {                    
                    routes.Add(landmark.Code); // store current node
                    GetAllRoutes(landmark, endingLandMark, isLandmarkVisited, routes);
                    
                    routes.Remove(landmark.Code); // remove current route
                }
            }

            isLandmarkVisited[startingLandMark.Code] = false;
        }
    }
}
