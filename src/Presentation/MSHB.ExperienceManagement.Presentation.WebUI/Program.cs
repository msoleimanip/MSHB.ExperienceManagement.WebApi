using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MSHB.ExperienceManagement.Layers.L03.Services.Security;

namespace MSHB.ExperienceManagement.Presentation.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
  

            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbInitializer = scope.ServiceProvider.GetService<IDbInitializerService>();
                    dbInitializer.Initialize();
                    dbInitializer.SeedData();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            host.Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()    
                .UseKestrel(option =>
                {
                    option.Limits.MaxRequestBodySize = null;

                })
             .ConfigureLogging((hostingContext, logging) =>
             {
                 logging.AddDebug();
                 logging.AddConsole();
                 logging.AddLog4Net();
                 logging.SetMinimumLevel(LogLevel.Debug);
             })
                .UseIISIntegration() 
                .UseUrls("http://0.0.0.0:6000")
                .Build();
    }
}
