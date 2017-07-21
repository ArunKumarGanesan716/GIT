using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodScheduler;

namespace TestFoodScheduler
{
    [TestClass]
    public class TestFoodScheduler
    {
        [TestMethod]
        public void TestDefault()
        {
            Program.ExecuteOrder("morning,1,2,3,4", false);
        }

        [TestMethod]
        public void TestCommaSeperation()
        {
            Program.ExecuteOrder("morning1", false);
        }

        [TestMethod]
        public void TestSelectDish()
        {
            Program.ExecuteOrder("night", false);
        }

        [TestMethod]
        public void TestFoodOrder()
        {
            Program.ExecuteOrder("night,2,3,1,4", false);
        }

        [TestMethod]
        public void TestNoDessertMorning()
        {
            Program.ExecuteOrder("morning,4", false);
        }

        [TestMethod]
        public void TestCaseSensitive()
        {
            Program.ExecuteOrder("MoRnInG,1", false);
        }

        [TestMethod]
        public void TestInvalidSelection()
        {
            Program.ExecuteOrder("night,1,2,apple", false);
        }

        [TestMethod]
        public void TestInvalidSelectionStopOnError()
        {
            Program.ExecuteOrder("night,1,2,3,4,5,6,7,8", false);
        }
        [TestMethod]
        public void TestMultipleCoffeeOrder()
        {
            Program.ExecuteOrder("Morning,1,2,3,3,3,3", false);
        }
        [TestMethod]
        public void TestMultiplePotatoOrder()
        {
            Program.ExecuteOrder("night,1,2,2,2,2,2", false);
        }

        [TestMethod]
        public void TestSingleOrder()
        {
            Program.ExecuteOrder("night,1,1,1,2,2,2,3,3,3,4,4,4", false);
        }
    }
}
