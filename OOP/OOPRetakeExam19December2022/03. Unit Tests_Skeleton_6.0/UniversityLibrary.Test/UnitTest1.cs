namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Linq;
    using System.Text;

    public class Tests
    {
        UniversityLibrary ul;
        TextBook textBook;
        StringBuilder sb;

        [SetUp]
        public void Setup()
        {
            ul = new UniversityLibrary();
            textBook = new TextBook("Title", "Author", "Category");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Book: Title - 1");
            sb.AppendLine("Category: Category");
            sb.AppendLine("Author: Author");
        }

        [Test]
        public void CreatingUniversityLibrary_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(ul);
            Assert.IsNotNull(ul.Catalogue);
        }

        [Test]
        public void AddTextBookToLibrary_ShouldWorkCorrectly()
        {
            ul.AddTextBookToLibrary(textBook);
            Assert.AreEqual(1, ul.Catalogue.First(b => b.Title == "Title").InventoryNumber);
            Assert.AreEqual(1, ul.Catalogue.Count);
            Assert.AreEqual(sb.ToString().TrimEnd(), ul.Catalogue.First(b => b.Title == "Title").ToString());
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}