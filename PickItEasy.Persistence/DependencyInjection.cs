using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application.Interfaces;

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
