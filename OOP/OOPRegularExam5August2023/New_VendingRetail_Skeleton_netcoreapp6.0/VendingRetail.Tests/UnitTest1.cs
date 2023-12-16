using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private const int _WaterCapacity = 320;
        private const int _ButtonsCount = 3;
        CoffeeMat coffeeMat;

        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(_WaterCapacity, _ButtonsCount);
        }

        [Test]
        public void TestCreatingCoffeeMat()
        {
            Assert.IsNotNull(coffeeMat);
            Assert.AreEqual(_WaterCapacity, coffeeMat.WaterCapacity);
            Assert.AreEqual(_ButtonsCount, coffeeMat.ButtonsCount);
            Assert.AreEqual(0, coffeeMat.Income);
        }

        [Test]
        public void TestFillFullWaterTank()
        {
            coffeeMat.FillWaterTank();
            Assert.Pass("Water tank is already full!", coffeeMat.FillWaterTank());
        }

        [Test]
        public void TestFillWaterTank()
        {
            Assert.AreEqual($"Water tank is filled with {_WaterCapacity}ml", coffeeMat.FillWaterTank());
            coffeeMat.AddDrink("coffee", 2.0);
            coffeeMat.BuyDrink("coffee");
            Assert.AreEqual($"Water tank is filled with {80}ml", coffeeMat.FillWaterTank());
        }

        [Test]
        public void TestAddDrink()
        {
            Assert.AreEqual(true, coffeeMat.AddDrink("coffee", 2));
        }

        [Test]
        public void TestAddDrinkTwice()
        {
            coffeeMat.AddDrink("coffee", 2);
            Assert.AreEqual(false, coffeeMat.AddDrink("coffee", 2));
        }

        [Test]
        public void TestAddDrinkWithoutFreeButton()
        {
            coffeeMat.AddDrink("coffee", 2);
            coffeeMat.AddDrink("coffeeLate", 2);
            coffeeMat.AddDrink("coffeeTurkish", 2);
            Assert.AreEqual(false, coffeeMat.AddDrink("coffeeLate", 2));
        }

        [Test]
        public void TestBuyDrinkButNoWater()
        {
            coffeeMat.AddDrink("coffee", 2);
            Assert.AreEqual("CoffeeMat is out of water!", coffeeMat.BuyDrink("coffee"));
            coffeeMat.FillWaterTank();
            coffeeMat.BuyDrink("coffee");
            coffeeMat.BuyDrink("coffee");
            coffeeMat.BuyDrink("coffee");
            coffeeMat.BuyDrink("coffee");
            Assert.AreEqual("CoffeeMat is out of water!", coffeeMat.BuyDrink("coffee"));
        }

        [Test]
        public void TestBuyInvalidDrink()
        {
            coffeeMat.FillWaterTank();
            Assert.AreEqual("coffee is not available!", coffeeMat.BuyDrink("coffee"));
            coffeeMat.AddDrink("coffee", 2);
            Assert.AreEqual("coffeeLate is not available!", coffeeMat.BuyDrink("coffeeLate"));
        }

        [Test]
        public void TestBuyDrink()
        {
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("coffee", 2);
            Assert.AreEqual("Your bill is 2.00$", coffeeMat.BuyDrink("coffee"));
            Assert.AreEqual($"Water tank is filled with {80}ml", coffeeMat.FillWaterTank());
        }

        [Test]
        public void TestCollectIncome()
        {
            coffeeMat.AddDrink("coffee", 2);
            coffeeMat.AddDrink("coffeeLate", 2);
            coffeeMat.AddDrink("coffeeTurkish", 2);
            coffeeMat.FillWaterTank();
            coffeeMat.BuyDrink("coffee");
            Assert.AreEqual(2.00, coffeeMat.CollectIncome());
            Assert.AreEqual(0.00, coffeeMat.Income);
        }

    }
}