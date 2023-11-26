namespace Database.Tests
{
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private int[] databaseInput = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private int testDataBaseCount;

        [SetUp]
        public void Setup()
        {
            database = new(databaseInput);
            testDataBaseCount = databaseInput.Length;
        }

        [Test]
        public void WhenCreateDatabase_CountShouldBeCorrect()
        {
            int expectedCount = testDataBaseCount;
            int actualCount = database.Count;

            Assert.IsNotNull(database);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]

        public void WhenCreateDatabaseWithMoreThan16Elements_ShouldThrowInvalidOperationException(int[] data)
        {
            string errorInvalidOperationException = "Array's capacity must be exactly 16 integers!";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database = new Database(data));

            Assert.AreEqual(errorInvalidOperationException, exception.Message);
        }

        [TestCase(111)]
        public void WhenAddMoreThan16Elements_ShouldThrowInvalidOperationException(int element)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(element));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);

        }

        [TestCase(4)]
        public void AddMethod_ShouldIncreaseCount(int element)
        {
            database = new(1, 2);
            int expectedCount = 3;

            database.Add(element);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(new int[] { 1, 2, 5, 8, 6 })]
        public void AddMethod_ShouldAddCorrectly(int[] inputArray)
        {
            database = new();

            foreach (int element in inputArray)
            {
                database.Add(element);
            }

            Assert.AreEqual(inputArray, database.Fetch());
        }

        [Test]
        public void WhenTryRemoveElementInEmptyCollection_ShouldThrowInvalidOperationException()
        {
            database = new();
            string errorInvalidOperationException = "The collection is empty!";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Remove());
            Assert.AreEqual(errorInvalidOperationException, exception.Message);
        }

        [Test]
        public void RemoveMethod_ShouldDecreaseCount()
        {
            database.Remove();

            Assert.AreEqual(testDataBaseCount - 1, database.Count);
        }

        [Test]
        public void RemoveMethod_ShouldWorkCorrectly()
        {
            List<int> databaseAsList = new(databaseInput);

            for (int i = database.Count - 1; i >= 0; i--)
            {
                databaseAsList.RemoveAt(i);
                database.Remove();

                Assert.AreEqual(databaseAsList, database.Fetch());
            }
        }

        [Test]
        public void FetchMethod_ShouldReturnElementsAsArray()
        {
            int[] copyDatabase = database.Fetch();
            Assert.AreEqual(databaseInput, copyDatabase);
        }
    }
}
