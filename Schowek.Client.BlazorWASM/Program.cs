using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Schowek.Client.BlazorWASM;
using Schowek.Client.BlazorWASM.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5011/api") });
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();

await builder.Build().RunAsync();
