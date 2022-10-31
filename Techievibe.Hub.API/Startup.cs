using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using SumoLogic.Logging.AspNetCore;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Techievibe.Hub.API.Middlewares;
using Techievibe.Hub.Common.Exceptions;
using Techievibe.Hub.DataAccess.Dapper.ServiceRegistration;
using Techievibe.Hub.Logging.Core;
using Techievibe.Hub.Logging.ServiceRegistration;
using Techievibe.Hub.Services.Common.Interfaces;
using Techievibe.Hub.Services.Common.Managers;
using Techievibe.Hub.Services.Common.Mappers;

namespace Techievibe.Hub.API
{
    /// <summary>
    /// Runs during startup of the application, responsible for injecting dependent middleware services and essential services to run the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This objects allows you to read environment variables and settings during runtime.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// A constructor for StartUp that instantiates Configuration object.
        /// </summary>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures middleware services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                //To be able to show response examples
                c.ExampleFilters();
                //To be able to use SwashBuckle Annotations
                c.EnableAnnotations();
                //c.SwaggerDoc("V1", new OpenApiInfo { Title = "Techievibe.Hub.API", Version = "V1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                c.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                        return new[] { api.GroupName };

                    if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");

                });

                c.DocInclusionPredicate((name, api) => true);
            });

            //services.AddSwaggerGen();

            //To automatically search all the example from assembly.
            services.AddSwaggerExamplesFromAssemblyOf<Startup>();

            services.AddHealthChecks();

            services.AddHttpContextAccessor();

            //Add all middleware service dependencies
            LoggerRegistration.AddSumoLogicLoggerForWeb(services, this.Configuration);
            DataAccessRegistration.AddSqlServerDependenciesForWeb(services, this.Configuration);
            services.AddSingleton<IUserManager, UserManager>();
            //services.AddAutoMapper(cfg => {
            //    cfg.AddProfile(typeof(UserMapper));
            //});


        }

        /// <summary>
        /// configures middleware services for containerized applications
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureContainer(IServiceCollection services)
        { 
            
        }

        /// <summary>
        /// configures the usage of injected middleware services.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            var loggerOptions = LoggerRegistration.GetSumoLogicLoggerOptions();
            loggerFactory.AddSumoLogic(loggerOptions);

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseMiddleware<TracingMiddleware>();
            //app.ConfigureExceptionHandler(app.ApplicationServices.GetRequiredService<ISumoLogger>());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Techievibe.Hub.API");
                c.RoutePrefix = "api/v1/swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
