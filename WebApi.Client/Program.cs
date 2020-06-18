using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi.Model;
using Autofac;

namespace WebApi.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using (var context = new Context())
            //{
            //    context.Database.EnsureDeleted();
            //}
            using (var context = new Context())
            {
                context.Database.EnsureCreated();
                if(context.StateOfElection.Count() == 0)
                {
                    context.StateOfElection.Add(new StateOfElection());
                }
            }
            //var container = ContainerBuilderCreator.CreateBasicContainerBuilder().Build();

            //inicjalizacja SQL i autofakap
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
