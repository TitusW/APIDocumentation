using Microsoft.EntityFrameworkCore;
using APIService.Data;
using APIService.Repositories;
using APIService.Usecases;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration
    //.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

Console.WriteLine("DefaultConnection: " + builder.Configuration.GetConnectionString("DefaultConnection"));

var env = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<APIServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
 });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAPIDefinitionRepo, APIDefinitionRepo>();
builder.Services.AddScoped<IAPIFieldRepo, APIFieldRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAPIDefinitionUsecase, APIDefinitionUsecase>();
builder.Services.AddScoped<IAPIFieldUsecase, APIFieldUsecase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Test")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

