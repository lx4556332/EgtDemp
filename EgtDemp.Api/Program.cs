using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Winton.Extensions.Configuration.Consul;

namespace EgtDemp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((context,config) =>
                    {
                        var env = context.HostingEnvironment;
                        config.AddConsul($"{env.ApplicationName}/appsettings.{env.EnvironmentName}.json", options =>
                        {
                            //1、使用consul客戶端加载consul配置
                            options.ConsulConfigurationOptions = cco =>
                            {
                                cco.Address = new Uri("http://127.0.0.1:8500");
                            };
                            //2、热更新（动态加载）
                            options.ReloadOnChange = true;
                        });
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
