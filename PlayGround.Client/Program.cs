using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlayGround.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ITestService, TestService>();
await builder.Build().RunAsync();
