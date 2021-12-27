using LM = Locator.Api.Domain.Entities;
using Xunit;
using System.Collections.Generic;
using Locator.Api.Infrastructure.Locator.Repository;
using Locator.Api.Infrastructure.Persistance;
using FluentAssertions;
using System.Linq;
using System;

namespace Locator.Api.Infrastructure.Tests.Landmark
{
    public class LandmarkRepositoryTest
    {
        private InMemoryDBContext _context;
        private LandmarkRepository _lmRepo;
        public LandmarkRepositoryTest()
        {
            _context = new InMemoryDBContext();
            _lmRepo = new LandmarkRepository(_context);
        }
        [Fact]
        public void GetAllLandMarks_Test_AllLandMarks_Should_Be_5()
        {
            var lms = _lmRepo.GetAllLandMarksAsync().Result;
            lms.Should().NotBeNull();
            lms.Count().Should().Be(5);
        }

        [Theory]
        [ClassData(typeof(LandmarkRepositoryTestData))]
        public void GetAdjecentLandMarksAsync_Test(LM.Landmark landmark, List<string> adjLandmrks)
        {
            var result = _lmRepo.GetAdjecentLandMarksAsync(landmark).Result;
            result.Should().NotBeNull();
            result.Count().Should().Be(adjLandmrks.Count);
            for (int i = 0; i < result.Count(); i++)
            {
                result.ToList()[i].Code.Should().Be(adjLandmrks[i]);
            }
        }

        [Theory]
        [ClassData(typeof(LandmarkRepositoryTestData2))]
        public void GetDistanceAsync_Test(LM.Landmark startingLandMark, LM.Landmark endingLandMark, IEnumerable<LM.Landmark> viaLandMarks, int? distance)
        {

            var result = _lmRepo.GetDistanceAsync(startingLandMark, endingLandMark, viaLandMarks).Result;           
            result.Should().Be(distance);
        }
    }
}
