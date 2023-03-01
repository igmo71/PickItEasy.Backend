using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickItEasy.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PickItEasy.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];


            //services.AddDbContext<PickItEasyDbContext>(options =>
            //{
            //    options.UseSqlite(connectionString);
            //});
            //services.AddScoped<IPickItEasyDbContext>(provider =>
            //    provider.GetRequiredService<PickItEasyDbContext>());

            services.AddDbContext<IPickItEasyDbContext, PickItEasyDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            return services;
        }
    }
}
