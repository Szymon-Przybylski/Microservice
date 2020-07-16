using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey;
using Convey.Logging;
using Convey.WebApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShippingService.Application;
using ShippingService.Infrastructure;

namespace ShippingService.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args)
                .Build()
                .RunAsync();
        }

        private static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(
                    services => services
                        .AddConvey()
                        .AddInfrastructure()
                        .AddWebApi()
                        .AddApplication()
                        .Build()
                ).Configure(app => app
                    .UseInfrastructure()
                    .UseRouting()
                    .UseEndpoints(e => e.MapControllers())
                )
                .UseLogging();
    }
}