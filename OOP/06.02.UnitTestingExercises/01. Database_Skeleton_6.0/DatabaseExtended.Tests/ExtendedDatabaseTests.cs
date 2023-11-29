namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        public const long initId = 100;
        public const long testId = 200;
        public const string initName = "init";
        public const string testName = "test";
        public Person person;

        [SetUp]
        public void Setup()
        {
            database = new();
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(100000 + i, $"test{i}"));
            }

            person = new Person(initId, initName);
        }

        [Test]
        public void WhenCreateDatabase_CountShouldBeCorrect()
        {
            Assert.IsNotNull(database);
            Assert.AreEqual(16, database.Count);
        }

        [TestCase]
        public void WhenCreateDatabaseWithMoreThan16Elements_ShouldThrowInvalidOperationException()
        {
            Person[] arrayOfPersons = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                arrayOfPersons[i] = (new Person(100000 + i, $"test{i}"));
            }

            ArgumentException exception = Assert.Throws<ArgumentException>(() => database = new Database(arrayOfPersons));

            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
        }

        [TestCase(111)]
        public void WhenAddMoreThan16Elements_ShouldThrowInvalidOperationException(int element)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(10017, "test17")));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);

        }

        [TestCase(4)]
        public void AddMethod_ShouldIncreaseCount(int element)
        {
            database = new Database(new Person(10017, "test17"));
            database.Add(new Person(10018, "test18"));

            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void WhenAddЕxistingUsername_ShouldThrowException()
        {
            database = new Database(new Person(10017, "test17"));

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(10018, "test17")));
        }

        [Test]
        public void WhenAddЕxistingID_ShouldThrowException()
        {
            database = new Database(new Person(10017, "test17"));

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(10017, "test18")));
        }

        [Test]
        public void WhenTryRemoveElementInEmptyCollection_ShouldThrowInvalidOperationException()
        {
            database = new();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethod_ShouldDecreaseCount()
        {
            database.Remove();

            Assert.AreEqual(15, database.Count);
        }

        [Test]
        public void FindByUsername_ShouldWorkCorrectly()
        {
            Person actual = database.FindByUsername("test2");
            Assert.AreEqual("test2", actual.UserName);
        }

        [Test]
        public void WhenUseEmptyStringForUsername_SholdThrowArgumentNullException()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(""));

            Assert.AreEqual("Value cannot be null. (Parameter 'Username parameter is null!')", exception.Message);
        }

        [Test]
        public void WhenUseInvalidUsername_SholdThrowInvalidOperationException()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.FindByUsername("invalidUsername"));

            Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [Test]
        public void FindById_ShouldWorkCorrectly()
        {
            Person actual = database.FindById(100002);
            Assert.AreEqual(100002, actual.Id);
        }

        [Test]
        public void WhenUseNegativeId_SholdThrowArgumentOutOfRangeException()
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-100002));

            Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'Id should be a positive number!')", exception.Message);
        }

        [Test]
        public void WhenUseInvalidId_SholdThrowInvalidOperationException()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.FindById(1));

            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }

        [Test]
        public void CreatePerson_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(person);
            Assert.AreEqual(initId, person.Id);
            Assert.AreEqual(initId, person.Id);
        }

        //[Test]
        //public void RemoveMethod_ShouldWorkCorrectly()
        //{
        //    List<int> databaseAsList = new(databaseInput);

        //    for (int i = database.Count - 1; i >= 0; i--)
        //    {
        //        databaseAsList.RemoveAt(i);
        //        database.Remove();

        //        Assert.AreEqual(databaseAsList, database.Fetch());
        //    }
        //}


    }
}