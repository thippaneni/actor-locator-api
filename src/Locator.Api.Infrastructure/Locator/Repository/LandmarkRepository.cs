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
        public IEnumerable<Landmark> GetAllLandMarksAsync()
        {
            return _context.LandMarks.ToList();
        }
        public Landmark GetLandMarkByCodeAsync(string code)
        {
            return _context.LandMarks.ToList().SingleOrDefault(lm => lm.Code == code);
        }
        public IEnumerable<Landmark> GetAdjecentLandMarksAsync(Landmark landmark)
        {
            var routes = _context.Routes.ToList();
            var startinglandmarks = routes.Where(d => d.StartLandmarkCode == landmark.Code).ToList();
            var adjLandmarks = new List<Landmark>();
            startinglandmarks.ForEach(lmCode => {
                var landmark = GetLandMarkByCodeAsync(lmCode.EndLandmarkCode);
                adjLandmarks.Add(landmark);
            });
           
            return adjLandmarks;
        }
    }
}
