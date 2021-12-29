using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Core.Locator.Interfaces;
using Locator.Api.Core.Locator.Models;
using Locator.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var result = new List<LandmarkModel>();
            var landmarks = _landmarkRepository.GetAllLandMarksAsync();            
            return await Task.FromResult(landmarks);
        }

        public async Task<IEnumerable<RouteModel>> GetAllRoutesAsync()
        {
            var result = new List<RouteModel>();
            var routes = _routeRepository.GetAllRoutesAsync();
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
            return await Task.FromResult(result);
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
            var routes = _routeRepository.GetAllRoutesAsync();

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

            return await Task.FromResult(distance);
        }

        public async Task<RoutePath> GetNoOfRoutesAsync(Landmark startingLandMark, Landmark endingLandMark, int? maxStops)
        {
            var routes = _routeRepository.GetRoutesAsync(startingLandMark, endingLandMark);
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
