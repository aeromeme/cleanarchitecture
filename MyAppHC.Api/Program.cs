using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyAppHC.Api.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IRepository, DBRepository.TaskRepository>();
//builder.Services.AddDbContext<DBRepository.Models.TaskDBContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<DBRepository.Models.TaskDBContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MyAppHC.Api")));

builder.Services.AddGraphQLServer().AddQueryType<ItemQuery>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();

