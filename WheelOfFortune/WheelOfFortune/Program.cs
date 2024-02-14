using System.Reflection;
using WheelOfFortune;
using WheelOfFortune.Client.Pages;
using WheelOfFortune.Client.Services;
using WheelOfFortune.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

WheelOfFortune.Client.ProgramConfig.ConfigureCommonServices(builder.Services);

var app = builder.Build();

var wheelService = app.Services.GetRequiredService<WheelService>();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WheelPage).Assembly);

app.MapGet("/api/get-random", () => TypedResults.Ok(GetRandomService.ComputeRotation()));

app.Run();
