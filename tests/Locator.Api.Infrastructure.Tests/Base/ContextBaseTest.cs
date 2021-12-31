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
    public static class ContextBaseTest
    {
        public static InMemoryDBContext context = null;
        static ContextBaseTest()
        {
            var options = new DbContextOptionsBuilder<InMemoryDBContext>();
            options.UseInMemoryDatabase("test");
            context = new InMemoryDBContext(options.Options);
            ApplicationDBContextSeedData.SeedSampleDataAsync(context).ConfigureAwait(false);
        }        
    }
}
