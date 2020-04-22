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

                if (string.Equals($"quit",line, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var coffeeShops = coffeeShopDP.LoadCoffeShops();

                var commandHandler = string.Equals($"help", line, StringComparison.OrdinalIgnoreCase)
                    ? new HelpCommandHandler(coffeeShops) as ICommandHandler
                    : new CoffeeShopCommandHandler(coffeeShops, line);
                
                commandHandler.HandleCommand();
            }
        }
    }
}
