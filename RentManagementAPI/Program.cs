global using RentManagementAPI.Models;
global using RentManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using RentManagementAPI.Mapping;
using RentManagementAPI.Services.FloorService;
using RentManagementAPI.Services.FlatService;
using RentManagementAPI.Services.RentService;
using RentManagementAPI.Services.TenantService;
using RentManagementAPI.Services.DepositeService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFloorService, FloorService>();
builder.Services.AddScoped<IFlatService, FlatService>();
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IDepositeService, DepositeService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddDbContext<DataContext>();

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
