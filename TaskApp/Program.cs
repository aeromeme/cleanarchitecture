using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Aplication.Ports;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");
var services = new ServiceCollection();
services.AddDbContext<DBRepository.Models.TaskDBContext>(options =>
    options.UseSqlServer(connectionString));

services.AddScoped<IRepository, DBRepository.TaskRepository>();
services.AddScoped<IService, Aplication.ItemService>();

var serviceProvider = services.BuildServiceProvider();

var itemService = serviceProvider.GetService<IService>();

while (true) {
    Console.WriteLine("1 add item");
    Console.WriteLine("2 list items");
    Console.WriteLine("3 exit");
    Console.Write("Choose an option: ");
    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            Console.Write("Enter item title: ");
            var title = Console.ReadLine();
           
            if (itemService != null && title != null)
            {
                await itemService.addItem(title);
              
                Console.WriteLine("Item added.");
            }
            break;
         case "2": 
            
            if (itemService != null)
            {
                var items = await itemService.getItems();
                foreach (var item in items)
                {
                    Console.WriteLine($"ID: {item.Id}, Title: {item.Title}, Completed: {item.IsCompleted}");
                }
            }
            break;
        case "3":
             return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;

    }


}