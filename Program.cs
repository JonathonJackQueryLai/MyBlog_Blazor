using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyblogBlazor.Commons;

namespace MyblogBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var baseAddress = "https://39.108.218.166/";

            if (builder.HostEnvironment.IsProduction())
                baseAddress = "https://39.108.218.166/";

            builder.Services.AddTransient(sp => new HttpClient
                {
                    
                    BaseAddress = new Uri(baseAddress)
                });
          
            builder.Services.AddSingleton(typeof(Common));

            await builder.Build().RunAsync();
        }
    }
}
