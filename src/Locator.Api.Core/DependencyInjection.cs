using Locator.Api.Core.Locator.Interfaces;
using Locator.Api.Core.Locator.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Locator.Api.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ILocatorService, LocatorService>();
            return services;
        }
    }
}
