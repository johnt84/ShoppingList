using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ShoppingListBlazorWasm.Client.Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShoppingListBlazorWasm.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<ShoppingListClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            await builder.Build().RunAsync();
        }
    }
}
