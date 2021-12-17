using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LM = Locator.Api.Domain.Entities;

namespace Locator.Api.Infrastructure.Tests.Landmark
{
    class LandmarkRepositoryTestData2 : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
           {
                new LM.Landmark() {Name = "A", Code = "A" },
                new LM.Landmark() {Name = "C", Code = "C" },
                new List<LM.Landmark>() { new LM.Landmark() { Name = "B", Code = "B" } },
                12
           };
            yield return new object[]
           {
                new LM.Landmark() {Name = "A", Code = "A" },
                new LM.Landmark() {Name = "D", Code = "D" },
                new List<LM.Landmark>() { new LM.Landmark() { Name = "E", Code = "E" } },
                null
           };
            yield return new object[]
           {
                new LM.Landmark() {Name = "A", Code = "A" },
                new LM.Landmark() {Name = "D", Code = "D" },
                new List<LM.Landmark>() { 
                    new LM.Landmark() { Name = "E", Code = "E" },
                    new LM.Landmark() { Name = "B", Code = "B" },
                    new LM.Landmark() { Name = "C", Code = "C" }
                },
                17
           };

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
