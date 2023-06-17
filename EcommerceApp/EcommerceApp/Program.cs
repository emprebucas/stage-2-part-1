using System.Reflection;
using EcommerceApp.Data;
using EcommerceApp.Interfaces;
using EcommerceApp.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using AutoMapper;

namespace EcommerceApp
{
    /// <summary>
    /// The Program class serves as the entry point for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The `Main` method is the starting point of the program. 
        /// It calls the `CreateHostBuilder` method to build and run the web application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// The `CreateHostBuilder` method sets up the application's configuration and web host.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // configures the application to use a JSON configuration file named "appsettings.json"
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                // configures the web host and sets up the application's services
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // configuration of services with the application's dependency injection container, allowing them to be used throughout the application
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        // adds controllers and endpoint routing
                        services.AddControllers();
                        services.AddEndpointsApiExplorer();

                        // adds Swagger for generating API documentation
                        services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce API", Version = "v1" });

                            // registers the `AddCustomHeaderParameter` class as an operation filter for Swagger
                            // ensures that the custom header parameter is included in the generated Swagger documentation for all API operations
                            c.OperationFilter<AddCustomHeaderParameter>();

                            // set the XML comments file path for generating accurate Swagger documentation
                            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                            c.IncludeXmlComments(xmlPath);
                        });

                        // sets up a MySQL database using the connection string retrieved from the "ECommerceDb" key in the configuration

                        // retrieves the configuration object
                        var configuration = hostContext.Configuration;
                        // retrieves the connection string from  the application's configuration (appsettings.json)
                        var connectionString = configuration.GetConnectionString("ECommerceDb");

                        // registers the `ECommerceDbContext` as a service with the dependency injection container
                        // allows the application to use `ECommerceDbContext` for interacting with the database
                       services.AddDbContext<ECommerceDbContext>(options =>
                        {
                            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 33)), mysqlOptions =>
                            {
                                // enables automatic retry on database failures.
                                // if a database operation fails, Entity Framework Core will automatically retry the operation a certain number of times before throwing an exception
                                mysqlOptions.EnableRetryOnFailure();
                            }).EnableServiceProviderCaching(false); // disables the caching of the service provider for the database context
                        });

                        // registers repositories and sets up dependency injection for repositories
                        services.AddScoped<IOrderRepository, OrderRepository>();
                        services.AddScoped<ICartItemRepository, CartItemRepository>();
                        services.AddScoped<IUserRepository, UserRepository>();

                        // adds MediatR for implementing the Mediator pattern for handling commands and queries
                        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
                        // called with a configuration lambda expression that registers the services from the assembly where the `Program` class is defined which allows MediatR to automatically discover and register the command and query handlers defined in that assembly

                        //adds AutoMapper for object mapping
                        services.AddAutoMapper(typeof(Mapping));
                        // called with the `typeof(Mapping)` parameter, which specifies the assembly containing the mapping profiles which allows AutoMapper to discover and configure the mapping profiles defined in that assembly

                        // adds authentication and authorization
                        // uses a custom authentication scheme named "BasicAuthentication" with a corresponding handler (BasicAuthenticationHandler.cs)
                        services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
                        services.AddAuthorization();

                        // configures the HTTP context accessor and a custom HttpContextHelper (HttpContextHelper.cs)
                        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                        services.AddSingleton<HttpContextHelper>();

                    })
                    // configures the application's request processing pipeline
                    .Configure((hostContext, app) =>
                    {
                        // if the application is running in the development environment, it enables the developer exception page
                        if (hostContext.HostingEnvironment.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }

                        // sets up Swagger and Swagger UI middleware
                        app.UseSwagger();
                        app.UseSwaggerUI(c =>
                        {
                            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce API V1");
                        });

                        // enables routing, authentication, and authorization
                        app.UseRouting();
                        app.UseAuthentication();
                        app.UseAuthorization();

                        // maps the API controllers as endpoints
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });

                    });
                });
    }
}