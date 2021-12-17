using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LM = Locator.Api.Domain.Entities;

namespace Locator.Api.Infrastructure.Tests.Route
{
    class RouteRepositoryTestData2 : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new LM.Landmark() {Name = "A", Code = "A" },
                new LM.Landmark() {Name = "C", Code = "C" },
                2,
                2
            };
            yield return new object[]
            {
                new LM.Landmark() {Name = "A", Code = "A" },
                new LM.Landmark() {Name = "C", Code = "C" },
                null,
                3
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
