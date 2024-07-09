namespace BookShop;

using Data;
using System;
using Initializer;
using System.Text;
using BookShop.Models;
using BookShop.Models.Enums;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        //DbInitializer.ResetDatabase(db);

        //Task 2 string command = Console.ReadLine();
        // Task 2 Console.WriteLine(GetBooksByAgeRestriction(db, command));

        Console.WriteLine(GetBooksByPrice(db));
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
            sb.AppendLine($"{book.Title} - {book.Price:f2}");
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




