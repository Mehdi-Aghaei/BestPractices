using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlayGround.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<TestClient>(client =>
{
	client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);

});

await builder.Build().RunAsync();
