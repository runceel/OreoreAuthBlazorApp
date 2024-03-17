using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OreoreAuthBlazorApp.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// à»â∫ÇÃ3çsÇí«â¡
builder.Services.AddScoped<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
