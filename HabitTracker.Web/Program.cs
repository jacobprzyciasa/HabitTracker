using HabitTracker.Web;
using HabitTracker.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRefitClient<IUserService>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7161"));
builder.Services.AddRefitClient<IHabitListService>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7161"));

await builder.Build().RunAsync();
