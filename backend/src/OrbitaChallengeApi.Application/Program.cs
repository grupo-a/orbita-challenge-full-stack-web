using OrbitaChallengeApi.Application.Data.Context;
using OrbitaChallengeApi.Application.Data.Repositories;
using OrbitaChallengeApi.Application.Domain.Extensions;
using OrbitaChallengeApi.Application.Domain.Interfaces;
using OrbitaChallengeApi.Application.Domain.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors();

builder.Services.AddHealthChecks();

builder.Services.AddCors();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApiContext"),
    b => b.MigrationsHistoryTable("__EFMigrationsHistory", "orbita")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler(a => a.Run(async context =>
{
    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    var exception = exceptionHandlerPathFeature?.Error;

    var result = new BaseErrorResponse()
    {
        Errors = new List<string>() {
            exception?.Message ?? ""
    }
    };

    context.Response.ContentType = "application/json";
    var code = 500;

    if (exception is HttpStatusException httpException)
    {
        code = (int)httpException.Status;
    }

    context.Response.StatusCode = code;

    if (code != 204)
    {
        await context.Response.WriteAsync(JsonSerializer.Serialize(result));
    }
}));

app.UseCors(x => x
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestMigrations();

app.UseHealthChecks("/api/status");
app.UseAuthorization();

app.MapControllers();

app.Run();
