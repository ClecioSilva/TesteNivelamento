using MediatR;
using Microsoft.OpenApi.Models;
using Questao5.Infrastructure.Sqlite;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Your API", Version = "v1"});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// sqlite
//#pragma warning disable CS8602 // Dereference of a possibly null reference.
var databaseBootstrap = app.Services.GetService<IDatabaseBootstrap>();
databaseBootstrap?.Setup();
//#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informa��es �teis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


