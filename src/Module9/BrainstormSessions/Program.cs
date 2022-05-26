using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System.IO;
using System.Net;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(path: "appsettings.json")
                    .Build();

            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    // Implemented from here as well, without lack 
                    /*.WriteTo.Email(new EmailConnectionInfo
                    {
                        FromEmail = "--@gmail.com",
                        ToEmail = "--@gmail.com",
                        MailServer = "smtp.gmail.com",
                        NetworkCredentials = new NetworkCredential
                        {
                            UserName = "--@gmail.com",
                            Password = "SUPERSECRET"
                        },
                        EnableSsl = true,
                        Port = 465,
                        EmailSubject = "Error in app"
                    },  batchPostingLimit: 10)*/
                .CreateLogger();


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
