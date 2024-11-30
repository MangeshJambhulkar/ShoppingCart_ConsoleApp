using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace ShoppingCartUnitTest
{
    [TestClass]
    public class ShoppingCartUnitTest
    {
        [TestMethod]
        public void Test_EmptyBasket_ReturnsZero()
        {
            // Arrange
            var basket = new List<string>(); 
            // Act
            var totalCost = new ShoppingCart_ConsoleApp.ShoppingCartCalculation().CalculateShoppingCartBasketTotalCost(basket); 
            // Assert
            Assert.AreEqual(0, totalCost);
        }
        [TestMethod]
        public void Test_SingleItemTypes_ReturnsCorrectCost()
        {
            // Arrange
            var basket = new List<string> { "Apple", "Banana", "Melon", "Lime" };

            // Act
            var totalCost = new ShoppingCart_ConsoleApp.ShoppingCartCalculation().CalculateShoppingCartBasketTotalCost(basket);

            // Assert
            Assert.AreEqual(1.20m, totalCost); // 35p + 20p + 50p + 15p = £1.20
        }
        [TestMethod]
        public void Test_MultipleItemsWithOffers_ReturnsCorrectCost()
        {
            // Arrange
            var basket = new List<string> { "Apple", "Apple", "Banana", "Melon", "Melon", "Lime", "Lime", "Lime", "Lime" };

            // Act
            var totalCost = new ShoppingCart_ConsoleApp.ShoppingCartCalculation().CalculateShoppingCartBasketTotalCost(basket);

            // Assert
            Assert.AreEqual(1.85m, totalCost); // As calculated in the example
        }
        [TestMethod]
        public void Test_OnlyMelonsWithOffer_ReturnsCorrectCost()
        {
            // Arrange
            var basket = new List<string> { "Melon", "Melon", "Melon" };

            // Act
            var totalCost = new ShoppingCart_ConsoleApp.ShoppingCartCalculation().CalculateShoppingCartBasketTotalCost(basket);

            // Assert
            Assert.AreEqual(1.00m, totalCost); // Two Melons at 50p each + one free = £1.00
        }
        [TestMethod]
        public void Test_OnlyLimesWithOffer_ReturnsCorrectCost()
        {
            // Arrange
            var basket = new List<string> { "Lime", "Lime", "Lime", "Lime", "Lime" };

            // Act
            var totalCost = new ShoppingCart_ConsoleApp.ShoppingCartCalculation().CalculateShoppingCartBasketTotalCost(basket);

            // Assert
            Assert.AreEqual(0.60m, totalCost); // Three for 30p + Two at 30p = £0.60
        }
        [TestMethod]
        public void Test_InvalidItem_IgnoresUnknownItems()
        {
            // Arrange
            var basket = new List<string> { "Apple", "InvalidItem", "Banana" };

            // Act
            var totalCost = new ShoppingCart_ConsoleApp.ShoppingCartCalculation().CalculateShoppingCartBasketTotalCost(basket);

            // Assert
            Assert.AreEqual(0.55m, totalCost); // 35p (Apple) + 20p (Banana) = £0.55
        }

        [TestMethod]
        public void Test_InvalidItemTypes_IgnoresAndCalculatesCorrectly()
        {
            // Arrange
            var basket = new List<string> { "InvalidItem1", "InvalidItem2", "Apple", "Banana" };

            // Act
            var totalCost = new ShoppingCart_ConsoleApp.ShoppingCartCalculation().CalculateShoppingCartBasketTotalCost(basket);

            // Assert
            Assert.AreEqual(0.55m, totalCost); // 35p (Apple) + 20p (Banana) = £0.55
        }
        [TestMethod]
        public void Test_NullBasket_ThrowsArgumentNullException()
        {
            // Arrange
            List<string> basket = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ShoppingCart_ConsoleApp.ShoppingCartCalculation().CalculateShoppingCartBasketTotalCost(basket));
        }
    }
}
