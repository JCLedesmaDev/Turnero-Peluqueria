#region Realizo importaciones a nivel global para evitar el using en cada pag


// service
global using Turnero.Client.Service;

// Store's
global using Turnero.Client.StoreGlobal;

// Models
global using Turnero.Client.Models;

#endregion

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Turnero.Client;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region Servicios agregados

// Peluquero 
builder.Services.AddScoped<PeluqueroService>();
builder.Services.AddScoped<TurnoService>();

// Store's
builder.Services.AddScoped<GlobalStore>();


#endregion Servicios agregados


await builder.Build().RunAsync();