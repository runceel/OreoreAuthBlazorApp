using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using OreoreAuthBlazorApp;
using OreoreAuthBlazorApp.Client.Pages;
using OreoreAuthBlazorApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// �F�،n�T�[�r�X�̒ǉ�
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

// Blazor�p�̔F�؏���񋟂��邽�߂̃R���|�[�l���g
// builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>(); ���Ƃ��Ƃ̓f�t�H���g�������g���Ă�
builder.Services.AddScoped<AuthenticationStateProvider, PersistingServerAuthenticationStateProvider>();
// �F�؏��� CascadingParameter �œn���悤�ɂ���
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// �F�ؔF�̃~�h���E�F�A��ǉ�
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(OreoreAuthBlazorApp.Client._Imports).Assembly);

app.Run();
