#region Usings

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

#endregion

namespace AdvECommDay8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}