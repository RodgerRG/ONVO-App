using ONVO_App.GoonGenerator;
using ONVO_App.SocketManager;
using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace ONVO_App
{
    class Program
    {
        static void Main(string[] args)
        {
            GoonGenerator.GoonGenerator goonGen = new GoonGenerator.GoonGenerator();
            Output output = new Output();
            Goon[] goons = goonGen.generateGoons(300, 1, 3, 8, 8, 13, 1, 1, 3, 4, 1, 1);

            output.printGoons(goons);
            output.printGoonstoFile(goons);

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
