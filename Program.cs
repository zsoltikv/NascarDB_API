/*
 * ASP.NET Core Web API (.NET 8.0) – Step by Step
 * 
 * 1Create Project:
 * - Project type: ASP.NET Core Web API
 * - Framework: .NET 8.0
 * - Settings:
 *      • Use Controllers
 *      • Enable HTTPS
 *      • Enable Open API (Swagger)
 * 
 * Create Database (SQL Server):
 * - Open SQL Server Object Explorer -> New Query
 * 
 * CREATE DATABASE nascardb;
 * use database nascardb;
 * 
 * Install NuGet Packages (Package Manager Console):
 * 
 * Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.22
 * Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.22
 * Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.22
 * 
 * Scaffold Database (from existing DB):
 * 
 * Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=nascardb;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context NascarDBContext -DataAnnotations
 * 
 * - OutputDir Models       -> folder for generated models
 * - Context NascarDBContext -> name of the DbContext
 * - DataAnnotations        -> use annotations in models
 * 
 * Configure Connection String (appsettings.json):
 * 
 * {
 *   "ConnectionStrings": {
 *     "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=nascardb;Trusted_Connection=True;"
 *   }
 * }
 * 
 * Register DbContext in Program.cs:
 * 
 * using Microsoft.EntityFrameworkCore;
 * using MyNamespace.Models; // replace with your own namespace
 * 
 * var builder = WebApplication.CreateBuilder(args);
 * 
 * // Register DbContext
 * builder.Services.AddDbContext<NascarDBContext>(options =>
 *     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 * 
 * // Register Controllers and Swagger
 * builder.Services.AddControllers();
 * builder.Services.AddEndpointsApiExplorer();
 * builder.Services.AddSwaggerGen();
 * 
 * var app = builder.Build();
 * 
 * // Configure HTTP request pipeline
 * if (app.Environment.IsDevelopment())
 * {
 *     app.UseSwagger();
 *     app.UseSwaggerUI();
 * }
 * 
 * app.UseHttpsRedirection();
 * app.UseAuthorization();
 * app.MapControllers();
 * 
 * app.Run();
 * 
 * Create API Controller:
 * - Project Explorer -> Controllers -> Add -> New Scaffolded Item
 * - Choose "API Controller with actions, using Entity Framework"
 * - Select NascarDBContext and the desired model
 * - Visual Studio will generate basic CRUD actions
 */

using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<NascarDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
