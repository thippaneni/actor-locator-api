using FluentAssertions;
using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Core.Locator.Interfaces;
using Locator.Api.Core.Locator.Services;
using Locator.Api.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Locator.Api.Core.Tests.Locator.Services
{
    public class LocatorServiceTest
    {
        private readonly ILandmarkRepository _landmarkRepo;
        private readonly IRouteRepository _routeRepo;
        private readonly ILocatorService _locatorService;

        public LocatorServiceTest()
        {
            _landmarkRepo = MockLandmarkRepo();
            _routeRepo = MockRouteRepo();
            _locatorService = new LocatorService(_landmarkRepo, _routeRepo);
        }

        private ILandmarkRepository MockLandmarkRepo()
        {
            var lmRepo = new Mock<ILandmarkRepository>();
            lmRepo.Setup(repo => repo.GetAllLandMarksAsync().Result).Returns(GetLandmarks());
            lmRepo.Setup(repo => repo.GetLandMarkByCodeAsync(It.IsAny<string>())).Returns(GetLandmarks().First());

            return lmRepo.Object;
        }

        private IRouteRepository MockRouteRepo()
        {
            var rtRepo = new Mock<IRouteRepository>();
            rtRepo.Setup(repo => repo.GetAllRoutesAsync().Result).Returns(GetRoutes());
            return rtRepo.Object;
        }

        private IEnumerable<Landmark> GetLandmarks()
        {
            return new List<Landmark>() {
                new Landmark() {Code = "A", Name = "A"},
                new Landmark() {Code = "B", Name = "B"},
                new Landmark() {Code = "C", Name = "C"}
            };
        }

        private IEnumerable<Route> GetRoutes()
        {
            return new List<Route>() {
                new Route() {StartLandmarkCode = "A", EndLandmarkCode = "B", RouteCode ="AB", Distance = 3},
                new Route() {StartLandmarkCode = "B", EndLandmarkCode = "C", RouteCode ="BC", Distance = 2},
            };
        }

        [Fact]
        public async void GetAllLandMarksAsync_Test()
        {
            var lms = await _locatorService.GetAllLandMarksAsync();
            lms.Count().Should().Be(3);
            lms.First().Code.Should().Be("A");
        }

        [Fact]
        public async void GetAllRoutesAsync_Test()
        {
            var routes = await _locatorService.GetAllRoutesAsync();
            routes.Count().Should().Be(2);
            routes.First().Distance.Should().Be(3);
            routes.First().RouteCode.Should().Be("AB");
        }

        [Fact]
        public async void GetDistanceAsync_Test_Returns_Distance()
        {
            var lms = GetLandmarks().ToList();            
            var distance = await _locatorService.GetDistanceAsync(lms[0], lms[2], new List<Landmark> { lms[1] });

            distance.Should().NotBeNull();
            distance.Should().Be(5);
        }

        [Fact]
        public async void GetDistanceAsync_Test_Returns_Null()
        {
            var lms = GetLandmarks().ToList();
            var distance = await _locatorService.GetDistanceAsync(lms[2], lms[0], new List<Landmark> { lms[1] });

            distance.Should().BeNull();            
        }
    }
}
