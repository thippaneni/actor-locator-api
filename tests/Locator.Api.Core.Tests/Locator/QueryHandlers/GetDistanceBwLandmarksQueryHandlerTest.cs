using FluentAssertions;
using Locator.Api.Contracts.Requests;
using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Core.Locator.Queries;
using Locator.Api.Core.Locator.QueryHandlers;
using Locator.Api.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Locator.Api.Core.Locator.Interfaces;

namespace Locator.Api.Core.Tests.Locator.QueryHandlers
{
    public class GetDistanceBwLandmarksQueryHandlerTest
    {
        private readonly ILocatorService _locatorService;
        private readonly GetDistanceBwLandmarksQueryHandler _handler;
        public GetDistanceBwLandmarksQueryHandlerTest()
        {
            _locatorService = GetMockLocatorService();
            _handler = new GetDistanceBwLandmarksQueryHandler(_locatorService);
        }

        //private ILandmarkRepository GetMocLandmarkRepository()
        //{
        //    var mockRepo = new Mock<ILandmarkRepository>();

        //    mockRepo.Setup(repo=> repo.GetDistanceAsync(It.IsAny<Landmark>(), It.IsAny<Landmark>(), It.IsAny<IEnumerable<Landmark>>()).Result).Returns(12);

        //    return mockRepo.Object;
        //}

        private ILocatorService GetMockLocatorService()
        {
            var mockRepo = new Mock<ILocatorService>();

            mockRepo.Setup(repo => repo.GetDistanceAsync(It.IsAny<Landmark>(), It.IsAny<Landmark>(), It.IsAny<IEnumerable<Landmark>>()).Result).Returns(12);

            return mockRepo.Object;
        }

        [Fact]
        public void GetDistanceBwLandmarksQueryHandler_Handle_Request_Test()
        {
            var request = new GetDistanceBwLandmarksRequest() { EndingLanmarkCode = "C", StatingLanmarkCode = "A", ViaLandmarkCodes = new List<string> { "B" } };
           
            var query = new GetDistanceBwLandmarksQuery(request);
            var cancelToken = new CancellationToken();
            var result = _handler.Handle(query, cancelToken).Result;
            result.Should().Be(12);
            
        }
    }
}
