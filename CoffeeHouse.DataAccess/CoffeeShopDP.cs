using CoffeeHouse.DataAccess.Model;
using System.Collections.Generic;

namespace CoffeeHouse.DataAccess
{
    public class CoffeeShopDP
    {
        public IEnumerable<CoffeeShop> LoadCoffeShops()
        {
            yield return new CoffeeShop { Location = "Warsaw", BeansInStockInKg = 191, PaperCupsInStock = 200 };
            yield return new CoffeeShop { Location = "Berlin", BeansInStockInKg = 91, PaperCupsInStock = 50 };
            yield return new CoffeeShop { Location = "Paris", BeansInStockInKg = 121, PaperCupsInStock = 101 };
        }
    }
}

