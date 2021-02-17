using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OcelotAPIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        //public static void Main(string[] args)
        //{
        //    new WebHostBuilder()
        //    .UseContentRoot(Directory.GetCurrentDirectory())
        //    .ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        config
        //            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        //            .AddJsonFile("appsettings.json", true, true)
        //            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
        //            .AddJsonFile("ocelot.json")
        //            .AddEnvironmentVariables();
        //    })
        //    .ConfigureServices(s => {
        //        s.AddOcelot();
        //    })
        //    .ConfigureLogging((hostingContext, logging) =>
        //    {
        //           //add your logging
        //       })
        //    .UseIIS()
        //    .Configure(app =>
        //    {
        //        app.UseOcelot().Wait();
        //    })
        //    .Build()
        //    .Run();
        //}
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile($"ocelot.json").AddEnvironmentVariables();
                }).ConfigureLogging((hostingContext, logging) =>
                {
                    Console.WriteLine(logging);
                    //add your logging
                });
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        // Host.CreateDefaultBuilder(args)
        //     .ConfigureAppConfiguration((hostingContext, config) =>
        //     {
        //         config
        //             .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        //             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //             .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
        //             .AddJsonFile($"ocelot.json")
        //             .AddEnvironmentVariables();
        //     })
        //     .ConfigureWebHostDefaults(webBuilder =>
        //     {
        //         webBuilder.UseStartup<Startup>();
        //     });
    }
}
