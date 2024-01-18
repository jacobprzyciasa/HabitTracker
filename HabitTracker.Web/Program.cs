using Blazored.LocalStorage;
using HabitTracker.Web;
using HabitTracker.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;
using AutoMapper;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//auth
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRefitClient<IUserService>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7161"));
builder.Services.AddRefitClient<IHabitListService>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7161"));
builder.Services.AddRefitClient<IHabitService>().ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7161"));
builder.Services.AddAutoMapper(typeof(Program));

await builder.Build().RunAsync();
