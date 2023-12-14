using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private const int _WaterCapacity = 250;
        private const int _ButtonsCount = 3;
        private const string _Name = "Name";
        private const double _Price = 3.0;
        CoffeeMat coffeeMat;

        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(_WaterCapacity, _ButtonsCount);
        }

        [Test]
        public void Creating_CoffeMat_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(coffeeMat);
            Assert.AreEqual(_WaterCapacity, coffeeMat.WaterCapacity);
            Assert.AreEqual(_ButtonsCount, coffeeMat.ButtonsCount);
            Assert.AreEqual(0, coffeeMat.Income);
            Assert.AreEqual(true, coffeeMat.AddDrink(_Name, _Price));
        }

        [Test]
        public void FullWaterTank_ShouldReturnMessage()
        {
            coffeeMat.FillWaterTank();
            Assert.AreEqual("Water tank is already full!", coffeeMat.FillWaterTank());
        }

        [Test]
        public void NotFullWaterTank_ShouldReturnMessage()
        {
            Assert.AreEqual($"Water tank is filled with {_WaterCapacity}ml", coffeeMat.FillWaterTank());
        }

        [Test]
        public void TestDrinksCount()
        {
            coffeeMat.AddDrink($"{_Name}1", _Price);
            coffeeMat.AddDrink($"{_Name}2", _Price);
            coffeeMat.AddDrink($"{_Name}3", _Price);
            Assert.AreEqual(false, coffeeMat.AddDrink($"{_Name}4", _Price));
        }

        [Test]
        public void TestAddDrinksTwice()
        {
            coffeeMat.AddDrink($"{_Name}1", _Price);
            Assert.AreEqual(false, coffeeMat.AddDrink($"{_Name}1", _Price));
        }

        [Test]
        public void TestAddDrinks()
        {
            Assert.AreEqual(true, coffeeMat.AddDrink($"{_Name}1", _Price));
        }

        [Test]
        public void TestBayDrink()
        {
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink($"{_Name}1", _Price);
            Assert.AreEqual($"Your bill is {_Price:f2}$", coffeeMat.BuyDrink($"{_Name}1"));
        }

        [Test]
        public void TestBayInvalidDrink()
        {
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink($"{_Name}1", _Price);
            Assert.AreEqual($"{_Name}2 is not available!", coffeeMat.BuyDrink($"{_Name}2"));
        }

        [Test]
        public void TestBayWhenOutOfWater()
        {
            coffeeMat.AddDrink($"{_Name}1", _Price);
            Assert.AreEqual("CoffeeMat is out of water!", coffeeMat.BuyDrink($"{_Name}1"));
        }

        [Test]
        public void TestCollectIncome()
        {
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink($"{_Name}1", _Price);
            coffeeMat.BuyDrink($"{_Name}1");
            Assert.AreEqual(_Price, coffeeMat.CollectIncome());
        }

        [Test]
        public void Test7()
        {
            Assert.Pass();
        }
    }
}