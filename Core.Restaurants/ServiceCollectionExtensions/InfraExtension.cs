using Core.Restaurants.Restaurants;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Restaurants.ServiceExtensions
{
    public static class InfraExtension
    {
        public static void AddCore(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(InfraExtension).Assembly);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(InfraExtension).Assembly));

            services.AddValidatorsFromAssembly(typeof(InfraExtension).Assembly).AddFluentValidationAutoValidation();
        }
    }
}
