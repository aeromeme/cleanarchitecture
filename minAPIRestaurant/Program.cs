var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "products.json");
string pathxml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productsxml.xml");
builder.Services.AddTransient<Restaurant.Ports.Primary.IServicecs, Restaurant.Services.ProductService>();
//builder.Services.AddTransient<Restaurant.Ports.Secondary.IRepository>(sp => new JsonRepository.JsonRepository(path));
builder.Services.AddTransient<Restaurant.Ports.Secondary.IRepository>(sp => new xmlRepository.XmlProductRepository(pathxml));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

///app.UseHttpsRedirection();


app.MapGet("/products", (Restaurant.Ports.Primary.IServicecs productService) =>
{
    return Results.Ok(productService.GetProducts());
}).WithName("GetProducts");

app.MapPost("/products", (Restaurant.Ports.Primary.IServicecs productService, Restaurant.Entities.Product product) =>
{
    productService.AddProduct(product);
    return Results.Created($"/products/{product.Id}", product);
}).WithName("AddProducts");

app.Run();

