using Microsoft.EntityFrameworkCore;
using PlayGround.API.Components;
using PlayGround.API.Data;
using PlayGround.API.Routes;
using PlayGround.Client;
using PlayGround.Client.Components;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

var connectionString = builder.Configuration.GetConnectionString("ApiDatabase");
builder.Services.AddSqlite<PlayGroundDbContext>(connectionString);
builder.Services.AddScoped<TestClient>();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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

app.MapGet("/api", ( ) => "API is alive.");
app.MapPosters();
app.MapImages();
app.MapUsers();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(HomePage).Assembly);

app.Run();
