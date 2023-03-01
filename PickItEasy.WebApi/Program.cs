using PickItEasy.Application;
using PickItEasy.Application.Common.Mappings;
using PickItEasy.Application.Interfaces;
using PickItEasy.Persistence;
using PickItEasy.WebApi.Middleware;
using System.Reflection;

namespace PickItEasy.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IPickItEasyDbContext).Assembly));
            });

            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            InitializeDB(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCustomExceptionHandler();

            app.UseRouting(); // ???
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void InitializeDB(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var srviceProvider = scope.ServiceProvider;
            try
            {
                var dbContext = srviceProvider.GetRequiredService<PickItEasyDbContext>();
                DbInitializer.Initialize(dbContext);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}