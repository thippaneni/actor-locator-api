using Locator.Api.Infrastructure.Persistance;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace Locator.Api.Infrastructure.Tests
{
    public class InMemoryDBContextTest
    {
        [Fact]
        public void Routes_Test_Routes_Should_Be_9()
        {
            var context = new InMemoryDBContext();
            var routes = context.Routes;
            routes.Should().NotBeNull();
            routes.Count().Should().Be(9);
        }

        [Fact]
        public void LandMarks_Test_LandMarks_Should_Be_5()
        {
            var context = new InMemoryDBContext();
            var landmarks = context.LandMarks;
            landmarks.Should().NotBeNull();
            landmarks.Count().Should().Be(5);
        }
    }
}
