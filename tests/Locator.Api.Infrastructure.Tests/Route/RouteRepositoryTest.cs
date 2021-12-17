using FluentAssertions;
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
        [Fact]
        public void GetAllRoutes_Test_AllRoutes_Should_Be_9()
        {
            var context = new InMemoryDBContext();
            var lmRepo = new LandmarkRepository(context);
            var routesRepo = new RouteRepository(context, lmRepo);

            var routes = routesRepo.GetAllRoutesAsync().Result;
            routes.Should().NotBeNull();
            routes.Count().Should().Be(9);
        }
        [Theory]
        [ClassData(typeof(RouteRepositoryTestData))]
        public void GetRoutesAsync_Test(LM.Landmark startLandmark, LM.Landmark endLandmark, List<string> routes)
        {
            var context = new InMemoryDBContext();
            var lmRepo = new LandmarkRepository(context);
            var routesRepo = new RouteRepository(context, lmRepo);

            var result = routesRepo.GetRoutesAsync(startLandmark, endLandmark).Result;
            result.Should().NotBeNull();
            for (int i = 0; i < routes.Count(); i++)
            {
                result.ToList()[i].Should().Be(routes[i]);
            }
        }

        [Theory]
        [ClassData(typeof(RouteRepositoryTestData2))]
        public void GetNoOfRoutesAsync_Test(LM.Landmark startLandmark, LM.Landmark endLandmark, int? maxStops, int expected)
        {
            var context = new InMemoryDBContext();
            var lmRepo = new LandmarkRepository(context);
            var routesRepo = new RouteRepository(context, lmRepo);

            var result = routesRepo.GetNoOfRoutesAsync(startLandmark, endLandmark, maxStops).Result;
            result.Should().Be(expected);
        }
    }
}
