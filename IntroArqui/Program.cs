// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

Console.WriteLine("Hello, World!");

var names= new Names();
var nameshash= new NamesHash();
var system = new MySystem(nameshash);
//while (true)
//{
//    system.Run();
//}


var services = new ServiceCollection();
services.AddSingleton<INames, NamesHash>();
services.AddSingleton<MySystem>();

var serviceProvider = services.BuildServiceProvider();

var Mysystem = serviceProvider.GetService<MySystem>();
while (Mysystem != null)
{
    Mysystem.Run();
}



//dominio
public interface INames
{
    void AddName(string name);
    List<string> GetNames();
}

//data
public class Names : INames
{
    private readonly List<string> _names = new();
    public void AddName(string name) => _names.Add(name);
    public List<string> GetNames() => _names;
}

public class NamesHash: INames
{
    private readonly HashSet<string> _names = new();
    public void AddName(string name) => _names.Add(name);
    public List<string> GetNames() => _names.ToList();
}

//UI
public class MySystem
{
    private readonly INames _names;
    public MySystem(INames names)
    {
        _names = names;
    }
    public void ShowNames()
    {
        foreach (var name in _names.GetNames())
        {
            Console.WriteLine(name);
        }
    }

    public void Run() {
        Console.WriteLine("Select menu");
        Console.WriteLine("1. Add Name");
        Console.WriteLine("2. Show Names");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Option: ");

        string option = Console.ReadLine() ?? "";

        switch(option)
        {
            case "1":
                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine() ?? "";
                _names.AddName(name);
                break;
            case "2":
                ShowNames();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
}
