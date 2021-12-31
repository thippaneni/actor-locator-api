using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Core.Locator.Interfaces;
using Locator.Api.Core.Locator.Models;
using Locator.Api.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.Services
{
    public class LocatorService : ILocatorService
    {        
        private readonly ILandmarkRepository _landmarkRepository;
        private readonly IRouteRepository _routeRepository;
        public LocatorService(ILandmarkRepository landmarkRepository, IRouteRepository routeRepository)
        {
            _landmarkRepository = landmarkRepository;
            _routeRepository = routeRepository;
        }
        public async Task<IEnumerable<Landmark>> GetAllLandMarksAsync()
        {
            return await _landmarkRepository.GetAllLandMarksAsync();
        }

        public async Task<IEnumerable<RouteModel>> GetAllRoutesAsync()
        {
            var result = new List<RouteModel>();
            var routes = await _routeRepository.GetAllRoutesAsync();
            routes.ToList().ForEach(route => {
                var startLm = _landmarkRepository.GetLandMarkByCodeAsync(route.StartLandmarkCode);
                var endLm = _landmarkRepository.GetLandMarkByCodeAsync(route.EndLandmarkCode);
                result.Add(new RouteModel()
                {
                    RouteId = route.Id,
                    StartLandmark = ConvertToModel(startLm),
                    EndLandmark = ConvertToModel(endLm),
                    Distance = route.Distance,
                    RouteCode = route.RouteCode
                });
            });
            return result;
        }

        public async Task<int?> GetDistanceAsync(Landmark startingLandMark, Landmark endingLandMark, IEnumerable<Landmark> viaLandMarks)
        {
            var codes = new List<string>();
            var tempLM = startingLandMark;
            viaLandMarks.ToList().ForEach(vlm =>
            {
                codes.Add(tempLM.Code + vlm.Code);
                tempLM.Code = vlm.Code;
                tempLM.Name = vlm.Name;
            });
            codes.Add(tempLM.Code + endingLandMark.Code);

            int? distance = 0;
            bool rootFound = false;
            var routes = await _routeRepository.GetAllRoutesAsync();

            codes.ForEach(code =>
            {
                rootFound = false;
                foreach (var route in routes)
                {
                    if (route.RouteCode == code)
                    {
                        distance += route.Distance;
                        rootFound = true;
                    }
                }
            });

            if (!rootFound)
            {
                distance = null;
            }

            return distance;
        }

        public async Task<RoutePath> GetNoOfRoutesAsync(Landmark startingLandMark, Landmark endingLandMark, int? maxStops)
        {
            var routes = await GetRoutesAsync(startingLandMark, endingLandMark);
            var routePath = new RoutePath();
            if (routes != null && routes.Any())
            {
                if (!maxStops.HasValue)
                {
                    routePath.NoOfRoutes = routes.Count();
                    routePath.Routes = routes;
                    return routePath;
                }
                var paths = new List<string>();
                routes.ToList().ForEach(route =>
                {
                    if (route.Split("->").Length <= maxStops + 2) // +2 is for including starting and ending landmarks
                    {
                        paths.Add(route);
                    }
                });
                routePath.NoOfRoutes = paths.Count();
                routePath.Routes = paths;
            }
            return await Task.FromResult(routePath);
        }

        private void GetAllRoutes(Landmark startingLandMark, Landmark endingLandMark, Dictionary<string, bool> isLandmarkVisited, List<string> routes, List<string> result)
        {
            if (startingLandMark.Code.Equals(endingLandMark.Code))
            {
                result.Add(string.Join("->", routes));
                return;
            }

            isLandmarkVisited[startingLandMark.Code] = true; //current route visited

            foreach (var landmark in _landmarkRepository.GetAdjecentLandMarksAsync(startingLandMark))
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

        public async Task<IEnumerable<string>> GetRoutesAsync(Landmark startingLandMark, Landmark endingLandMark)
        {
            var landmarks = await _landmarkRepository.GetAllLandMarksAsync();
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

        private LandmarkModel ConvertToModel(Landmark landmark)
        {
            return new LandmarkModel() { Code = landmark.Code, Name = landmark.Name, LandmarkId = landmark.Id };
        }
        private Landmark ConvertToEntity(LandmarkModel model)
        {
            return new Landmark() { Code = model.Code, Name = model.Name, Id = model.LandmarkId };
        }
    }
}
