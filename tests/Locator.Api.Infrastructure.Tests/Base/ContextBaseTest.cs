using Locator.Api.Infrastructure.Persistance;
using Locator.Api.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Infrastructure.Tests.Base
{
    public sealed class ContextBaseTest
    {
        private static InMemoryDBContext _testContext = null;
        private static readonly object lockThread = new object();

        private ContextBaseTest()
        {
            
        }
        public static InMemoryDBContext TestContext
        {
            get
            {
                lock (lockThread)
                {
                    if (_testContext == null)
                    {
                        var options = new DbContextOptionsBuilder<InMemoryDBContext>();
                        options.UseInMemoryDatabase("test");
                        _testContext = new InMemoryDBContext(options.Options);
                        ApplicationDBContextSeedData.SeedSampleDataAsync(_testContext).ConfigureAwait(false);
                    }
                }
                return _testContext;
            }
        }
    }
}
