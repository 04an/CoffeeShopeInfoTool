using CoffeeHouse.DataAccess;
using System;
using System.Linq;

namespace CoffeeHouse.ShopInfoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Coffee House - Shop info tool!");

            Console.WriteLine("Write 'help' to list available coffe shop commands, " + 
                "write 'quit' to exit application");

            var coffeeShopDP = new CoffeeShopDP();

            while (true)
            {
                var line = Console.ReadLine();

                if (string.Equals($"quit",line, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var coffeeShops = coffeeShopDP.LoadCoffeShops();

                if (string.Equals($"help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"> Available coffee sho commands");
                    foreach(var coffeeShop in coffeeShops)
                    {
                        Console.WriteLine("> " + coffeeShop.Location) ;
                    }
                }
                else
                {
                    var foundCoffeeShops = coffeeShops
                        .Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (foundCoffeeShops.Count == 0)
                    {
                        Console.WriteLine($"> Command '{line}' not found");
                    }
                    else if (foundCoffeeShops.Count == 1)
                    {
                        var coffeShop = foundCoffeeShops.Single();
                        Console.WriteLine($"Location: {coffeShop.Location}");
                        Console.WriteLine($"Beans in stock: {coffeShop.BeansInStockInKg} kg");
                    }
                    else
                    {
                        Console.WriteLine(">Multiple matching coffe shop commands found:");
                        foreach(var coffeeType in foundCoffeeShops)
                        {
                            Console.WriteLine($"> {coffeeType.Location}");
                        }
                    }
                }
            }
        }
    }
}
