using LM = Locator.Api.Domain.Entities;
using Xunit;
using System.Collections.Generic;
using Locator.Api.Infrastructure.Locator.Repository;
using Locator.Api.Infrastructure.Persistance;
using FluentAssertions;
using System.Linq;

namespace Locator.Api.Infrastructure.Tests.Landmark
{
    public class LandmarkRepositoryTest
    {
        [Theory]
        [ClassData(typeof(LandmarkRepositoryTestData))]
        public void GetAdjecentLandMarksAsync_Test(LM.Landmark landmark, List<string> adjLandmrks)
        {
            var context = new InMemoryDBContext();
            var lmRepo = new LandmarkRepository(context);

            var result = lmRepo.GetAdjecentLandMarksAsync(landmark).Result;
            result.Should().NotBeNull();
            result.Count().Should().Be(adjLandmrks.Count);
            for (int i = 0; i < result.Count(); i++)
            {
                result.ToList()[i].Code.Should().Be(adjLandmrks[i]);
            }
        }

        [Theory]
        [ClassData(typeof(LandmarkRepositoryTestData))]
        public void GetDistanceAsync_Test(LM.Landmark landmark, List<string> adjLandmrks)
        {
            var context = new InMemoryDBContext();
            var lmRepo = new LandmarkRepository(context);

            var result = lmRepo.GetAdjecentLandMarksAsync(landmark).Result;
            result.Should().NotBeNull();
            result.Count().Should().Be(adjLandmrks.Count);
            for (int i = 0; i < result.Count(); i++)
            {
                result.ToList()[i].Code.Should().Be(adjLandmrks[i]);
            }
        }
    }
}
