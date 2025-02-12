using Microsoft.EntityFrameworkCore;
using WebAppDocker.Database.Entities;
using WebAppDocker.Database.Repositories;
using WebAppDocker.Extensions;
using WebAppDocker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Database");
//string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//string dbName = Environment.GetEnvironmentVariable("DB_NAME");
//string dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
//string connectionStringFormatted = "";
//if (connectionString!=null)
//{
//    connectionStringFormatted = string.Format(connectionString, dbHost, dbName, dbPassword);
//}
builder.Services.AddDbContext<WebAppDockerDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();

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
    // extension method for database migrations
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
