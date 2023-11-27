namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new();
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(100000 + i, $"test{i}"));
            }
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
            for (int i = 0; i < 16; i++)
            {
                arrayOfPersons[i] = (new Person(100000 + i, $"test{i}"));
            }

            ArgumentException exception = Assert.Throws<ArgumentException>(() => database = new Database(arrayOfPersons));

            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
        }

        //[TestCase(111)]
        //public void WhenAddMoreThan16Elements_ShouldThrowInvalidOperationException(int element)
        //{
        //    InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(element));
        //    Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);

        //}

        //[TestCase(4)]
        //public void AddMethod_ShouldIncreaseCount(int element)
        //{
        //    database = new(1, 2);
        //    int expectedCount = 3;

        //    database.Add(element);

        //    Assert.AreEqual(expectedCount, database.Count);
        //}

        //[TestCase(new int[] { 1, 2, 5, 8, 6 })]
        //public void AddMethod_ShouldAddCorrectly(int[] inputArray)
        //{
        //    database = new();

        //    foreach (int element in inputArray)
        //    {
        //        database.Add(element);
        //    }

        //    Assert.AreEqual(inputArray, database.Fetch());
        //}

        //[Test]
        //public void WhenTryRemoveElementInEmptyCollection_ShouldThrowInvalidOperationException()
        //{
        //    database = new();
        //    string errorInvalidOperationException = "The collection is empty!";

        //    InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Remove());
        //    Assert.AreEqual(errorInvalidOperationException, exception.Message);
        //}

        //[Test]
        //public void RemoveMethod_ShouldDecreaseCount()
        //{
        //    database.Remove();

        //    Assert.AreEqual(testDataBaseCount - 1, database.Count);
        //}

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

        //[Test]
        //public void FetchMethod_ShouldReturnElementsAsArray()
        //{
        //    int[] copyDatabase = database.Fetch();
        //    Assert.AreEqual(databaseInput, copyDatabase);
        //}
    }
}