﻿using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeHouse.DataAccess.Model;

namespace CoffeeHouse.ShopInfoTool
{
    internal class CoffeeShopCommandHandler : ICommandHandler
    {
        private IEnumerable<CoffeeShop> coffeeShops;
        private string line;

        public CoffeeShopCommandHandler(IEnumerable<CoffeeShop> coffeeShops, string line)
        {
            this.coffeeShops = coffeeShops;
            this.line = line;
        }

        public void HandleCommand()
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
                foreach (var coffeeType in foundCoffeeShops)
                {
                    Console.WriteLine($"> {coffeeType.Location}");
                }
            }

        }
    }
}