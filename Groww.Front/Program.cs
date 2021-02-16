using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;

namespace Groww.Front
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
				   .AddSingleton(new HttpClient
				   {
					   BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
				   })
				   .AddBulmaProviders()
				   .AddFontAwesomeIcons();

			var host = builder.Build();

			host.Services
				.UseBulmaProviders()
				.UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}
