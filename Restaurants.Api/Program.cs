using Infra.Restaurants;
using Infra.Restaurants.Extensions;
using Infra.Restaurants.Seeders;
using Infra.Restaurants.ServiceExtensions;
using Microsoft.EntityFrameworkCore;
using RestaurantsPresentation.Api.Middlewares;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCore();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseTimeMiddleware();

app.UseSwagger();
app.UseSwaggerUI();


var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeders>();
await seeder.RestuarantList();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
