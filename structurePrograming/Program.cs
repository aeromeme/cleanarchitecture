int number = 15;
number = 20;
float decimalNumber = 1.2f; // 7 digits precision
double decimalNumber2 = 1.2; // 15-16 digits precision
decimal decimalNumber3 = 1.2m; // 28-29 digits precision
bool isTrue = true; // false
string name="TOTO";
char l='T';
var num = 15.2m;

//arays
int[] numbers = new int[3];
numbers[0] = 15;
numbers[1] = 20;
numbers[2] = 25;

var numbers2 = new int[] { 15, 20, 25 };

switch (number)
{
    case 15:
        Console.WriteLine("number is 15");
        break;
    case 20:
        Console.WriteLine("number is 20");
        break;
    default:
        Console.WriteLine("number is not 15 or 20");
        break;
}

while (number < 25)
{
    Console.WriteLine(number);
    number++;
}
do
{
    Console.WriteLine(number);
    number++;
} while (number < 30);
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine(numbers[i]);
}

Console.WriteLine(mayorque100(number));
show(mayorque100(105).ToString());

bool mayorque100 (int number) { 
    if (number > 100)
    {
        return true;
    }
    return false;
}
void show(string message) { 
    Console.WriteLine(message);
}

int limit = 10;
var beers = new string[limit];
int op = 0;
do {
    Console.Clear();
        showMenu();
    op = int.Parse(Console.ReadLine());
        switch (op)
        {
            case 1:
                if (Array.IndexOf(beers, null) != -1)
                {
                    Console.WriteLine("Enter beer name:");
                    string beerName = Console.ReadLine();
                    beers[Array.IndexOf(beers, null)] = beerName;
                }
                else
                {
                    Console.WriteLine("Beer list is full.");
                }
                break;
            case 2:
                showBeers(beers);
            break;
            case 3:
                Console.WriteLine("Exiting...");
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                break;
    }
} while (op !=3);

void showMenu()
{
    Console.WriteLine("1. Add beer");
    Console.WriteLine("2. List beers");
    Console.WriteLine("3. Exit");
}
void showBeers(string[] beers)
{
    Console.WriteLine("Beers:");
    foreach (var beer in beers)
    {
        if (beer != null)
        {
            Console.WriteLine(beer);
        }
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}