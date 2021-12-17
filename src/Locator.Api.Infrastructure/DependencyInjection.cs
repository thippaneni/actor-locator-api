using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Infrastructure.Locator.Repository;
using Locator.Api.Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Locator.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddScoped<IApplicationDbContext, InMemoryDBContext>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<ILandmarkRepository, LandmarkRepository>();
            return services;
        }
    }
}
