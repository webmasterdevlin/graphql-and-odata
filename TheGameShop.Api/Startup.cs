using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheGameShop.Api.GraphQL;
using TheGameShop.Api.OData;
using TheGameShop.Api.Repositories;
using TheGameShop.GraphQL.GraphQL.Messaging;
using TheGameShop.Infrastructure.Data;

namespace TheGameShop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TheGameShopDbContext>(options => options
                .UseSqlite("Data Source=GraphqlTheGameShopDatabase.sqlite3"));

            services.AddScoped<GameRepository>();
            services.AddScoped<GameReviewRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<TheGameShopSchema>();

            services.AddSingleton<ReviewMessageService>();

            services.AddGraphQL(o =>
                {
                    o.ExposeExceptions = true;
                    o.EnableMetrics = true;
                })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader()
                .AddWebSockets();

            services.AddCors();

            services.AddControllers(mvcOptions => mvcOptions.EnableEndpointRouting = false);

            // requires using Microsoft.AspNet.OData.Extensions;
            services.AddOData();
        }

        public void Configure(IApplicationBuilder app, TheGameShopDbContext dbContext)
        {
            app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().OrderBy().Filter().Count().Expand(); // .MaxTop(10)
                routeBuilder.MapODataServiceRoute("odata", "odata", EntityDataModel.GetEdmModel());
            });

            app.UseWebSockets();

            /*GraphQL*/

            app.UseGraphQLWebSockets<TheGameShopSchema>("/graphql");

            app.UseGraphQL<TheGameShopSchema>();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            dbContext.Seed(); // Database seeding
        }
    }
}