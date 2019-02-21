using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace Connected.Accounts.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var rootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //Directory.SetCurrentDirectory(rootPath);
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
