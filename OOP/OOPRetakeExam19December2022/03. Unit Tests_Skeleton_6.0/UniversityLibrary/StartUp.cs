using System;

namespace UniversityLibrary
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            UniversityLibrary ul = new UniversityLibrary();

            ul.AddTextBookToLibrary(textBook);
            TextBook textBook = new TextBook("Title", "Author", "Category");
            foreach (var book in ul.Catalogue)
            {
                Console.WriteLine(book.ToString());
            }

        }
    }
}
