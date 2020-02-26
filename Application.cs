using ONVO_App.GoonGenerator;
using System;
using System.Linq;
using System.IO;
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
            //CreateHostBuilder(args).Build().Run();

            SkillGenerator gen = new SkillGenerator(0.5, 2, 0, 0.3);

            string path = Directory.GetCurrentDirectory() + "/logs/";
            string fileName = string.Format("Skill_File_@{0}-{1}-{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            if(File.Exists(path + fileName)) {
                File.Delete(path + fileName);
            }

            StreamWriter writer = new StreamWriter(File.Create(path + fileName));

            for(int i = 0; i < 300000; i++) {
                Random rng = new Random();
                Skill s = gen.makeSkill(0, rng.Next(1, 4));

                writer.WriteLine(s);
                writer.WriteLine("\n");
            }

            writer.Close();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
