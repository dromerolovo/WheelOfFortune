using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WheelOfFortune.Client;
using WheelOfFortune.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

ProgramConfig.ConfigureCommonServices(builder.Services);

var host = builder.Build();

//HTTP factory is creating a new instance every injection.

var wheelService = host.Services.GetRequiredService<WheelService>();
wheelService.SetUpHttpClientBaseAddress(new Uri(builder.HostEnvironment.BaseAddress));

await host.RunAsync();