using Aplication.Ports;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyAppHC.Api.Mutations;
using MyAppHC.Api.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IRepository, DBRepository.TaskRepository>();

builder.Services.AddDbContext<DBRepository.Models.TaskDBContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MyAppHC.Api")));

builder.Services.AddScoped<IRepository, DBRepository.TaskRepository>();
builder.Services.AddScoped<IService, Aplication.ItemService>();

builder.Services.AddScoped<ICommonService<Note>, Aplication.NoteService>();
builder.Services.AddScoped<ICommonRepository<Note>, DBRepository.NoteRepository>();


builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<NoteQuery>()
    .AddTypeExtension<ItemQuery>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<ItemMutation>()
    .AddTypeExtension<NoteMutation>();

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

