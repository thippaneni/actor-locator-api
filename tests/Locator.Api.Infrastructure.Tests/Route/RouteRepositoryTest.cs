using FluentAssertions;
using Locator.Api.Core.Locator.Models;
using Locator.Api.Infrastructure.Locator.Repository;
using Locator.Api.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using LM = Locator.Api.Domain.Entities;

namespace Locator.Api.Infrastructure.Tests.Route
{
    public class RouteRepositoryTest
    {
        private InMemoryDBContext _context;
        private LandmarkRepository _lmRepo;
        private RouteRepository _routesRepo;
        public RouteRepositoryTest()
        {
            _context = new InMemoryDBContext(null);
            _lmRepo = new LandmarkRepository(_context);
            _routesRepo = new RouteRepository(_context, _lmRepo);
        }
        [Fact]
        public void GetAllRoutes_Test_AllRoutes_Should_Be_9()
        {
            var routes = _routesRepo.GetAllRoutesAsync();
            routes.Should().NotBeNull();
            routes.Count().Should().Be(9);
        }
        [Theory]
        [ClassData(typeof(RouteRepositoryTestData))]
        public void GetRoutesAsync_Test(LM.Landmark startLandmark, LM.Landmark endLandmark, List<string> routes)
        {            
            var result = _routesRepo.GetRoutesAsync(startLandmark, endLandmark);
            result.Should().NotBeNull();
            for (int i = 0; i < routes.Count(); i++)
            {
                result.ToList()[i].Should().Be(routes[i]);
            }
        }

        //[Theory]
        //[ClassData(typeof(RouteRepositoryTestData2))]
        //public void GetNoOfRoutesAsync_Test(LM.Landmark startLandmark, LM.Landmark endLandmark, int? maxStops, RoutePath expected)
        //{            
        //    var result = _routesRepo.GetNoOfRoutesAsync(startLandmark, endLandmark, maxStops).Result;
        //    result.NoOfRoutes.Should().Be(expected.NoOfRoutes);
        //}
    }
}
