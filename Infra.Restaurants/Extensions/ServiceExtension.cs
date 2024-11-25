using Core.Restaurants.Domain.Service;
using Infra.Restaurants.Repositories;
using Infra.Restaurants.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Restaurants.Extensions
{
    public static class ServiceExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("default")).EnableSensitiveDataLogging());
            services.AddScoped<IRestaurantSeeders,RestaurantSeeders>();
            services.AddTransient<IResturantRepository, RestaurantRepository>();
        }
    }
}
