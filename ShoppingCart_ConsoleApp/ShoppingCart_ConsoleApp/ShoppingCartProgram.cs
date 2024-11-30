using System;
using System.Collections.Generic;
namespace ShoppingCart_ConsoleApp
{
    public class ShoppingCartProgram
    {
        static void Main(string[] args)
        {
            var basket = new List<string> { "Apple",  "Banana", "Melon", "Melon", "Lime", "Lime", "Lime"};
            decimal totalCost = new ShoppingCartCalculation().CalculateShoppingCartBasketTotalCost(basket);
            Console.WriteLine($"Shopping CartBasket Total cost(Given Items in problem): ${totalCost:F2}");

            basket = new List<string> { "Apple", "Apple", "Banana", "Melon", "Melon", "Melon", "Lime", "Lime", "Lime", "Lime" };
            totalCost = new ShoppingCartCalculation().CalculateShoppingCartBasketTotalCost(basket);
            Console.WriteLine($"Shopping CartBasket Total cost(To Test Discount): ${totalCost:F2}");
        }
    }
}
