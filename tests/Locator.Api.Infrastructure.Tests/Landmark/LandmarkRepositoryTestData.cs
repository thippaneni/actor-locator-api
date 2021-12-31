using System.Collections;
using System.Collections.Generic;
using LM = Locator.Api.Domain.Entities;

namespace Locator.Api.Infrastructure.Tests.Landmark
{
    class LandmarkRepositoryTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new LM.Landmark() {Name = "A", Code = "A" },
                new List<string>() { "B", "D", "E" }
            };
            yield return new object[]
            {
                new LM.Landmark() {Name = "C", Code = "C" },
                new List<string>() { "D", "E" }
            };

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
