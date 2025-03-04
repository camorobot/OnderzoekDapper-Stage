using OnderzoekDapper.Config;
using OnderzoekDapper.Repositories;
using OnderzoekDapper.Services;

using Microsoft.EntityFrameworkCore;
using OnderzoekDapper.Config;
using OnderzoekDapper.DBContext;
using OnderzoekDapper.Repositories;
using OnderzoekDapper.Repositories.Interfaces;
using OnderzoekDapper.Services;

var builder = WebApplication.CreateBuilder(args);

// Haal databaseconfiguratie op uit appsettings.json
var config = builder.Configuration.GetSection("DatabaseConfig").Get<DatabaseConfig>();
builder.Services.AddSingleton(config);

// Voeg DbContext toe voor Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(config.ConnectionString));

// **Schakel hier tussen Dapper en EF**
// Gebruik Dapper
builder.Services.AddSingleton<IUserRepository>(new DapperUserRepository(config.ConnectionString));

// Gebruik Entity Framework
// builder.Services.AddScoped<IUserRepository, EFUserRepository>();

// Voeg de services toe
builder.Services.AddScoped<UserService>();

// Voeg ServerRepository en ServerService toe (bestaande services)
builder.Services.AddSingleton<ServerRepository>();
builder.Services.AddSingleton<ServerService>();

// Voeg controllers en OpenAPI ondersteuning toe
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

