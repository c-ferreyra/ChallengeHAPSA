using ChallengeHAPSA.Api.Helpers;
using ChallengeHAPSA.DependencyInjection.NetCore;
using System.Text.Json.Serialization;

const string FrontEndCorsPolicy = "FrontEnd";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InstallDependencies(builder.Configuration);

builder.Services.AddCors(options =>
    options.AddPolicy(FrontEndCorsPolicy, policy =>
        policy.WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [])
            .AllowAnyHeader()
            .AllowAnyMethod()));

// enums como string en el json (type: "Racehorse" en vez de 0)
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMediatR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // la UI solo consume el documento que ya genera Microsoft.AspNetCore.OpenApi
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/openapi/v1.json", "ChallengeHAPSA API v1"));
}

app.UseHttpsRedirection();

app.UseCors(FrontEndCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
