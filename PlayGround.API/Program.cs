using Microsoft.EntityFrameworkCore;
using PlayGround.API.Components;
using PlayGround.API.Data;
using PlayGround.API.Routes;
using PlayGround.Client.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("ApiDatabase");
builder.Services.AddSqlite<PlayGroundDbContext>(connectionString);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
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
	.AddAdditionalAssemblies(typeof(HomePage).Assembly);

app.Run();
