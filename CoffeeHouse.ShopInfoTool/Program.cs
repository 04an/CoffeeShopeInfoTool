using CoffeeHouse.DataAccess;
using System;

namespace CoffeeHouse.ShopInfoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Coffee House - Shop info tool!");

            Console.WriteLine("Write 'help' to list available commands");

            var coffeeShopDP = new CoffeeShopDP();

            while (true)
            {
                var line = Console.ReadLine();

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
