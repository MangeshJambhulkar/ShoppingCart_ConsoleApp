using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart_ConsoleApp
{
    public class ShoppingCartCalculation
    {
        public ShoppingCartCalculation()
        {

        }
        public decimal CalculateShoppingCartBasketTotalCost(List<string> basket)
        {
            // Prices and offers
            var prices = new Dictionary<string, decimal>
        {
            { "Apple", 0.35m },
            { "Banana", 0.20m },
            { "Melon", 0.50m },
            { "Lime", 0.15m }
        };

            decimal total = 0;

            var itemCounts = basket.GroupBy(item => item)
                                   .ToDictionary(group => group.Key, group => group.Count());

            foreach (var item in itemCounts)
            {
                string itemName = item.Key;
                int count = item.Value;

                if (prices.ContainsKey(itemName))
                {
                    switch (itemName)
                    {
                        case "Melon":
                            // Buy one get one free
                            total += ((count / 2) + count % 2) * prices[itemName];
                            break;

                        case "Lime":
                            // Three for the price of two
                            total += ((count / 3) * 2 + count % 3) * prices[itemName];
                            break;

                        default:
                            // Regular pricing
                            total += count * prices[itemName];
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Warning: Unknown item '{itemName}' in the basket. Ignored.");
                }
            }

            return total;
        }
    }
}
