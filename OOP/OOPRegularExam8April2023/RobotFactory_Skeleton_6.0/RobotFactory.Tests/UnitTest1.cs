using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private const string _Name = "TestName";
        private const int _Capacity = 4;
        Factory factory;

        [SetUp]
        public void Setup()
        {
            factory = new Factory(_Name, _Capacity);
        }

        [Test]
        public void TestCreatingFactory()
        {
            Assert.IsNotNull(factory);
            Assert.IsNotNull(factory.Robots);
            Assert.IsNotNull(factory.Supplements);
            Assert.AreEqual(_Name, factory.Name);
            Assert.AreEqual(_Capacity, factory.Capacity);
        }

        [TestCase("R2D2", 500, 1212)]
        public void TestProduceRobot(string model, double price, int interfaceStandard)
        {
            Robot robot = new Robot(model, price, interfaceStandard);
            Assert.IsNotNull(robot);
            Assert.AreEqual($"Produced --> {robot}", factory.ProduceRobot(model, price, interfaceStandard)); ;
        }

        [TestCase("R2D2", 500, 1212)]
        public void TestIncreaseRobotsCount_WhenProduceRobot(string model, double price, int interfaceStandard)
        {
            factory.ProduceRobot(model, price, interfaceStandard);
            Assert.AreEqual(1, factory.Robots.Count);
        }

        [TestCase("R2D2", 500, 1212)]
        public void TestFactoryCapacity_WhenProduceRobot(string model, double price, int interfaceStandard)
        {
            factory.ProduceRobot(model, price, interfaceStandard);
            factory.ProduceRobot(model, price, interfaceStandard);
            factory.ProduceRobot(model, price, interfaceStandard);
            factory.ProduceRobot(model, price, interfaceStandard);
            Assert.AreEqual("The factory is unable to produce more robots for this production day!", factory.ProduceRobot(model, price, interfaceStandard));
        }

        [TestCase(_Name, 1212)]
        public void TestProduceSupplement(string name, int interfaceStandard)
        {
            Supplement supplement = new Supplement(name, interfaceStandard);
            Assert.IsNotNull(new Supplement(name, interfaceStandard));
            factory.ProduceSupplement(name, interfaceStandard);
            Assert.AreEqual(1, factory.Supplements.Count);
            Assert.AreEqual(supplement.ToString(), factory.ProduceSupplement(name, interfaceStandard));

        }

        [Test]
        public void TestUpgradeRobot()
        {
            Robot robot = new Robot("R2D2", 500, 1212);
            Supplement supplement = new Supplement("Brain", 1212);
            Assert.AreEqual(true, factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void TestCounOfSupplement_WhenUpgradeRobot()
        {
            Robot robot = new Robot("R2D2", 500, 1212);
            Supplement supplement = new Supplement("Brain", 1212);
            factory.UpgradeRobot(robot, supplement);
            Assert.AreEqual(true, robot.Supplements.Contains(supplement));
        }

        [Test]
        public void TestReAddInterface()
        {
            Robot robot = new Robot("R2D2", 500, 1212);
            Supplement supplement = new Supplement("Brain", 1212);
            factory.UpgradeRobot(robot, supplement);
            Assert.AreEqual(false, factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void TestAddInvalidInterface()
        {
            Robot robot = new Robot("R2D2", 500, 1111);
            Supplement supplement = new Supplement("Brain", 1212);
            Assert.AreEqual(false, factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void TestAddSupplementTwice()
        {
            Robot robot = new Robot("R2D2", 500, 1111);
            Supplement supplement = new Supplement("Brain", 1212);
            factory.UpgradeRobot(robot, supplement);
            Assert.AreEqual(false, factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void SellRobot()
        {
            Robot robot2 = new Robot("Robocop", 1000, 1111);

            factory.ProduceRobot("R2D2", 500, 1111);
            factory.ProduceRobot("Robocop", 1000, 1111);
            factory.ProduceRobot("Terminator", 10000, 1111);

            Assert.IsNotNull(factory.SellRobot(1000));
            Assert.IsTrue(factory.SellRobot(1000).Price == 1000);
        }

        [Test]
        public void SellRobot2()
        {
            Robot robot1 = new Robot("R2D2", 500, 1111);
            Robot robot2 = new Robot("Robocop", 1000, 1111);
            Robot robot3 = new Robot("Terminator", 10000, 1111);

            Assert.AreEqual(null, factory.SellRobot(100000));
        }
    }
}