using UGOptionsPattern.Components;
using UGOptionsPattern.Middleware;
using UGOptionsPattern.Services;

var builder = WebApplication.CreateBuilder(args);

/*
 * You have to tell the app builder to load in the appsettings file and the environment specific appsettings file
 * You can literally have 8 sandbox environments, 
 *                        2 production environments, 
 *                        3 development environments,
 *                        and your local and this process works for all without any extra code.
 */
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

/*
 * Load and run the middleware that loads in all your settings from the appsettings file.
 */
EnvironmentSettings environmentSettings = new(builder.Services);
environmentSettings.ConfigureSettings(builder.Configuration);

builder.Services.AddScoped<DatabaseService>();
builder.Services.AddScoped<HomePageService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
