using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using CarWorkshop.Infrastructure.Repositories;
using CarWorkshop.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructures(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarWorkshopDbContext>(option => option.UseSqlServer(
                configuration.GetConnectionString("CarWorkshop")));

            services.AddScoped<CarWorkschopSeeder>();

            services.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();

        }
    }
}
