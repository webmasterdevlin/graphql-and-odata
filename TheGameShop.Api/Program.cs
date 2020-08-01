using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TheGameShop.GraphQL;

namespace TheGameShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .ConfigureKestrel((context, options) => { options.AllowSynchronousIO = true; });
                });
    }
}