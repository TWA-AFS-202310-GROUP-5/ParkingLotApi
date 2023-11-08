using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ParkingLotApi.Filters;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;
using ParkingLotApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<InvalidCapacityExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ParkingLotService>();
builder.Services.Configure<ParkingLotDBSettings>(builder.Configuration.GetSection("ParkingLotDatabase"));
builder.Services.AddSingleton<IParkingLotRepository, ParkingLotRepository>();

var app = builder.Build();

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

public partial class Program { }