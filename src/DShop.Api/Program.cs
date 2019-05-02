using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using DShop.Common.Logging;
using DShop.Common.Metrics;
using DShop.Common.Mvc;
using DShop.Common.Vault;
using System;
using Serilog;

namespace DShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            { 
                CreateWebHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Host terminted unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseLogging()
                .UseVault()
                .UseLockbox()
                .UseAppMetrics();
    }
}
