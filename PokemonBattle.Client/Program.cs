using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PokemonBattle.Client.Controllers;
using PokemonBattle.Client.Orchestrators;
using PokemonBattle.Client.StateManagement;
using PokemonBattle.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<StateManager>();
            builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddScoped<IPokemonOrchestrator, PokemonOrchestrator>();
            builder.Services.AddScoped<PokemonController>();
            await builder.Build().RunAsync();
        }
    }
}
