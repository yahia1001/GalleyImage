using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GalleryImage.Client.Helper;
using GalleryImage.Client;

namespace Gallery.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //Important
            ConfiguredServices(builder.Services);
            await builder.Build().RunAsync();
        }

        private static void ConfiguredServices(IServiceCollection services)
        {
            services.AddOptions();


            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IRepository, Repository>();

        }

    }
}
