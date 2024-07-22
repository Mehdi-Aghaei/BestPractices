#pragma warning disable CA1506
using ComponentsLibrary;
using ComponentsLibrary.Clients;

using PlayGround.API.Components;
using PlayGround.API.Data;
using PlayGround.API.Endpoints;
using PlayGround.API.Routes;
using PlayGround.Client.Components;
using PlayGround.Client.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

var serverUrl = builder.Configuration["ServerUrl"] ?? throw new InvalidOperationException("Todo API URL is not configured");

var connectionString = builder.Configuration.GetConnectionString("ApiDatabase");
builder.Services.AddSqlite<PlayGroundDbContext>(connectionString);

builder.Services.AddScoped<ApiClient>();
builder.Services.AddSingleton<ITestClient, TestClient>();
builder.Services.AddHttpClient("Test", client =>
{
	client.BaseAddress = new Uri(serverUrl);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

app.MapGet("/api", () => "API is alive.");
app.MapPosters();
app.MapImages();
app.MapUsers();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(HomePage).Assembly)
	.AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
#pragma warning restore CA1506
