﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LM = Locator.Api.Domain.Entities;

namespace Locator.Api.Infrastructure.Tests.Route
{
    class RouteRepositoryTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new LM.Landmark() {Name = "A", Code = "A" },
                new LM.Landmark() {Name = "C", Code = "C" },
                new List<string>() { "A->B->C", "A->D->E->B->C", "A->E->B->C" }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
