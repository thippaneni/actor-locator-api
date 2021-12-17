using Locator.Api.Core.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using FluentValidation;

namespace Locator.Api.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(ILandmarkRepository));
            //services.AddValidatorsFromAssembly(typeof(IValidator).Assembly);
            return services;
        }
    }
}
