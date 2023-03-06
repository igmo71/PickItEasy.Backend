using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using PickItEasy.Application;
using PickItEasy.Application.Common.Mappings;
using PickItEasy.Application.Interfaces;
using PickItEasy.Persistence;
using PickItEasy.WebApi.Middleware;
using PickItEasy.WebApi.Services;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace PickItEasy.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //var logger = new LoggerConfiguration()
            //    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
            //    .WriteTo.File("Log/PickItEasyWebApi-.log", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

            //builder.Logging.ClearProviders();
            //builder.Logging.AddSerilog(logger);

            builder.Host.UseSerilog((ctx, lc) => lc
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                .WriteTo.File("Log/PickItEasyWebApi-.log", rollingInterval: RollingInterval.Day));

            // Add services to the container.

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IPickItEasyDbContext).Assembly));
            });

            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer("Bearer", options =>
                {
                    //options.Authority = "https://localhost:32770"; // in Docker Identity server run
                    //options.Authority = "https://localhost:7109"; // in https Identity server run 
                    options.Authority = "https://localhost:44323/"; // in IIS express Identity server run
                    options.Audience = "PickItEasyWebApi";
                    options.RequireHttpsMetadata = false;
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApiVersioning();

            builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            InitializeDB(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var apiVersionDescriptions in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    {
                        config.SwaggerEndpoint(
                            $"/swagger/{apiVersionDescriptions.GroupName}/swagger.json",
                            apiVersionDescriptions.GroupName.ToUpperInvariant());
                        //config.RoutePrefix = string.Empty;
                    }
                });
            }

             //app.UseSerilogRequestLogging(); // TODO: ???

            app.UseCustomExceptionHandler();

            app.UseRouting(); // ???
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseApiVersioning();

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
                Log.Fatal(ex, "Error while app initialization");
                throw;
            }
        }
    }
}