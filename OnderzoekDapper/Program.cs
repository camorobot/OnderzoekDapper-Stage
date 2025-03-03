using OnderzoekDapper.Config;
using OnderzoekDapper.Repositories;
using OnderzoekDapper.Services;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection("DatabaseConfig").Get<DatabaseConfig>();
builder.Services.AddSingleton(config);

builder.Services.AddSingleton<ServerRepository>();
builder.Services.AddSingleton<ServerService>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
