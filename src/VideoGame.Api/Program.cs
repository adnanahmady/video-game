using System.Text.Json;

using FluentValidation.AspNetCore;

using Scalar.AspNetCore;

using VideoGame.Api.Modules;
using VideoGame.Application;
using VideoGame.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddApplication();
builder.Services.AddInfrastructure(
    builder.Configuration["ConnectionStrings:Default"]!);
builder.Services.AddApiModules(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

if (app.Environment.EnvironmentName != "Testing")
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
