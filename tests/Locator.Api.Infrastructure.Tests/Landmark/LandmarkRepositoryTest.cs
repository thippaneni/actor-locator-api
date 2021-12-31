using LM = Locator.Api.Domain.Entities;
using Xunit;
using System.Collections.Generic;
using Locator.Api.Infrastructure.Locator.Repository;
using Locator.Api.Infrastructure.Persistance;
using FluentAssertions;
using System.Linq;
using System;
using Locator.Api.Infrastructure.Tests.Base;

namespace Locator.Api.Infrastructure.Tests.Landmark
{
    public class LandmarkRepositoryTest
    {
        private InMemoryDBContext _context;
        private LandmarkRepository _lmRepo;
        public LandmarkRepositoryTest()
        {
            _context = ContextBaseTest.context;
            _lmRepo = new LandmarkRepository(_context);
        }
        
        [Theory]
        [ClassData(typeof(LandmarkRepositoryTestData))]
        public void GetAdjecentLandMarksAsync_Test(LM.Landmark landmark, List<string> adjLandmrks)
        {
            var result = _lmRepo.GetAdjecentLandMarksAsync(landmark);
            result.Should().NotBeNull();
            result.Count().Should().Be(adjLandmrks.Count);
            for (int i = 0; i < result.Count(); i++)
            {
                result.ToList()[i].Code.Should().Be(adjLandmrks[i]);
            }
        }

        [Fact]
        public void GetLandMarkByCodeAsync_Test()
        {
            var result = _lmRepo.GetLandMarkByCodeAsync("A");
            result.Code.Should().Be("A");
        }
    }
}
