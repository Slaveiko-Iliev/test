using System;

namespace UniversityLibrary
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            UniversityLibrary ul = new UniversityLibrary();
            TextBook textBook = new TextBook("Title", "Author", "Category");
            ul.AddTextBookToLibrary(textBook);

            foreach (var book in ul.Catalogue)
            {
                Console.WriteLine(book.ToString());
            }

        }
    }
}
