using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_KomodoCafe;
using System.Collections.Generic;

namespace _01_KomodoCafe_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly MenuRepository menuRepository = new MenuRepository();


        [TestInitialize]
        public void SeedRepository()
        {
            Meals mealOne = new Meals(1, "hamburger", "lil pieve of americana", new List<string> { "bun", "pickle", "patty", "cheese", "lettuce", "tomato", "onion" }, 8d);
            Meals mealTwo = new Meals(2, "Meatloaf", "mystery Meat", new List<string> { "ingedrient1", "ingedrient2", "ingedrient3" }, 15d);
            Meals mealThree = new Meals(3, "Meatloaf", "Loaf of Meat", new List<string> { "ing1", "ing2", "ing3" }, 16d);
            Meals mealFour = new Meals(4, "Meatloaf", "Loaf of Meat", new List<string> { "ing1", "ing2", "ing3" }, 11d);
            Meals mealFive = new Meals(5, "Meatloaf", "Loaf of Meat", new List<string> { "ing1", "ing2", "ing3" }, 10d);

            menuRepository.AddMealToMenu(mealOne);
            menuRepository.AddMealToMenu(mealTwo);
            menuRepository.AddMealToMenu(mealThree);
            menuRepository.AddMealToMenu(mealFour);
            menuRepository.AddMealToMenu(mealFive);
        }



        [TestMethod]
        public void TestAddShouldAddToMenu()
        {
            Meals shepherdsPie = new Meals(6, "shepherds pie", "pie of shep herds", new List<string> { "ing1", "ing2", "ing3" }, 12d);

            bool wasAdded = menuRepository.AddMealToMenu(shepherdsPie);

            Console.WriteLine(shepherdsPie.MenuNumber);

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void TestGetMealsList()
        {

            int actual = menuRepository.GetMenu().Count;
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteMealTest()
        {

            menuRepository.DeleteMenuItem(menuRepository.SearchRepoByInputReturnList("hamburger"));

            int actual = menuRepository.GetMenu().Count;
            int expected = 4;
            Assert.AreEqual(expected, actual);
        }
    }
}
