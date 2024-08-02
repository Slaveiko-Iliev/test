﻿namespace BookShop;

using BookShop.Initializer;
using BookShop.Models;
using BookShop.Models.Enums;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

public class StartUp
{
    public static void Main()
    {
        using var context = new BookShopContext();
        //DbInitializer.ResetDatabase(context);

        Console.WriteLine(RemoveBooks(context));

        IncreasePrices(context);
    }

    //Task 16
    public static int RemoveBooks(BookShopContext context)
    {
        Book[] booksToDelete = context.Books
            .Where(b => b.Copies < 4200)
            .ToArray();

        int countOfBooksToDelete = booksToDelete.Length;

        foreach (var book in booksToDelete)
        {
            context.Books.Remove(book);
        }

        context.SaveChanges();

        return countOfBooksToDelete;
    }

    //Task 15
    public static void IncreasePrices(BookShopContext context)
    {
        Book[] books = context.Books
            .Where(b => b.ReleaseDate.Value.Year < 2010)
            .ToArray();

        foreach (var book in books)
        {
            book.Price += 5;
        }

        context.SaveChanges();
    }

    //Task 14
    public static string GetMostRecentBooks(BookShopContext context)
    {
        var recentBooksByCategories = context.Categories
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                CategoryName = c.Name,
                MostResentBooks = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => new
                    {
                        cb.Book.Title,
                        cb.Book.ReleaseDate
                    })
                    .ToArray()
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var category in recentBooksByCategories)
        {
            sb.AppendLine($"--{category.CategoryName}");

            foreach (var book in category.MostResentBooks)
            {
                sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //Task 13
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        var profitsByCategory = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks
                        .Sum(bc => bc.Book.Copies * bc.Book.Price)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName);

        return string.Join(Environment.NewLine, profitsByCategory
                                                    .Select(p => $"{p.CategoryName} ${p.TotalProfit:f2}"));
    }

    //Task 12
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        var books = context.Authors
            .Select(a => new
            {
                FullName = $"{a.FirstName} {a.LastName}",
                TotalBooks = a.Books.Sum(b => b.Copies)
            })
            .OrderByDescending(b => b.TotalBooks)
            .ToArray();

        return string.Join(Environment.NewLine, books.Select(b => $"{b.FullName} - {b.TotalBooks}"));
    }

    //Task 11
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        var books = context.Books
            .Where(b => b.Title.Length > lengthCheck);

        return books.Count();
    }

    //Task 10
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        var books = context.Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                b.Title,
                FullName = b.Author.FirstName + " " + b.Author.LastName
            })
            .ToArray();
        


        return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.FullName})"));
    }

    //Task 9
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var titles = context.Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .OrderBy(b => b.Title)
            .Select(b => new
            {
                b.Title
            })
            .ToArray();

        return string.Join(Environment.NewLine, titles.Select(t => t.Title));
    }

    //Task 8
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var authors = context.Authors
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => new
            {
                FullName = a.FirstName + " " + a.LastName
            })
            .OrderBy(a => a.FullName)
            .ToArray();
        
        return string.Join(Environment.NewLine, authors.Select(a => a.FullName));
    }

    //Task 7
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        var dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

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
        string[] books = context.Books
            .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
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



