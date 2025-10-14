using Microsoft.Extensions.DependencyInjection;
using Restaurant.Ports.Primary;
using Restaurant.Services;
string path=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"products.json");

var services= new ServiceCollection();
services.AddTransient<IServicecs, ProductService>();
services.AddTransient<Restaurant.Ports.Secondary.IRepository>(sp=> new JsonRepository.JsonRepository(path));

var serviceProvider= services.BuildServiceProvider();

var productService= serviceProvider.GetService<IServicecs>();

while (true)
{
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. List Products");
    Console.WriteLine("3. Exit");

    Console.WriteLine("Select an option: ");

    string option= Console.ReadLine()??"";

    switch(option)
    {
        case "1":
            Console.WriteLine("Enter product id: ");
            int id= int.Parse(Console.ReadLine()??"0");
            Console.WriteLine("Enter product name: ");
            string name= Console.ReadLine()??"";
            Console.WriteLine("Enter product price: ");
            decimal price= decimal.Parse(Console.ReadLine()??"0");
            productService?.AddProduct(new Restaurant.Entities.Product(id,name,price));
            break;
        case "2":
            var products= productService?.GetProducts();
            if (products != null)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                }
            }
            else
            {
                Console.WriteLine("No products found.");
            }
            break;
        case "3":
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

}


    productService?.AddProduct(new Restaurant.Entities.Product(1,"Pizza",10m));
