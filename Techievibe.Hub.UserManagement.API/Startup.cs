using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SumoLogic.Logging.AspNetCore;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Techievibe.Hub.Services.Common.Interfaces;
using Techievibe.Hub.Services.Common.Managers;
using Techievibe.Hub.Services.Common.Mappers;
using Techievibe.Hub.Services.ServiceRegistration;

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Techievibe.Hub.UserManagement.API", Version = "1.0.0" });
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

            CommonRegistration.AddAllServicesWithDependenciesForWeb(services, Configuration);

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


            var loggerOptions = CommonRegistration.GetSumoLogicLoggerOptions();
            loggerFactory.AddSumoLogic(loggerOptions);

            CommonRegistration.AddAllMiddlewaresWithDependenciesForWeb(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            // Configure the HTTP request pipeline.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/user-mgmt/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/user-mgmt/swagger/v1/swagger.json", "Techievibe.Hub.UserManagement.API");
                c.RoutePrefix = "api/user-mgmt/swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
