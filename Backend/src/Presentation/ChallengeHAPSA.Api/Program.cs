using ChallengeHAPSA.Api.Helpers;
using ChallengeHAPSA.DependencyInjection.NetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InstallDependencies(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMediatR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
