using Androsov.DataAccess;
using Androsov.DataAccess.Cache;
using Androsov.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");
if (connectionString == null)
{
    throw new Exception("Connection string is missing");
}

builder.Services.ConfigureSqlServer(connectionString);


builder.Services.ConfigureCacheServices(builder.Configuration);
// or configure regular repositories 
//builder.Services.ConfigureRepositories();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var databaseIntializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
await databaseIntializer.Initialize();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
