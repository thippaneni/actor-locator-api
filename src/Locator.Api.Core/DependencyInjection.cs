using Locator.Api.Core.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using FluentValidation;
using System.Reflection;
using Locator.Api.Core.Locator.Interfaces;
using Locator.Api.Core.Locator.Services;

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
