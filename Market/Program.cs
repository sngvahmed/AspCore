using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Market.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Market
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            IWebHost _ = CreateWebHostBuilder(args).Build(); // host

            using (var scope = _.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    var context = service.GetRequiredService<MarketDbContext>();
                    DBIntializer.Seed(context);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }


            _.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
