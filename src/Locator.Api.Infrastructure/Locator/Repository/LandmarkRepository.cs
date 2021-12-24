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
    public class LandmarkRepository : ILandmarkRepository
    {
        private readonly IApplicationDbContext _context;

        public LandmarkRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Landmark>> GetAllLandMarksAsync()
        {
            return await Task.Run(() => _context.LandMarks.ToList());
        }

        public Task<int?> GetDistanceAsync(Landmark startingLandMark, Landmark endingLandMark, IEnumerable<Landmark> viaLandMarks)
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
            var routes = _context.Routes.ToList();

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
            
            return Task.FromResult(distance);

        }
        public async Task<IEnumerable<Landmark>> GetAdjecentLandMarksAsync(Landmark landmark)
        {
            var routes = _context.Routes.ToList();
            var startinglandmarks = routes.Where(d => d.StartLandmark.Code == landmark.Code);
            var adjLandmarks = new List<Landmark>();
            startinglandmarks.ToList().ForEach(lm => adjLandmarks.Add(lm.EndLandmark));
            return await Task.FromResult(adjLandmarks);
        }
    }
}
