using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OcelotApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            builder.ConfigureServices(s => s.AddSingleton(builder))
                    .ConfigureAppConfiguration(ic => ic.AddJsonFile("Configuration.json"))
                    .UseStartup<Startup>();
            var host = builder.Build();
            return host;
        }
    }
}

//public static void Main(string[] args)
//{
//    CreateWebHostBuilder(args).Build().Run();
//}

//public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//    WebHost.CreateDefaultBuilder(args)
//        .UseStartup<Startup>();