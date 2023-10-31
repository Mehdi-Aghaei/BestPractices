using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlayGround.Client;
using PlayGround.Shared;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

/*builder.Services.AddHttpClient<TestClient>(client =>
{
	client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

*/
await builder.Build().RunAsync();
