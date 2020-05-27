using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SkillTreeRazorPageBlogSample.Data;
using SkillTreeRazorPageBlogSample.Model;

namespace SkillTreeRazorPageBlogSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //   CreateHostBuilder(args).Build().Run();

            #region SeedData init  第一次作 要建db 寫資料

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<RazorPageBlogContext>();
                    context.Database.EnsureCreated();
                    
                    SeedData.Initialize(services);  //這裡
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();

            #endregion



        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
