using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OreoreAuthBlazorApp.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 以下の3行を追加
builder.Services.AddScoped<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
