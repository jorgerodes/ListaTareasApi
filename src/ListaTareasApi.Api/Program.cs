using Asp.Versioning;
using Asp.Versioning.Builder;
using CleanArchitecture.Api.Extensions;
using ListaTareasApi.Api.Tareas;
using ListaTareasApi.Application;
using ListaTareasApi.Infrastructure;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.ApplyMigration();



app.MapControllers();

ApiVersionSet apiVersion = app.NewApiVersionSet().HasApiVersion(new ApiVersion(1))
    .ReportApiVersions().Build();

var routeGroupBuilder = app.MapGroup("api/v{version:apiVersion}").WithApiVersionSet(apiVersion);

routeGroupBuilder.MapTareaEndpoints();


app.Run();


