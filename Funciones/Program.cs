DateTime Tomorrow() => DateTime.Now.AddDays(1);
Console.WriteLine("funcion no pura"+Tomorrow());

var t = PureTomorrow;
Console.WriteLine("funcion pura"+t(DateTime.Now));

Action<string> print = x => Console.WriteLine(x);

print("Hello World");
DateTime PureTomorrow(DateTime date) => date.AddDays(1);
Console.WriteLine("funcion pura"+PureTomorrow(DateTime.Now));

Beer corona= new Beer( "Corona", 1.5M);
Beer heineken= new Beer("Heineken", 1.2M);


Console.WriteLine("funcion no pura"+ToUpperCase(corona).Name);
Console.WriteLine("funcion no pura"+corona.Name);
Console.WriteLine("funcion pura"+ToUpperPure(heineken).Name);
Console.WriteLine("funcion pura"+heineken.Name);


Action<string> hi = name => Console.WriteLine($"Hello {name}");
Action <int,int> sum = (a,b) => print((a+b).ToString());

hi("Salvador");
sum(3,5);


Func<int,int,int> add = (a,b) => a+b;
Predicate<int> isPositive = n => n > 0;
print(add(4,5).ToString());

List<int> numbers = new List<int>() {1,2,3,4,5,6,7,8,9,10};
var evenNumbers = Filter(numbers, n => n % 2 == 0);

foreach (var item in evenNumbers)
{
    print(item.ToString());
}

List<int> Filter(List<int> list, Predicate<int> predicate)
{
    List<int> result = new List<int>();
    foreach (var item in list)
    {
        if (predicate(item))
        {
            result.Add(item);
        }
    }
    return result;
}

Predicate<int> isEven = n => n % 2 == 0;
print(isEven(4).ToString());


Beer ToUpperCase(Beer beer)
{
    beer.Name = beer.Name.ToUpper();
    return beer;
}
Beer ToUpperPure(Beer beer)
{
    return new Beer(beer.Name.ToUpper(), beer.Price);
}
public class Beer
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Beer(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}