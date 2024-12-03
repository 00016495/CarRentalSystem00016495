using Microsoft.EntityFrameworkCore;
using CarRentalSystem00016495.Api.Data.DbContexts;
using CarRentalSystem00016495.Api.Data.IRepositories;
using CarRentalSystem00016495.Api.Data.Repositories;
using CarRentalSystem00016495.Api.Middlewares;
using CarRentalSystem00016495.Api.Service.Interfaces;
using CarRentalSystem00016495.Api.Service.Mappers;
using CarRentalSystem00016495.Api.Service.Services;
using CarRentalSystem00016495.Api.Helpers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Database
builder.Services.AddDbContext<AppDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Mapper registered
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Service regisration
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IRentalService,RentalService>();

// Configure URL
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new ConfigureApiUrlName()));
});

// Allowing CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost4200");
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
