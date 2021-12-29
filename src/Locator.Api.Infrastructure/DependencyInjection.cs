using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Infrastructure.Locator.Repository;
using Locator.Api.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Locator.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryDBContext>(opt => opt.UseInMemoryDatabase("Locator"));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<InMemoryDBContext>());
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<ILandmarkRepository, LandmarkRepository>();
            return services;
        }       
    }
}
