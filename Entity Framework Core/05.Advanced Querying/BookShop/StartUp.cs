namespace BookShop;

using BookShop.Models.Enums;
using Data;
using System;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using var context = new BookShopContext();
        //DbInitializer.ResetDatabase(db);

        Console.WriteLine(GetBooksByCategory(context, "horror mystery drama"));
    }



    //Task 7
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        DateTime dateTime = DateTime.Parse(date);

        var books = context.Books
            .Where(b => b.ReleaseDate < dateTime)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new
            {
                b.Title,
                b.EditionType,
                b.Price
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Task 6
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] listOfCategories = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => w.ToLower())
            .ToArray();



        var booksTitle = context.Books
            .Where(b => b.BookCategories
                .Any(bc => listOfCategories.Contains(bc.Category.Name.ToLower())))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, booksTitle);
    }

    //Task 5
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        string[] books = context.Books
            .Where(b => b.ReleaseDate!.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        string result = string.Join(Environment.NewLine, books);

        return result;
    }

    //Task 4
    public static string GetBooksByPrice(BookShopContext context)
    {
        var books = context.Books
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => new
            {
                b.Title,
                b.Price
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Task 3
    public static string GetGoldenBooks(BookShopContext context)
    {
        EditionType editionType = Enum.Parse<EditionType>("Gold");

        string[] books = context.Books
            .Where(b => b.EditionType == editionType && b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        string result = string.Join(Environment.NewLine, books);

        return result;
    }

    //Task 2
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        var books = context.Books
            .OrderBy(b => b.Title)
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in books)
        {
            if (book.AgeRestriction.ToString().ToLower() == command.ToLower())
            {
                sb.AppendLine(book.Title);
            }

        }

        return sb.ToString().TrimEnd();
    }

}




