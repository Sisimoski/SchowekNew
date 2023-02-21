using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Schowek.Client.BlazorWASM;
using Schowek.Library.Data;
using Schowek.Library.Interfaces;
using Schowek.Library.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContext<DataContext>(options =>
{
    // options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); ;
    options.UseSqlite("DataSource=/Users/sisimoski/Documents/Development 👨‍💻/SchowekNew/Schowek.Library/Data/app.db");
});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();

await builder.Build().RunAsync();
