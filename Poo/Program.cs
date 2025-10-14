using Poo.Bussisness;
Beer corona= new Beer() { Name = "Corona", Price = 1.5M };
Beer heineken = new Beer("Heineken", 1.2M);
Console.WriteLine($"Beer: {corona.Name}, Price: {corona.Price.ToString("C")}");
Console.WriteLine(heineken.GetInfo("Cerveza de SV "));
ExpiringBeer modelo = new ExpiringBeer("Modelo", 1.8M, DateTime.Now.AddMonths(6));
Console.WriteLine(modelo.GetInfo("Cerveza d SV"));
Console.WriteLine($"Price after discount: {ApplyDiscount(heineken).ToString("C")}");
Console.WriteLine($"Price after discount: {ApplyDiscount(corona).ToString("C")}");
Console.WriteLine($"Price after discount: {ApplyDiscount(modelo).ToString("C")}");
Collection<int> numbers = new Collection<int>(3);
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);

foreach (var number in numbers.GetAll())
{
    Console.WriteLine(number);
}


decimal ApplyDiscount(ISalable item)
{
    return item.Price - (item.Price * item.Discount / 100);
}
