using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.EntityFrameworkCore;
using PlayGround.API.Components;
using PlayGround.API.Data;
using PlayGround.API.Routes;
using PlayGround.Client;
using PlayGround.Client.Components;
using PlayGround.Shared;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

var connectionString = builder.Configuration.GetConnectionString("ApiDatabase");
builder.Services.AddSqlite<PlayGroundDbContext>(connectionString);
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IClient,TestClient>();
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

app.MapGet("/api", (int id ) => { 
	id += 1; 
	return $"API is alive: {id += 1}"; });
app.MapPosters();
app.MapImages();
app.MapUsers();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(HomePage).Assembly);

app.Run();