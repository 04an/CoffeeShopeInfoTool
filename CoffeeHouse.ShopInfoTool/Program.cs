using CoffeeHouse.DataAccess;
using System;

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

                if (string.Equals("quit",line, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var coffeeShops = coffeeShopDP.LoadCoffeShops();

                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee sho commands");
                    foreach(var coffeeShop in coffeeShops)
                    {
                        Console.WriteLine("> " + coffeeShop.Location) ;
                    }
                }
            }
        }
    }
}
