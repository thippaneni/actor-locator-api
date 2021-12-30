using Locator.Api.Core.Common.Interfaces;
using Locator.Api.Infrastructure.Locator.Repository;
using Locator.Api.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locator.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var dbType = configuration.GetValue<string>("DatabaseType");
            var connectionString = string.Empty;
            switch (dbType)
            {
                case "PostgresSQL":
                    connectionString = configuration.GetConnectionString("PostgreSqlDBConnection");
                    services.AddDbContext<PostgreSqlDBContext>(options => options.UseNpgsql(connectionString));
                    services.AddScoped<IApplicationDbContext>(provider => provider.GetService<PostgreSqlDBContext>());
                    break;

                case "MySQL":
                    connectionString = configuration.GetConnectionString("MySqlDBConnection");
                    services.AddDbContext<MySqlDBContext>(options => options.UseMySQL(connectionString));
                    services.AddScoped<IApplicationDbContext>(provider => provider.GetService<MySqlDBContext>());
                    break;

                default:
                    services.AddDbContext<InMemoryDBContext>(options => options.UseInMemoryDatabase("InMemoryLocatorDb"));
                    services.AddScoped<IApplicationDbContext>(provider => provider.GetService<InMemoryDBContext>());
                    break;
            }            
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<ILandmarkRepository, LandmarkRepository>();
            return services;
        }       
    }
}
