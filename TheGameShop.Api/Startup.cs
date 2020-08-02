using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using TheGameShop.Api.Data;
using TheGameShop.Api.Data.Entities;
using TheGameShop.Api.GraphQL;
using TheGameShop.Api.Repositories;
using TheGameShop.GraphQL.GraphQL.Messaging;

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

            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped).AddUserContextBuilder(httpContext => httpContext.User)
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
                routeBuilder.Select().OrderBy().Filter().Count().OrderBy().Expand(); // .MaxTop(10)
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });

            app.UseWebSockets();

            /*GraphQL*/

            app.UseGraphQLWebSockets<TheGameShopSchema>("/graphql");

            app.UseGraphQL<TheGameShopSchema>();

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            dbContext.Seed(); // Database seeding
        }

        /* EDM (Entity Data Model)*/

        private static IEdmModel GetEdmModel()
        {
            var edmBuilder = new ODataConventionModelBuilder();
            edmBuilder.EntitySet<Game>("Games");

            return edmBuilder.GetEdmModel();
        }
    }
}