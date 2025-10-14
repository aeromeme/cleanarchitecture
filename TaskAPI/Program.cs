using Aplication;
using Aplication.DTO;
using Aplication.Ports;
using DBRepository.Extra;
using DBRepository.Factory;
using DBRepository.Models;
using Domain.Entities;
using Domain.Interfaces;
using Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString=builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBRepository.Models.TaskDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepository, DBRepository.TaskRepository>();
builder.Services.AddScoped<IService, Aplication.ItemService>();

builder.Services.AddScoped<ICommonRepository<Note>, DBRepository.NoteRepository>();
builder.Services.AddScoped<ICommonService<Note>, Aplication.NoteService>();

builder.Services.AddScoped<ICommonRepository<NoteDto>, DBRepository.Note2Repository>();
builder.Services.AddScoped<ICommonService<NoteDto>, Aplication.Note2Service>();


// to use mappers
builder.Services.AddScoped<IAddRespository<NoteModel>, DBRepository.Note3Respository>();
builder.Services.AddScoped<IAddService<NoteDto,NoteModel>, Aplication.note3Service <NoteDto,NoteModel >>();
builder.Services.AddTransient<IMapper<NoteDto, Note>, NoteEntityMapper>();
builder.Services.AddTransient<IMapper<NoteDto, NoteModel>, NoteModelMapper>();


//to use factory with extra data
builder.Services.AddScoped<IFactoryRepository<IAddRespository<Note>, NoteExtraData>, Factory>();
builder.Services.AddTransient<IMapper<NoteDto, NoteExtraData>, NoteExtraDataMapper>();
builder.Services.AddScoped<IAddService<NoteDto, NoteExtraData>, notewithFactoryService<NoteDto, NoteExtraData>>();


//complete service

builder.Services.AddScoped<ICompleteRepository, DBRepository.TaskRepository>();
builder.Services.AddScoped<IGetRepository<Item>, DBRepository.TaskRepository>();

builder.Services.AddScoped<ICompleteService, CompleteTaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/items", async (IService service) =>
{
    var items = await service.getItems();
    return Results.Ok(items);
}).WithName("getItems");
app.MapPost("/items", async (IService service, string title) =>
{
    await service.addItem(title);
    return Results.Created();
}).WithName("saveItem");

app.MapGet("/notes", async (ICommonService<Note> service) => {
    var notes = await service.GetAll();
    return Results.Ok(notes);
}).WithName("get notes");

app.MapPost("/notes", async (ICommonService<Note> service, Note note) => {
   await service.AddEntity(note);
    return Results.Created();
}).WithName("add notes");

app.MapGet("/notes2", async (ICommonService<NoteDto> service) => {
    var notes = await service.GetAll();
    return Results.Ok(notes);
}).WithName("get notes 2");

app.MapPost("/notes2", async (ICommonService<NoteDto> service, NoteDto note) => {
    await service.AddEntity(note);
    return Results.Created();
}).WithName("add notes 2");


app.MapPost("/notes3", async (IAddService<NoteDto,NoteModel> service, NoteDto note) => {
    await service.AddAsync(note);
    return Results.Created();
}).WithName("add notes 3");

app.MapPost("/notes4", async (IAddService<NoteDto, NoteExtraData> service, NoteDto note) => {
    await service.AddAsync(note);
    return Results.Created();
}).WithName("add notes 4");

app.MapPost("/completeitems/{id}", async (ICompleteService service, int id) => {
    try
    {
        await service.Complete(id);
        return Results.NoContent();
    }
    catch (Exception)
    {
      return Results.NotFound();
    } 
    
}).WithName("complete items");

app.Run();

